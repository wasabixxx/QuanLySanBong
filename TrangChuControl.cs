using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Drawing.Printing;
using System.Linq;

namespace QuanLySanBong
{
    public partial class TrangChuControl : UserControl
    {
        private string connectionString = "Data Source=QuanLySanBong.db;Version=3;";
        private Dictionary<int, string> sanNames = new Dictionary<int, string>();
        private int selectedMaDatSan = -1;
        private string selectedTenSan;
        private string selectedGioBatDau;
        private string selectedGioKetThuc;
        private string selectedNgayDat;
        private HashSet<int> cancelledBookingsShown = new HashSet<int>();
        private static readonly HttpClient httpClient = new HttpClient();
        private Dictionary<int, Image> qrCodeCache = new Dictionary<int, Image>();
        private readonly object qrCacheLock = new object(); // Lock for QR cache
        private bool isLoadingQR = false;
        private Label loadingLabel;
        private readonly object dbLock = new object(); // Lock for database access
        private const int MaxQrRetries = 3; // Max retries for QR loading
        private const int RetryDelayMs = 1000; // Delay between retries in milliseconds

        public TrangChuControl()
        {
            InitializeComponent();
            InitializeLoadingLabel();
            LoadSanNames();
            LoadDatSanData();
            SetupDataGridView();
            SetupComboBoxPhuongThuc();
            this.Resize += new EventHandler(TrangChuControl_Resize);
            httpClient.Timeout = TimeSpan.FromSeconds(15); // Increased timeout
        }

        private void InitializeLoadingLabel()
        {
            loadingLabel = new Label();
            loadingLabel.Text = "Đang tải mã QR...";
            loadingLabel.Font = new Font("Arial", 10);
            loadingLabel.AutoSize = true;
            loadingLabel.Visible = false;
            panelThongTinThanhToan.Controls.Add(loadingLabel);
        }

        private void TrangChuControl_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            int width = Math.Max(this.ClientSize.Width, 800);
            int height = Math.Max(this.ClientSize.Height, 600);

            labelTitle.Width = width;

            flowLayoutPanelSan.Width = width / 2 - 30;
            flowLayoutPanelSan.Height = height - 80;

            panelThongTinDatSan.Location = new Point(width / 2 + 10, 60);
            panelThongTinDatSan.Width = width / 2 - 40;
            panelThongTinDatSan.Height = (height - 100) / 2;

            dataGridViewDatSan.Width = panelThongTinDatSan.Width - 20;
            dataGridViewDatSan.Height = panelThongTinDatSan.Height - 60;

            panelThongTinThanhToan.Location = new Point(width / 2 + 10, panelThongTinDatSan.Bottom + 10);
            panelThongTinThanhToan.Width = width / 2 - 40;
            panelThongTinThanhToan.Height = (height - 100) / 2 - 20;

            textBoxNguoiDat.Width = panelThongTinThanhToan.Width - 140;
            textBoxTongTien.Width = panelThongTinThanhToan.Width - 140;
            comboBoxPhuongThuc.Width = panelThongTinThanhToan.Width - 140;

            pictureBoxQRCode.Width = 200;
            pictureBoxQRCode.Height = 250;
            pictureBoxQRCode.Location = new Point((panelThongTinThanhToan.Width - pictureBoxQRCode.Width) / 2, 160);

            loadingLabel.Location = new Point((panelThongTinThanhToan.Width - loadingLabel.Width) / 2, pictureBoxQRCode.Top - 30);

            buttonInHoaDon.Location = new Point((panelThongTinThanhToan.Width - buttonInHoaDon.Width) / 2, panelThongTinThanhToan.Height - 60);
            buttonThanhToan.Location = new Point(panelThongTinThanhToan.Width - 120, panelThongTinThanhToan.Height - 110);
        }

        private void LoadSanNames()
        {
            lock (dbLock)
            {
                SQLiteConnection conn = null;
                try
                {
                    conn = new SQLiteConnection(connectionString);
                    conn.Open();
                    string query = "SELECT MaSan, TenSan FROM SanBong";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int maSan = reader.GetInt32(0);
                            string tenSan = reader.GetString(1);
                            sanNames[maSan] = tenSan;
                        }
                    }
                }
                catch (SQLiteException ex) when (ex.Message.Contains("database is locked"))
                {
                    MessageBox.Show("Cơ sở dữ liệu đang bị khóa, thử lại sau vài giây.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách sân: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conn != null && conn.State != System.Data.ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void LoadDatSanData()
        {
            lock (dbLock)
            {
                flowLayoutPanelSan.Controls.Clear();

                SQLiteConnection conn = null;
                try
                {
                    conn = new SQLiteConnection(connectionString);
                    conn.Open();
                    string query = @"
                        SELECT d.MaSan, d.NgayDat, d.GioBatDau, d.GioKetThuc, d.TrangThai, d.MaDatSan, d.TrangThaiThanhToan
                        FROM DatSan d
                        WHERE DATE(d.NgayDat) >= DATE('now', 'start of day')
                        ORDER BY d.MaSan, d.NgayDat, d.GioBatDau";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        Dictionary<int, List<(string NgayDat, string GioBatDau, string GioKetThuc, string TrangThai, int MaDatSan, int TrangThaiThanhToan)>> sanData = new Dictionary<int, List<(string, string, string, string, int, int)>>();

                        while (reader.Read())
                        {
                            int maSan = reader.GetInt32(0);
                            string ngayDat = reader.GetString(1);
                            string gioBatDau = reader.GetString(2);
                            string gioKetThuc = reader.GetString(3);
                            string trangThai = reader.GetString(4);
                            int maDatSan = reader.GetInt32(5);
                            int trangThaiThanhToan = reader.GetInt32(6);

                            if (!sanData.ContainsKey(maSan))
                            {
                                sanData[maSan] = new List<(string, string, string, string, int, int)>();
                            }
                            sanData[maSan].Add((ngayDat, gioBatDau, gioKetThuc, trangThai, maDatSan, trangThaiThanhToan));
                        }

                        foreach (var san in sanData)
                        {
                            int maSan = san.Key;
                            string tenSan = sanNames.ContainsKey(maSan) ? sanNames[maSan] : "Sân " + maSan;
                            Panel panelSan = CreateSanPanel(tenSan, san.Value);
                            flowLayoutPanelSan.Controls.Add(panelSan);
                        }
                    }
                }
                catch (SQLiteException ex) when (ex.Message.Contains("database is locked"))
                {
                    MessageBox.Show("Cơ sở dữ liệu đang bị khóa, thử lại sau vài giây.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu đặt sân: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conn != null && conn.State != System.Data.ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }
            }
        }

        private Panel CreateSanPanel(string tenSan, List<(string NgayDat, string GioBatDau, string GioKetThuc, string TrangThai, int MaDatSan, int TrangThaiThanhToan)> khungGios)
        {
            Panel panel = new Panel();
            panel.Size = new Size(flowLayoutPanelSan.Width - 30, 150);
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.BackColor = Color.White;
            panel.Margin = new Padding(10);

            Label labelTenSan = new Label();
            labelTenSan.Text = tenSan;
            labelTenSan.Font = new Font("Arial", 12, FontStyle.Bold);
            labelTenSan.Location = new Point(10, 10);
            labelTenSan.Size = new Size(100, 30);
            panel.Controls.Add(labelTenSan);

            int y = 50;
            int x = 10;
            foreach (var khung in khungGios)
            {
                Button btnKhungGio = new Button();
                btnKhungGio.Text = khung.GioBatDau + " - " + khung.GioKetThuc + " ĐS " + khung.MaDatSan;
                btnKhungGio.Size = new Size(180, 40);
                btnKhungGio.Location = new Point(x, y);
                btnKhungGio.FlatStyle = FlatStyle.Flat;
                btnKhungGio.BackColor = khung.TrangThaiThanhToan == 1 ? Color.FromArgb(0, 255, 0) : Color.Red;
                btnKhungGio.Tag = khung.MaDatSan;
                btnKhungGio.Click += async (s, e) => await LoadThongTinDatSan((int)btnKhungGio.Tag);
                panel.Controls.Add(btnKhungGio);

                x += 190;
                if (x + 180 > panel.Width)
                {
                    x = 10;
                    y += 50;
                    if (y + 40 > panel.Height)
                    {
                        panel.Height += 50;
                    }
                }
            }

            return panel;
        }

        private void SetupDataGridView()
        {
            lock (dbLock)
            {
                dataGridViewDatSan.Columns.Clear();
                dataGridViewDatSan.Columns.Add("MaDatSan", "Mã đặt sân");
                dataGridViewDatSan.Columns.Add("MaSan", "Mã sân");
                dataGridViewDatSan.Columns.Add("MaKH", "Mã khách hàng");
                dataGridViewDatSan.Columns.Add("NgayDat", "Ngày đặt");
                dataGridViewDatSan.Columns.Add("GioBatDau", "Giờ bắt đầu");
                dataGridViewDatSan.Columns.Add("GioKetThuc", "Giờ kết thúc");
                dataGridViewDatSan.Columns.Add("TongTien", "Tổng tiền");
                dataGridViewDatSan.Columns.Add("TrangThaiThanhToan", "Trạng thái thanh toán");
                dataGridViewDatSan.Columns.Add("TrangThai", "Trạng thái");

                SQLiteConnection conn = null;
                try
                {
                    conn = new SQLiteConnection(connectionString);
                    conn.Open();
                    string query = @"
                        SELECT * FROM DatSan
                        WHERE DATE(NgayDat) >= DATE('now', 'start of day')";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridViewDatSan.Rows.Add(
                                reader["MaDatSan"],
                                reader["MaSan"],
                                reader["MaKH"],
                                reader["NgayDat"],
                                reader["GioBatDau"],
                                reader["GioKetThuc"],
                                reader["TongTien"],
                                reader["TrangThaiThanhToan"],
                                reader["TrangThai"]
                            );
                        }
                    }
                }
                catch (SQLiteException ex) when (ex.Message.Contains("database is locked"))
                {
                    MessageBox.Show("Cơ sở dữ liệu đang bị khóa, thử lại sau vài giây.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu lưới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conn != null && conn.State != System.Data.ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }
            }

            dataGridViewDatSan.SelectionChanged += async (s, e) =>
            {
                if (dataGridViewDatSan.SelectedRows.Count > 0)
                {
                    int maDatSan = Convert.ToInt32(dataGridViewDatSan.SelectedRows[0].Cells["MaDatSan"].Value);
                    await LoadThongTinDatSan(maDatSan);
                }
            };
        }

        private void SetupComboBoxPhuongThuc()
        {
            comboBoxPhuongThuc.Items.Clear();
            comboBoxPhuongThuc.Items.Add("Tiền mặt");
            comboBoxPhuongThuc.Items.Add("Chuyển khoản");
            comboBoxPhuongThuc.SelectedIndex = 0;
        }

        private async Task LoadThongTinDatSan(int maDatSan)
        {
            if (isLoadingQR) return;
            isLoadingQR = true;
            selectedMaDatSan = maDatSan;

            try
            {
                // Hiển thị loading
                loadingLabel.Visible = true;
                pictureBoxQRCode.Image = null;
                pictureBoxQRCode.Refresh();

                // Truy vấn cơ sở dữ liệu để lấy thông tin
                string totalBill = null;
                string qrUrl = null;
                lock (dbLock)
                {
                    using (var conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();
                        string query = @"
                    SELECT d.TongTien, d.NgayDat, d.GioBatDau, d.GioKetThuc, k.TenKH, d.TrangThaiThanhToan, s.TenSan, d.TrangThai
                    FROM DatSan d
                    JOIN KhachHang k ON d.MaKH = k.MaKH
                    JOIN SanBong s ON d.MaSan = s.MaSan
                    WHERE d.MaDatSan = @MaDatSan";

                        using (var cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaDatSan", maDatSan);
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    textBoxNguoiDat.Text = reader["TenKH"].ToString();
                                    totalBill = reader["TongTien"].ToString();
                                    textBoxTongTien.Text = totalBill;
                                    selectedTenSan = reader["TenSan"].ToString();
                                    selectedNgayDat = reader["NgayDat"].ToString();
                                    selectedGioBatDau = reader["GioBatDau"].ToString();
                                    selectedGioKetThuc = reader["GioKetThuc"].ToString();
                                    string trangThai = reader["TrangThai"].ToString();
                                    int trangThaiThanhToan = reader.GetInt32(reader.GetOrdinal("TrangThaiThanhToan"));
                                    buttonThanhToan.Enabled = (trangThaiThanhToan == 0 && trangThai != "Đã huỷ");
                                    buttonInHoaDon.Enabled = (trangThaiThanhToan == 0 && trangThai != "Đã huỷ");

                                    if (trangThai == "Đã huỷ" && !cancelledBookingsShown.Contains(maDatSan))
                                    {
                                        MessageBox.Show($"Đặt sân {maDatSan} đã bị huỷ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        cancelledBookingsShown.Add(maDatSan);
                                    }

                                    // Tạo URL QR theo thuật toán ban đầu
                                    string bankId = "MB";
                                    string accountNo = "446619999";
                                    string template = "print";
                                    string accountName = "NGUYEN NGOC KHANH";
                                    string addInfo = $"Thanh toan san bong {maDatSan}";
                                    string encodedAddInfo = Uri.EscapeDataString(addInfo);
                                    string encodedAccountName = Uri.EscapeDataString(accountName);

                                    qrUrl = $"https://img.vietqr.io/image/{bankId}-{accountNo}-{template}.png?amount={totalBill}&addInfo={encodedAddInfo}&accountName={encodedAccountName}";
                                }
                            }
                        }
                    }
                }

                // Tải QR trên luồng nền
                if (qrUrl != null)
                {
                    await Task.Run(() =>
                    {
                        try
                        {
                            // Gán ImageLocation và tải bất đồng bộ trên luồng chính
                            BeginInvoke((Action)(() =>
                            {
                                pictureBoxQRCode.ImageLocation = qrUrl;
                                pictureBoxQRCode.LoadAsync(); // Tải bất đồng bộ
                            }));
                        }
                        catch (Exception ex)
                        {
                            BeginInvoke((Action)(() =>
                            {
                                MessageBox.Show("Không thể tải mã QR. Vui lòng kiểm tra kết nối mạng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                pictureBoxQRCode.Image = null;
                            }));
                        }
                    });
                }
            }
            catch (SQLiteException ex) when (ex.Message.Contains("database is locked"))
            {
                MessageBox.Show("Cơ sở dữ liệu đang bị khóa, thử lại sau vài giây.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin đặt sân: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoadingQR = false;
                BeginInvoke((Action)(() => loadingLabel.Visible = false));
            }
        }

        private void buttonInHoaDon_Click(object sender, EventArgs e)
        {
            if (selectedMaDatSan == -1)
            {
                MessageBox.Show("Vui lòng chọn một khung giờ đặt sân để in hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.PrintHoaDon);
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pd;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }

        private void PrintHoaDon(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("Arial", 12);
            float y = 20;

            g.DrawString("HÓA ĐƠN THANH TOÁN", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new PointF(100, y));
            y += 40;

            g.DrawString("Mã đặt sân: " + selectedMaDatSan, font, Brushes.Black, new PointF(20, y));
            y += 30;
            g.DrawString("Tên sân: " + selectedTenSan, font, Brushes.Black, new PointF(20, y));
            y += 30;
            g.DrawString("Người đặt: " + textBoxNguoiDat.Text, font, Brushes.Black, new PointF(20, y));
            y += 30;
            g.DrawString("Ngày đặt: " + selectedNgayDat, font, Brushes.Black, new PointF(20, y));
            y += 30;
            g.DrawString("Khung giờ: " + selectedGioBatDau + " - " + selectedGioKetThuc, font, Brushes.Black, new PointF(20, y));
            y += 30;
            g.DrawString("Tổng tiền: " + textBoxTongTien.Text + " VND", font, Brushes.Black, new PointF(20, y));
            y += 30;
            g.DrawString("Phương thức thanh toán: " + comboBoxPhuongThuc.SelectedItem, font, Brushes.Black, new PointF(20, y));
            y += 30;
            g.DrawString("Ngày in: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), font, Brushes.Black, new PointF(20, y));
            y += 40;

            if (pictureBoxQRCode.Image != null)
            {
                g.DrawImage(pictureBoxQRCode.Image, new System.Drawing.Rectangle(20, (int)y, 150, 150));
            }
        }

        private void buttonThanhToan_Click(object sender, EventArgs e)
        {
            if (selectedMaDatSan == -1)
            {
                MessageBox.Show("Vui lòng chọn một khung giờ đặt sân để thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal tongTien;
            if (!decimal.TryParse(textBoxTongTien.Text, out tongTien) || tongTien <= 0)
            {
                MessageBox.Show("Tổng tiền không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lock (dbLock)
            {
                SQLiteConnection conn = null;
                SQLiteTransaction transaction = null;
                try
                {
                    conn = new SQLiteConnection(connectionString);
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    string updateQuery = @"
                        UPDATE DatSan
                        SET TrangThaiThanhToan = 1
                        WHERE MaDatSan = @MaDatSan";
                    using (SQLiteCommand updateCmd = new SQLiteCommand(updateQuery, conn, transaction))
                    {
                        updateCmd.Parameters.AddWithValue("@MaDatSan", selectedMaDatSan);
                        updateCmd.ExecuteNonQuery();
                    }

                    string insertQuery = @"
                        INSERT INTO LichSuThanhToan (MaDatSan, SoTien, NgayThanhToan, NoiDungChuyenKhoan)
                        VALUES (@MaDatSan, @SoTien, @NgayThanhToan, @NoiDungChuyenKhoan)";
                    using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conn, transaction))
                    {
                        insertCmd.Parameters.AddWithValue("@MaDatSan", selectedMaDatSan);
                        insertCmd.Parameters.AddWithValue("@SoTien", tongTien);
                        insertCmd.Parameters.AddWithValue("@NgayThanhToan", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        insertCmd.Parameters.AddWithValue("@NoiDungChuyenKhoan", "Thanh toán sân " + selectedMaDatSan + " bằng " + comboBoxPhuongThuc.SelectedItem);
                        insertCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadDatSanData();
                    SetupDataGridView();
                    textBoxNguoiDat.Text = "";
                    textBoxTongTien.Text = "";
                    pictureBoxQRCode.Image = null;
                    buttonThanhToan.Enabled = false;
                    buttonInHoaDon.Enabled = false;
                    selectedMaDatSan = -1;
                }
                catch (SQLiteException ex) when (ex.Message.Contains("database is locked"))
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                    MessageBox.Show("Cơ sở dữ liệu đang bị khóa, thử lại sau vài giây.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                    MessageBox.Show("Lỗi khi thực hiện thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conn != null && conn.State != System.Data.ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Drawing.Printing;

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

        public TrangChuControl()
        {
            InitializeComponent();
            LoadSanNames();
            LoadDatSanData();
            SetupDataGridView();
            SetupComboBoxPhuongThuc();
            this.Resize += new EventHandler(TrangChuControl_Resize);
        }

        private void TrangChuControl_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

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

            buttonInHoaDon.Location = new Point((panelThongTinThanhToan.Width - buttonInHoaDon.Width) / 2, panelThongTinThanhToan.Height - 60);
            buttonThanhToan.Location = new Point(panelThongTinThanhToan.Width - 120, panelThongTinThanhToan.Height - 110);
        }

        private void LoadSanNames()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
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
        }

        private void LoadDatSanData()
        {
            flowLayoutPanelSan.Controls.Clear();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT d.MaSan, d.NgayDat, d.GioBatDau, d.GioKetThuc, d.TrangThai, d.MaDatSan
                    FROM DatSan d
                    WHERE DATE(d.NgayDat) >= DATE('now', 'start of day')
                    ORDER BY d.MaSan, d.NgayDat, d.GioBatDau";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    Dictionary<int, List<(string NgayDat, string GioBatDau, string GioKetThuc, string TrangThai, int MaDatSan)>> sanData = new Dictionary<int, List<(string, string, string, string, int)>>();

                    while (reader.Read())
                    {
                        int maSan = reader.GetInt32(0);
                        string ngayDat = reader.GetString(1);
                        string gioBatDau = reader.GetString(2);
                        string gioKetThuc = reader.GetString(3);
                        string trangThai = reader.GetString(4);
                        int maDatSan = reader.GetInt32(5);

                        if (!sanData.ContainsKey(maSan))
                        {
                            sanData[maSan] = new List<(string, string, string, string, int)>();
                        }
                        sanData[maSan].Add((ngayDat, gioBatDau, gioKetThuc, trangThai, maDatSan));
                    }

                    foreach (var san in sanData)
                    {
                        int maSan = san.Key;
                        string tenSan = sanNames.ContainsKey(maSan) ? sanNames[maSan] : $"Sân {maSan}";
                        Panel panelSan = CreateSanPanel(tenSan, san.Value);
                        flowLayoutPanelSan.Controls.Add(panelSan);
                    }
                }
            }
        }

        private Panel CreateSanPanel(string tenSan, List<(string NgayDat, string GioBatDau, string GioKetThuc, string TrangThai, int MaDatSan)> khungGios)
        {
            Panel panel = new Panel
            {
                Size = new Size(flowLayoutPanelSan.Width - 30, 150),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(10)
            };

            Label labelTenSan = new Label
            {
                Text = tenSan,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(10, 10),
                Size = new Size(100, 30)
            };
            panel.Controls.Add(labelTenSan);

            int y = 50;
            int x = 10;
            foreach (var khung in khungGios)
            {
                Button btnKhungGio = new Button
                {
                    Text = $"{khung.GioBatDau} - {khung.GioKetThuc} ĐS {khung.MaDatSan}",
                    Size = new Size(180, 40),
                    Location = new Point(x, y),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = khung.TrangThai == "Đã đặt" ? Color.Red : Color.FromArgb(0, 255, 0),
                    Tag = khung.MaDatSan
                };
                btnKhungGio.Click += (s, e) => LoadThongTinDatSan((int)btnKhungGio.Tag);
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

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
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

            dataGridViewDatSan.SelectionChanged += (s, e) =>
            {
                if (dataGridViewDatSan.SelectedRows.Count > 0)
                {
                    int maDatSan = Convert.ToInt32(dataGridViewDatSan.SelectedRows[0].Cells["MaDatSan"].Value);
                    LoadThongTinDatSan(maDatSan);
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

        private void LoadThongTinDatSan(int maDatSan)
        {
            selectedMaDatSan = maDatSan;
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT d.TongTien, d.NgayDat, d.GioBatDau, d.GioKetThuc, k.TenKH, d.TrangThaiThanhToan, s.TenSan
                    FROM DatSan d
                    JOIN KhachHang k ON d.MaKH = k.MaKH
                    JOIN SanBong s ON d.MaSan = s.MaSan
                    WHERE d.MaDatSan = @MaDatSan";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDatSan", maDatSan);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBoxNguoiDat.Text = reader["TenKH"].ToString();
                            textBoxTongTien.Text = reader["TongTien"].ToString();
                            selectedTenSan = reader["TenSan"].ToString();
                            selectedNgayDat = reader["NgayDat"].ToString();
                            selectedGioBatDau = reader["GioBatDau"].ToString();
                            selectedGioKetThuc = reader["GioKetThuc"].ToString();
                            int trangThaiThanhToan = reader.GetInt32(reader.GetOrdinal("TrangThaiThanhToan"));
                            buttonThanhToan.Enabled = (trangThaiThanhToan == 0);
                            buttonInHoaDon.Enabled = (trangThaiThanhToan == 0);

                            // Tạo mã QR
                            string qrUrl = $"https://img.vietqr.io/image/MB-446619999-print.png?amount={textBoxTongTien.Text}&addInfo=Thanh toan Vippro mart {Uri.EscapeDataString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"))}&accountName=NGUYEN%20NGOC%20KHANH";
                            using (WebClient client = new WebClient())
                            {
                                byte[] imageData = client.DownloadData(qrUrl);
                                using (var ms = new System.IO.MemoryStream(imageData))
                                {
                                    pictureBoxQRCode.Image = Image.FromStream(ms);
                                }
                            }
                        }
                    }
                }
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

            g.DrawString($"Mã đặt sân: {selectedMaDatSan}", font, Brushes.Black, new PointF(20, y));
            y += 30;
            g.DrawString($"Tên sân: {selectedTenSan}", font, Brushes.Black, new PointF(20, y));
            y += 30;
            g.DrawString($"Người đặt: {textBoxNguoiDat.Text}", font, Brushes.Black, new PointF(20, y));
            y += 30;
            g.DrawString($"Ngày đặt: {selectedNgayDat}", font, Brushes.Black, new PointF(20, y));
            y += 30;
            g.DrawString($"Khung giờ: {selectedGioBatDau} - {selectedGioKetThuc}", font, Brushes.Black, new PointF(20, y));
            y += 30;
            g.DrawString($"Tổng tiền: {textBoxTongTien.Text} VND", font, Brushes.Black, new PointF(20, y));
            y += 30;
            g.DrawString($"Phương thức thanh toán: {comboBoxPhuongThuc.SelectedItem}", font, Brushes.Black, new PointF(20, y));
            y += 30;
            g.DrawString($"Ngày in: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}", font, Brushes.Black, new PointF(20, y));
            y += 40;

            if (pictureBoxQRCode.Image != null)
            {
                // Sửa lỗi: Sử dụng DrawImage với Rectangle thay vì PointF và RectangleF
                g.DrawImage(pictureBoxQRCode.Image, new Rectangle(20, (int)y, 150, 150));
            }
        }

        private void buttonThanhToan_Click(object sender, EventArgs e)
        {
            if (selectedMaDatSan == -1)
            {
                MessageBox.Show("Vui lòng chọn một khung giờ đặt sân để thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(textBoxTongTien.Text) || Convert.ToInt32(textBoxTongTien.Text) <= 0)
            {
                MessageBox.Show("Tổng tiền không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string updateQuery = @"
                    UPDATE DatSan
                    SET TrangThaiThanhToan = 1
                    WHERE MaDatSan = @MaDatSan";
                using (SQLiteCommand updateCmd = new SQLiteCommand(updateQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@MaDatSan", selectedMaDatSan);
                    updateCmd.ExecuteNonQuery();
                }

                string insertQuery = @"
                    INSERT INTO LichSuThanhToan (MaDatSan, SoTien, NgayThanhToan, NoiDungChuyenKhoan)
                    VALUES (@MaDatSan, @SoTien, @NgayThanhToan, @NoiDungChuyenKhoan)";
                using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@MaDatSan", selectedMaDatSan);
                    insertCmd.Parameters.AddWithValue("@SoTien", Convert.ToDecimal(textBoxTongTien.Text));
                    insertCmd.Parameters.AddWithValue("@NgayThanhToan", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    insertCmd.Parameters.AddWithValue("@NoiDungChuyenKhoan", $"Thanh toán sân {selectedMaDatSan} bằng {comboBoxPhuongThuc.SelectedItem}");
                    insertCmd.ExecuteNonQuery();
                }
            }

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
    }
}
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySanBong
{
    public partial class DatSanControl : UserControl
    {
        private string connectionString = "Data Source=QuanLySanBong.db;Version=3;";

        public DatSanControl()
        {
            InitializeComponent();
            SetupTimePickers();
            LoadSanData();
            this.Resize += new EventHandler(DatSanControl_Resize);
        }

        private void DatSanControl_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            labelTitle.Width = width;

            panelThongTinDatSan.Location = new Point(20, 60);
            panelThongTinDatSan.Width = width - 40;
            panelThongTinDatSan.Height = height - 100;

            comboBoxSan.Width = panelThongTinDatSan.Width - 140;
            dateTimePickerNgayDat.Width = panelThongTinDatSan.Width - 140;
            dateTimePickerGioBatDau.Width = (panelThongTinDatSan.Width - 170) / 2;
            dateTimePickerGioKetThuc.Width = (panelThongTinDatSan.Width - 170) / 2;
            dateTimePickerGioKetThuc.Location = new Point(dateTimePickerGioBatDau.Right + 30, dateTimePickerGioBatDau.Location.Y);
            textBoxTenKH.Width = panelThongTinDatSan.Width - 140;
            textBoxSoDienThoai.Width = panelThongTinDatSan.Width - 140;

            buttonDatSan.Location = new Point((panelThongTinDatSan.Width - buttonDatSan.Width) / 2, panelThongTinDatSan.Height - 60);
        }

        private void SetupTimePickers()
        {
            // Thiết lập dateTimePickerGioBatDau
            dateTimePickerGioBatDau.Format = DateTimePickerFormat.Custom;
            dateTimePickerGioBatDau.CustomFormat = "HH:mm";
            dateTimePickerGioBatDau.ShowUpDown = true;
            dateTimePickerGioBatDau.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 6, 0, 0);

            // Thiết lập dateTimePickerGioKetThuc
            dateTimePickerGioKetThuc.Format = DateTimePickerFormat.Custom;
            dateTimePickerGioKetThuc.CustomFormat = "HH:mm";
            dateTimePickerGioKetThuc.ShowUpDown = true;
            dateTimePickerGioKetThuc.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
        }

        private void LoadSanData()
        {
            comboBoxSan.Items.Clear();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MaSan, TenSan FROM SanBong WHERE TrangThai = 'Hoạt động'";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int maSan = reader.GetInt32(reader.GetOrdinal("MaSan"));
                        string tenSan = reader.GetString(reader.GetOrdinal("TenSan"));
                        comboBoxSan.Items.Add(new { MaSan = maSan, TenSan = tenSan });
                    }
                }
            }

            comboBoxSan.DisplayMember = "TenSan";
            comboBoxSan.ValueMember = "MaSan";
            if (comboBoxSan.Items.Count > 0)
                comboBoxSan.SelectedIndex = 0;
        }

        private void buttonDatSan_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào
            if (comboBoxSan.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn sân bóng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(textBoxTenKH.Text) || string.IsNullOrEmpty(textBoxSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxSoDienThoai.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại phải có 10 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy giờ bắt đầu và giờ kết thúc từ DateTimePicker
            string gioBatDau = dateTimePickerGioBatDau.Value.ToString("HH:mm");
            string gioKetThuc = dateTimePickerGioKetThuc.Value.ToString("HH:mm");

            // Kiểm tra giờ kết thúc phải lớn hơn giờ bắt đầu
            TimeSpan timeBatDau = TimeSpan.Parse(gioBatDau);
            TimeSpan timeKetThuc = TimeSpan.Parse(gioKetThuc);
            if (timeKetThuc <= timeBatDau)
            {
                MessageBox.Show("Giờ kết thúc phải lớn hơn giờ bắt đầu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin đặt sân
            int maSan = (int)((dynamic)comboBoxSan.SelectedItem).MaSan;
            string ngayDat = dateTimePickerNgayDat.Value.ToString("yyyy-MM-dd");
            string tenKH = textBoxTenKH.Text;
            string soDienThoai = textBoxSoDienThoai.Text;

            // Kiểm tra khung giờ trùng lặp
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT COUNT(*) 
                    FROM DatSan 
                    WHERE MaSan = @MaSan 
                    AND NgayDat = @NgayDat 
                    AND (
                        (GioBatDau < @GioKetThuc AND GioKetThuc > @GioBatDau)
                    )";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSan", maSan);
                    cmd.Parameters.AddWithValue("@NgayDat", ngayDat);
                    cmd.Parameters.AddWithValue("@GioBatDau", gioBatDau);
                    cmd.Parameters.AddWithValue("@GioKetThuc", gioKetThuc);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Khung giờ này đã được đặt. Vui lòng chọn khung giờ khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Tính tổng tiền
                int giaThue = 0;
                string queryGiaThue = "SELECT GiaThue FROM SanBong WHERE MaSan = @MaSan";
                using (SQLiteCommand cmd = new SQLiteCommand(queryGiaThue, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSan", maSan);
                    giaThue = Convert.ToInt32(cmd.ExecuteScalar());
                }

                TimeSpan thoiGian = timeKetThuc - timeBatDau;
                int tongTien = (int)(thoiGian.TotalHours * giaThue);

                // Thêm khách hàng vào bảng KhachHang nếu chưa tồn tại
                int maKH;
                string queryKH = "SELECT MaKH FROM KhachHang WHERE SoDienThoai = @SoDienThoai";
                using (SQLiteCommand cmd = new SQLiteCommand(queryKH, conn))
                {
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        maKH = Convert.ToInt32(result);
                    }
                    else
                    {
                        string insertKH = "INSERT INTO KhachHang (TenKH, SoDienThoai) VALUES (@TenKH, @SoDienThoai); SELECT last_insert_rowid();";
                        using (SQLiteCommand insertCmd = new SQLiteCommand(insertKH, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@TenKH", tenKH);
                            insertCmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                            maKH = Convert.ToInt32(insertCmd.ExecuteScalar());
                        }
                    }
                }

                // Thêm thông tin đặt sân vào bảng DatSan
                string insertDatSan = @"
                    INSERT INTO DatSan (MaSan, MaKH, NgayDat, GioBatDau, GioKetThuc, TongTien, TrangThaiThanhToan, TrangThai)
                    VALUES (@MaSan, @MaKH, @NgayDat, @GioBatDau, @GioKetThuc, @TongTien, 0, 'Đã đặt')";
                using (SQLiteCommand insertCmd = new SQLiteCommand(insertDatSan, conn))
                {
                    insertCmd.Parameters.AddWithValue("@MaSan", maSan);
                    insertCmd.Parameters.AddWithValue("@MaKH", maKH);
                    insertCmd.Parameters.AddWithValue("@NgayDat", ngayDat);
                    insertCmd.Parameters.AddWithValue("@GioBatDau", gioBatDau);
                    insertCmd.Parameters.AddWithValue("@GioKetThuc", gioKetThuc);
                    insertCmd.Parameters.AddWithValue("@TongTien", tongTien);
                    insertCmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Đặt sân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearInputs();
        }

        private void ClearInputs()
        {
            if (comboBoxSan.Items.Count > 0)
                comboBoxSan.SelectedIndex = 0;
            dateTimePickerNgayDat.Value = DateTime.Now;
            dateTimePickerGioBatDau.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 6, 0, 0);
            dateTimePickerGioKetThuc.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
            textBoxTenKH.Text = "";
            textBoxSoDienThoai.Text = "";
        }
    }
}
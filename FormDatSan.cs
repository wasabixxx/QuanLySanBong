using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace QuanLySanBong
{
    public partial class FormDatSan : Form
    {
        private string connectionString = "Data Source=QuanLySanBong.db;Version=3;";
        private int selectedMaSan = -1;

        public FormDatSan()
        {
            InitializeComponent();
            LoadSanBong();
        }

        private void LoadSanBong()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MaSan, TenSan FROM SanBong";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbSanBong.Items.Add(new { MaSan = reader["MaSan"], TenSan = reader["TenSan"] });
                }
                conn.Close();

                cmbSanBong.DisplayMember = "TenSan";
                cmbSanBong.ValueMember = "MaSan";
            }
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            if (cmbSanBong.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn sân!");
                return;
            }

            selectedMaSan = (int)(cmbSanBong.SelectedItem as dynamic).MaSan;
            string ngayDat = dtpNgayDat.Value.ToString("yyyy-MM-dd");
            string gioBatDau = dtpGioBatDau.Value.ToString("HH:mm");
            string gioKetThuc = dtpGioKetThuc.Value.ToString("HH:mm");

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM DatSan WHERE MaSan = @MaSan AND NgayDat = @NgayDat " +
                              "AND ((GioBatDau <= @GioBatDau AND GioKetThuc > @GioBatDau) OR " +
                              "(GioBatDau < @GioKetThuc AND GioKetThuc >= @GioKetThuc))";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSan", selectedMaSan);
                cmd.Parameters.AddWithValue("@NgayDat", ngayDat);
                cmd.Parameters.AddWithValue("@GioBatDau", gioBatDau);
                cmd.Parameters.AddWithValue("@GioKetThuc", gioKetThuc);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();

                if (count > 0)
                {
                    MessageBox.Show("Sân đã được đặt trong khung giờ này!");
                }
                else
                {
                    MessageBox.Show("Sân trống, bạn có thể đặt!");
                }
            }
        }

        private void btnDatSan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenKH.Text) || string.IsNullOrEmpty(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin khách hàng!");
                return;
            }

            // Lấy giờ bắt đầu và giờ kết thúc từ DateTimePicker
            TimeSpan gioBatDau = dtpGioBatDau.Value.TimeOfDay;
            TimeSpan gioKetThuc = dtpGioKetThuc.Value.TimeOfDay;

            // Kiểm tra giờ kết thúc phải lớn hơn giờ bắt đầu
            if (gioKetThuc <= gioBatDau)
            {
                MessageBox.Show("Giờ kết thúc phải lớn hơn giờ bắt đầu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string queryKH = "INSERT INTO KhachHang (TenKH, SoDienThoai) VALUES (@TenKH, @SoDienThoai); SELECT last_insert_rowid();";
                SQLiteCommand cmdKH = new SQLiteCommand(queryKH, conn);
                cmdKH.Parameters.AddWithValue("@TenKH", txtTenKH.Text);
                cmdKH.Parameters.AddWithValue("@SoDienThoai", txtSoDienThoai.Text);
                int maKH = Convert.ToInt32(cmdKH.ExecuteScalar());

                int giaThue = 0;
                string queryGia = "SELECT GiaThue FROM SanBong WHERE MaSan = @MaSan";
                SQLiteCommand cmdGia = new SQLiteCommand(queryGia, conn);
                cmdGia.Parameters.AddWithValue("@MaSan", selectedMaSan);
                giaThue = Convert.ToInt32(cmdGia.ExecuteScalar());

                // Tính thời gian (giờ kết thúc - giờ bắt đầu)
                TimeSpan thoiGian = gioKetThuc - gioBatDau;

                // Tính tổng tiền (giữ thuật toán cũ)
                decimal tongTien = (decimal)(thoiGian.TotalHours * giaThue);

                string queryDatSan = "INSERT INTO DatSan (MaSan, MaKH, NgayDat, GioBatDau, GioKetThuc, TongTien, TrangThaiThanhToan) " +
                                    "VALUES (@MaSan, @MaKH, @NgayDat, @GioBatDau, @GioKetThuc, @TongTien, 0); SELECT last_insert_rowid();";
                SQLiteCommand cmdDatSan = new SQLiteCommand(queryDatSan, conn);
                cmdDatSan.Parameters.AddWithValue("@MaSan", selectedMaSan);
                cmdDatSan.Parameters.AddWithValue("@MaKH", maKH);
                cmdDatSan.Parameters.AddWithValue("@NgayDat", dtpNgayDat.Value.ToString("yyyy-MM-dd"));
                cmdDatSan.Parameters.AddWithValue("@GioBatDau", dtpGioBatDau.Value.ToString("HH:mm"));
                cmdDatSan.Parameters.AddWithValue("@GioKetThuc", dtpGioKetThuc.Value.ToString("HH:mm"));
                cmdDatSan.Parameters.AddWithValue("@TongTien", tongTien);
                int maDatSan = Convert.ToInt32(cmdDatSan.ExecuteScalar());

                conn.Close();
            }

            MessageBox.Show("Đặt sân thành công! Vui lòng vào tab Thanh toán để thanh toán.");
            ClearInputs();
        }

        private void ClearInputs()
        {
            cmbSanBong.SelectedIndex = -1;
            txtTenKH.Clear();
            txtSoDienThoai.Clear();
        }
    }
}
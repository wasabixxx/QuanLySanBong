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
            LoadSanBong(); // Load danh sách sân vào ComboBox
        }

        // Load danh sách sân vào ComboBox
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

        // Kiểm tra lịch trống
        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            if (cmbSanBong.SelectedItem == null || string.IsNullOrEmpty(txtGioBatDau.Text) || string.IsNullOrEmpty(txtGioKetThuc.Text))
            {
                MessageBox.Show("Vui lòng chọn sân và nhập giờ bắt đầu/kết thúc!");
                return;
            }

            selectedMaSan = (int)(cmbSanBong.SelectedItem as dynamic).MaSan;
            string ngayDat = dtpNgayDat.Value.ToString("yyyy-MM-dd");
            string gioBatDau = txtGioBatDau.Text;
            string gioKetThuc = txtGioKetThuc.Text;

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

        // Đặt sân
        private void btnDatSan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenKH.Text) || string.IsNullOrEmpty(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin khách hàng!");
                return;
            }

            // Thêm khách hàng vào bảng KhachHang
            int maKH;
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string queryKH = "INSERT INTO KhachHang (TenKH, SoDienThoai) VALUES (@TenKH, @SoDienThoai); SELECT last_insert_rowid();";
                SQLiteCommand cmdKH = new SQLiteCommand(queryKH, conn);
                cmdKH.Parameters.AddWithValue("@TenKH", txtTenKH.Text);
                cmdKH.Parameters.AddWithValue("@SoDienThoai", txtSoDienThoai.Text);
                maKH = Convert.ToInt32(cmdKH.ExecuteScalar());

                // Tính tổng tiền
                int giaThue = 0;
                string queryGia = "SELECT GiaThue FROM SanBong WHERE MaSan = @MaSan";
                SQLiteCommand cmdGia = new SQLiteCommand(queryGia, conn);
                cmdGia.Parameters.AddWithValue("@MaSan", selectedMaSan);
                giaThue = Convert.ToInt32(cmdGia.ExecuteScalar());

                TimeSpan thoiGian = TimeSpan.Parse(txtGioKetThuc.Text) - TimeSpan.Parse(txtGioBatDau.Text);
                int tongTien = (int)(thoiGian.TotalHours * giaThue);

                // Thêm lịch đặt sân
                string queryDatSan = "INSERT INTO DatSan (MaSan, MaKH, NgayDat, GioBatDau, GioKetThuc, TongTien) " +
                                    "VALUES (@MaSan, @MaKH, @NgayDat, @GioBatDau, @GioKetThuc, @TongTien)";
                SQLiteCommand cmdDatSan = new SQLiteCommand(queryDatSan, conn);
                cmdDatSan.Parameters.AddWithValue("@MaSan", selectedMaSan);
                cmdDatSan.Parameters.AddWithValue("@MaKH", maKH);
                cmdDatSan.Parameters.AddWithValue("@NgayDat", dtpNgayDat.Value.ToString("yyyy-MM-dd"));
                cmdDatSan.Parameters.AddWithValue("@GioBatDau", txtGioBatDau.Text);
                cmdDatSan.Parameters.AddWithValue("@GioKetThuc", txtGioKetThuc.Text);
                cmdDatSan.Parameters.AddWithValue("@TongTien", tongTien);
                cmdDatSan.ExecuteNonQuery();

                conn.Close();
            }

            MessageBox.Show("Đặt sân thành công!");
            ClearInputs();
        }

        private void ClearInputs()
        {
            cmbSanBong.SelectedIndex = -1;
            txtGioBatDau.Clear();
            txtGioKetThuc.Clear();
            txtTenKH.Clear();
            txtSoDienThoai.Clear();
        }
    }
}
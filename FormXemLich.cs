using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace QuanLySanBong
{
    public partial class FormXemLich : Form
    {
        private string connectionString = "Data Source=QuanLySanBong.db;Version=3;";

        public FormXemLich()
        {
            InitializeComponent();
        }

        // Xem lịch khi chọn ngày
        private void btnXemLich_Click(object sender, EventArgs e)
        {
            string ngayDat = dtpNgayXem.Value.ToString("yyyy-MM-dd");

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT DatSan.MaDatSan, SanBong.TenSan, KhachHang.TenKH, KhachHang.SoDienThoai, 
                                DatSan.NgayDat, DatSan.GioBatDau, DatSan.GioKetThuc, DatSan.TongTien 
                                FROM DatSan 
                                JOIN SanBong ON DatSan.MaSan = SanBong.MaSan 
                                JOIN KhachHang ON DatSan.MaKH = KhachHang.MaKH 
                                WHERE DatSan.NgayDat = @NgayDat";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@NgayDat", ngayDat);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                dgvLichDat.DataSource = dt;

                conn.Close();
            }
        }
    }
}
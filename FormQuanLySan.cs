using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace QuanLySanBong
{
    public partial class FormQuanLySan : Form
    {
        private string connectionString = "Data Source=QuanLySanBong.db;Version=3;";
        private int selectedMaSan = -1; // Lưu MaSan của sân được chọn

        public FormQuanLySan()
        {
            InitializeComponent();
            LoadSanBong(); // Load danh sách sân khi form mở
        }

        // Load danh sách sân vào DataGridView
        private void LoadSanBong()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM SanBong";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
                System.Data.DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                dgvSanBong.DataSource = dt;
                conn.Close();
            }
        }

        // Thêm sân mới
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenSan.Text) || string.IsNullOrEmpty(txtLoaiSan.Text) || string.IsNullOrEmpty(txtGiaThue.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO SanBong (TenSan, LoaiSan, GiaThue) VALUES (@TenSan, @LoaiSan, @GiaThue)";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenSan", txtTenSan.Text);
                cmd.Parameters.AddWithValue("@LoaiSan", txtLoaiSan.Text);
                cmd.Parameters.AddWithValue("@GiaThue", int.Parse(txtGiaThue.Text));
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            MessageBox.Show("Thêm sân thành công!");
            LoadSanBong(); // Refresh danh sách
            ClearInputs();
        }

        // Sửa sân
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedMaSan == -1)
            {
                MessageBox.Show("Vui lòng chọn sân để sửa!");
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE SanBong SET TenSan = @TenSan, LoaiSan = @LoaiSan, GiaThue = @GiaThue WHERE MaSan = @MaSan";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenSan", txtTenSan.Text);
                cmd.Parameters.AddWithValue("@LoaiSan", txtLoaiSan.Text);
                cmd.Parameters.AddWithValue("@GiaThue", int.Parse(txtGiaThue.Text));
                cmd.Parameters.AddWithValue("@MaSan", selectedMaSan);
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            MessageBox.Show("Sửa sân thành công!");
            LoadSanBong();
            ClearInputs();
        }

        // Xóa sân
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedMaSan == -1)
            {
                MessageBox.Show("Vui lòng chọn sân để xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa sân này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM SanBong WHERE MaSan = @MaSan";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaSan", selectedMaSan);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Xóa sân thành công!");
                LoadSanBong();
                ClearInputs();
            }
        }

        // Khi click vào DataGridView, điền thông tin sân vào các TextBox
        private void dgvSanBong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanBong.Rows[e.RowIndex];
                selectedMaSan = Convert.ToInt32(row.Cells["MaSan"].Value);
                txtTenSan.Text = row.Cells["TenSan"].Value.ToString();
                txtLoaiSan.Text = row.Cells["LoaiSan"].Value.ToString();
                txtGiaThue.Text = row.Cells["GiaThue"].Value.ToString();
            }
        }

        // Xóa trắng các TextBox
        private void ClearInputs()
        {
            txtTenSan.Clear();
            txtLoaiSan.Clear();
            txtGiaThue.Clear();
            selectedMaSan = -1;
        }
    }
}
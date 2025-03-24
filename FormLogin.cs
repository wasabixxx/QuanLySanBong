using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace QuanLySanBong
{
    public partial class FormLogin : Form
    {
        private string connectionString = "Data Source=QuanLySanBong.db;Version=3;";

        public FormLogin()
        {
            InitializeComponent();
            CreateUserTable(); // Tạo bảng Users nếu chưa có
            InsertDefaultUser(); // Thêm tài khoản mặc định nếu chưa có
        }

        // Tạo bảng Users để lưu thông tin đăng nhập
        private void CreateUserTable()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"CREATE TABLE IF NOT EXISTS Users (
                    Username TEXT PRIMARY KEY,
                    Password TEXT NOT NULL
                )";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        // Thêm tài khoản mặc định (admin/12345) nếu chưa có
        private void InsertDefaultUser()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string checkUser = "SELECT COUNT(*) FROM Users WHERE Username = 'admin'";
                SQLiteCommand checkCmd = new SQLiteCommand(checkUser, conn);
                long userCount = (long)checkCmd.ExecuteScalar();

                if (userCount == 0)
                {
                    string insertUser = "INSERT INTO Users (Username, Password) VALUES ('admin', '12345')";
                    SQLiteCommand insertCmd = new SQLiteCommand(insertUser, conn);
                    insertCmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        // Xử lý sự kiện nút Đăng nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                long count = (long)cmd.ExecuteScalar();
                conn.Close();

                if (count > 0)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormMain formMain = new FormMain();
                    formMain.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Xử lý sự kiện nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
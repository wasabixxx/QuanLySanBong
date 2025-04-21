using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySanBong
{
    public partial class QuanLySanControl : UserControl
    {
        private string connectionString = "Data Source=QuanLySanBong.db;Version=3;";
        private int selectedMaSan = -1;

        public QuanLySanControl()
        {
            InitializeComponent();
            SetupDataGridView();
            SetupComboBoxTrangThai();
            LoadSanData();
            this.Resize += new EventHandler(QuanLySanControl_Resize);
        }

        private void QuanLySanControl_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            labelTitle.Width = width;

            dataGridViewSan.Location = new Point(20, 60);
            dataGridViewSan.Width = width - 40;
            dataGridViewSan.Height = (height - 100) / 2;

            panelThongTinSan.Location = new Point(20, dataGridViewSan.Bottom + 10);
            panelThongTinSan.Width = width - 40;
            panelThongTinSan.Height = (height - 100) / 2 - 20;

            textBoxTenSan.Width = panelThongTinSan.Width - 140;
            textBoxGiaThue.Width = panelThongTinSan.Width - 140;
            comboBoxTrangThai.Width = panelThongTinSan.Width - 140;
        }

        private void SetupDataGridView()
        {
            dataGridViewSan.Columns.Clear();
            dataGridViewSan.Columns.Add("MaSan", "Mã sân");
            dataGridViewSan.Columns.Add("TenSan", "Tên sân");
            dataGridViewSan.Columns.Add("GiaThue", "Giá thuê (VND/giờ)");
            dataGridViewSan.Columns.Add("TrangThai", "Trạng thái");

            // Tùy chỉnh giao diện DataGridView
            dataGridViewSan.BackgroundColor = Color.White;
            dataGridViewSan.BorderStyle = BorderStyle.FixedSingle;
            dataGridViewSan.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewSan.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215); // Màu xanh dương khi chọn
            dataGridViewSan.DefaultCellStyle.SelectionForeColor = Color.White;

            // Tùy chỉnh tiêu đề cột
            dataGridViewSan.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 150, 0); // Màu xanh lá cây
            dataGridViewSan.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewSan.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridViewSan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSan.EnableHeadersVisualStyles = false;

            // Tùy chỉnh nội dung cột
            dataGridViewSan.DefaultCellStyle.Font = new Font("Arial", 10);
            dataGridViewSan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Điều chỉnh chiều rộng cột
            dataGridViewSan.Columns["MaSan"].Width = 80;
            dataGridViewSan.Columns["TenSan"].Width = 200;
            dataGridViewSan.Columns["GiaThue"].Width = 150;
            dataGridViewSan.Columns["TrangThai"].Width = 120;
        }

        private void SetupComboBoxTrangThai()
        {
            comboBoxTrangThai.Items.Clear();
            comboBoxTrangThai.Items.Add("Hoạt động");
            comboBoxTrangThai.Items.Add("Bảo trì");
            comboBoxTrangThai.SelectedIndex = 0;
        }

        private void LoadSanData()
        {
            dataGridViewSan.Rows.Clear();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MaSan, TenSan, GiaThue, TrangThai FROM SanBong";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    int rowIndex = 0;
                    while (reader.Read())
                    {
                        int maSan = reader.GetInt32(reader.GetOrdinal("MaSan"));
                        string tenSan = reader.IsDBNull(reader.GetOrdinal("TenSan")) ? "" : reader.GetString(reader.GetOrdinal("TenSan"));
                        int giaThue = reader.IsDBNull(reader.GetOrdinal("GiaThue")) ? 0 : reader.GetInt32(reader.GetOrdinal("GiaThue"));
                        string trangThai = reader.IsDBNull(reader.GetOrdinal("TrangThai")) ? "Hoạt động" : reader.GetString(reader.GetOrdinal("TrangThai"));

                        int rowIdx = dataGridViewSan.Rows.Add(maSan, tenSan, giaThue, trangThai);

                        // Tùy chỉnh màu nền hàng
                        DataGridViewRow row = dataGridViewSan.Rows[rowIdx];
                        row.DefaultCellStyle.BackColor = rowIndex % 2 == 0 ? Color.White : Color.FromArgb(240, 240, 240); // Xen kẽ trắng và xám nhạt

                        // Tùy chỉnh màu nền dựa trên trạng thái
                        if (trangThai == "Hoạt động")
                            row.DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200); // Xanh nhạt
                        else if (trangThai == "Bảo trì")
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200); // Vàng nhạt

                        rowIndex++;
                    }
                }
            }

            // Gán sự kiện SelectionChanged sau khi dữ liệu được tải
            dataGridViewSan.SelectionChanged -= DataGridViewSan_SelectionChanged;
            dataGridViewSan.SelectionChanged += DataGridViewSan_SelectionChanged;
        }

        private void DataGridViewSan_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewSan.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewSan.SelectedRows[0];
                if (selectedRow.Cells["MaSan"].Value != null &&
                    selectedRow.Cells["TenSan"].Value != null &&
                    selectedRow.Cells["GiaThue"].Value != null &&
                    selectedRow.Cells["TrangThai"].Value != null)
                {
                    selectedMaSan = Convert.ToInt32(selectedRow.Cells["MaSan"].Value);
                    textBoxTenSan.Text = selectedRow.Cells["TenSan"].Value.ToString();
                    textBoxGiaThue.Text = selectedRow.Cells["GiaThue"].Value.ToString();
                    comboBoxTrangThai.SelectedItem = selectedRow.Cells["TrangThai"].Value.ToString();
                }
            }
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTenSan.Text) || string.IsNullOrEmpty(textBoxGiaThue.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBoxGiaThue.Text, out int giaThue) || giaThue <= 0)
            {
                MessageBox.Show("Giá thuê phải là một số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    INSERT INTO SanBong (TenSan, GiaThue, TrangThai)
                    VALUES (@TenSan, @GiaThue, @TrangThai)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenSan", textBoxTenSan.Text);
                    cmd.Parameters.AddWithValue("@GiaThue", giaThue);
                    cmd.Parameters.AddWithValue("@TrangThai", comboBoxTrangThai.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Thêm sân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadSanData();
            ClearInputs();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (selectedMaSan == -1)
            {
                MessageBox.Show("Vui lòng chọn một sân để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(textBoxTenSan.Text) || string.IsNullOrEmpty(textBoxGiaThue.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBoxGiaThue.Text, out int giaThue) || giaThue <= 0)
            {
                MessageBox.Show("Giá thuê phải là một số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    UPDATE SanBong
                    SET TenSan = @TenSan, GiaThue = @GiaThue, TrangThai = @TrangThai
                    WHERE MaSan = @MaSan";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenSan", textBoxTenSan.Text);
                    cmd.Parameters.AddWithValue("@GiaThue", giaThue);
                    cmd.Parameters.AddWithValue("@TrangThai", comboBoxTrangThai.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@MaSan", selectedMaSan);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Sửa sân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadSanData();
            ClearInputs();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (selectedMaSan == -1)
            {
                MessageBox.Show("Vui lòng chọn một sân để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sân này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM SanBong WHERE MaSan = @MaSan";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSan", selectedMaSan);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Xóa sân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadSanData();
            ClearInputs();
        }

        private void ClearInputs()
        {
            selectedMaSan = -1;
            textBoxTenSan.Text = "";
            textBoxGiaThue.Text = "";
            comboBoxTrangThai.SelectedIndex = 0;
        }
    }
}
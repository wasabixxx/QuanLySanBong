using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySanBong
{
    public partial class XemLichControl : UserControl
    {
        private string connectionString = "Data Source=QuanLySanBong.db;Version=3;";
        private int selectedMaDatSan = -1;

        public XemLichControl()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadSanData();
            this.Resize += new EventHandler(XemLichControl_Resize);
        }

        private void XemLichControl_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            labelTitle.Width = width;

            panelLocLich.Location = new Point(20, 60);
            panelLocLich.Width = width - 40;

            comboBoxSan.Width = (panelLocLich.Width - 340) / 2;
            dateTimePickerNgayXem.Width = (panelLocLich.Width - 340) / 2;
            dateTimePickerNgayXem.Location = new Point(comboBoxSan.Right + 30, comboBoxSan.Location.Y);
            buttonXemLich.Location = new Point(dateTimePickerNgayXem.Right + 30, dateTimePickerNgayXem.Location.Y);

            dataGridViewLichDat.Location = new Point(20, panelLocLich.Bottom + 10);
            dataGridViewLichDat.Width = width - 40;
            dataGridViewLichDat.Height = height - panelLocLich.Height - 110;

            buttonHuyDat.Location = new Point(dataGridViewLichDat.Right - buttonHuyDat.Width, dataGridViewLichDat.Bottom + 10);
        }

        private void SetupDataGridView()
        {
            dataGridViewLichDat.Columns.Clear();
            dataGridViewLichDat.Columns.Add("MaDatSan", "Mã đặt sân");
            dataGridViewLichDat.Columns.Add("TenSan", "Tên sân");
            dataGridViewLichDat.Columns.Add("TenKH", "Tên khách hàng");
            dataGridViewLichDat.Columns.Add("SoDienThoai", "Số điện thoại");
            dataGridViewLichDat.Columns.Add("GioBatDau", "Giờ bắt đầu");
            dataGridViewLichDat.Columns.Add("GioKetThuc", "Giờ kết thúc");
            dataGridViewLichDat.Columns.Add("TongTien", "Tổng tiền (VND)");
            dataGridViewLichDat.Columns.Add("TrangThaiThanhToan", "Trạng thái thanh toán");
            dataGridViewLichDat.Columns.Add("TrangThai", "Trạng thái");

            // Tùy chỉnh giao diện DataGridView
            dataGridViewLichDat.BackgroundColor = Color.White;
            dataGridViewLichDat.BorderStyle = BorderStyle.FixedSingle;
            dataGridViewLichDat.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewLichDat.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215); // Màu xanh dương khi chọn
            dataGridViewLichDat.DefaultCellStyle.SelectionForeColor = Color.White;

            // Tùy chỉnh tiêu đề cột
            dataGridViewLichDat.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 150, 0); // Màu xanh lá cây
            dataGridViewLichDat.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewLichDat.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridViewLichDat.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewLichDat.EnableHeadersVisualStyles = false;

            // Tùy chỉnh nội dung cột
            dataGridViewLichDat.DefaultCellStyle.Font = new Font("Arial", 10);
            dataGridViewLichDat.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Điều chỉnh chiều rộng cột
            dataGridViewLichDat.Columns["MaDatSan"].Width = 80;
            dataGridViewLichDat.Columns["TenSan"].Width = 120;
            dataGridViewLichDat.Columns["TenKH"].Width = 150;
            dataGridViewLichDat.Columns["SoDienThoai"].Width = 120;
            dataGridViewLichDat.Columns["GioBatDau"].Width = 100;
            dataGridViewLichDat.Columns["GioKetThuc"].Width = 100;
            dataGridViewLichDat.Columns["TongTien"].Width = 120;
            dataGridViewLichDat.Columns["TrangThaiThanhToan"].Width = 150;
            dataGridViewLichDat.Columns["TrangThai"].Width = 100;
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

        private void buttonXemLich_Click(object sender, EventArgs e)
        {
            if (comboBoxSan.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn sân bóng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maSan = (int)((dynamic)comboBoxSan.SelectedItem).MaSan;
            string ngayXem = dateTimePickerNgayXem.Value.ToString("yyyy-MM-dd");

            LoadLichDat(maSan, ngayXem);
        }

        private void LoadLichDat(int maSan, string ngayXem)
        {
            dataGridViewLichDat.Rows.Clear();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT ds.MaDatSan, sb.TenSan, kh.TenKH, kh.SoDienThoai, 
                           ds.GioBatDau, ds.GioKetThuc, ds.TongTien, 
                           ds.TrangThaiThanhToan, ds.TrangThai
                    FROM DatSan ds
                    JOIN SanBong sb ON ds.MaSan = sb.MaSan
                    JOIN KhachHang kh ON ds.MaKH = kh.MaKH
                    WHERE ds.MaSan = @MaSan AND ds.NgayDat = @NgayDat";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSan", maSan);
                    cmd.Parameters.AddWithValue("@NgayDat", ngayXem);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        int rowIndex = 0;
                        while (reader.Read())
                        {
                            int maDatSan = reader.GetInt32(reader.GetOrdinal("MaDatSan"));
                            string tenSan = reader.GetString(reader.GetOrdinal("TenSan"));
                            string tenKH = reader.GetString(reader.GetOrdinal("TenKH"));
                            string soDienThoai = reader.GetString(reader.GetOrdinal("SoDienThoai"));
                            string gioBatDau = reader.GetString(reader.GetOrdinal("GioBatDau"));
                            string gioKetThuc = reader.GetString(reader.GetOrdinal("GioKetThuc"));
                            int tongTien = reader.GetInt32(reader.GetOrdinal("TongTien"));
                            int trangThaiThanhToan = reader.GetInt32(reader.GetOrdinal("TrangThaiThanhToan"));
                            string trangThai = reader.GetString(reader.GetOrdinal("TrangThai"));

                            string trangThaiThanhToanText = trangThaiThanhToan == 0 ? "Chưa thanh toán" : "Đã thanh toán";

                            int rowIdx = dataGridViewLichDat.Rows.Add(
                                maDatSan, tenSan, tenKH, soDienThoai, gioBatDau, gioKetThuc,
                                tongTien, trangThaiThanhToanText, trangThai);

                            // Tùy chỉnh màu nền hàng
                            DataGridViewRow row = dataGridViewLichDat.Rows[rowIdx];
                            row.DefaultCellStyle.BackColor = rowIndex % 2 == 0 ? Color.White : Color.FromArgb(240, 240, 240); // Xen kẽ trắng và xám nhạt

                            // Tùy chỉnh màu nền dựa trên trạng thái thanh toán
                            if (trangThaiThanhToan == 0)
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200); // Đỏ nhạt
                            else
                                row.DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200); // Xanh nhạt

                            rowIndex++;
                        }
                    }
                }
            }

            // Gán sự kiện SelectionChanged
            dataGridViewLichDat.SelectionChanged -= DataGridViewLichDat_SelectionChanged;
            dataGridViewLichDat.SelectionChanged += DataGridViewLichDat_SelectionChanged;
        }

        private void DataGridViewLichDat_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewLichDat.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewLichDat.SelectedRows[0];
                if (selectedRow.Cells["MaDatSan"].Value != null)
                {
                    selectedMaDatSan = Convert.ToInt32(selectedRow.Cells["MaDatSan"].Value);
                }
            }
        }

        private void buttonHuyDat_Click(object sender, EventArgs e)
        {
            if (selectedMaDatSan == -1)
            {
                MessageBox.Show("Vui lòng chọn một lịch đặt để hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy lịch đặt này?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE DatSan SET TrangThai = 'Đã hủy' WHERE MaDatSan = @MaDatSan";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDatSan", selectedMaDatSan);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Hủy lịch đặt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Tải lại danh sách lịch đặt
            if (comboBoxSan.SelectedItem != null)
            {
                int maSan = (int)((dynamic)comboBoxSan.SelectedItem).MaSan;
                string ngayXem = dateTimePickerNgayXem.Value.ToString("yyyy-MM-dd");
                LoadLichDat(maSan, ngayXem);
            }

            selectedMaDatSan = -1;
        }
    }
}
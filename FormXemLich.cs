using System;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySanBong
{
    public partial class FormXemLich : Form
    {
        private readonly string connectionString = "Data Source=QuanLySanBong.db;Version=3;";

        public FormXemLich()
        {
            InitializeComponent();
            dtpNgayXem.Value = DateTime.Today; // Đặt ngày mặc định là hôm nay
            LoadLichDatSanAsync(); // Tải danh sách lịch đặt sân khi mở form
        }

        // Tải danh sách lịch đặt sân (bất đồng bộ), trả về Task
        private async Task LoadLichDatSanAsync()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();
                    // Lọc theo ngày được chọn trong DateTimePicker
                    string selectedDate = dtpNgayXem.Value.ToString("yyyy-MM-dd");
                    string query = @"
                        SELECT ds.MaDatSan, sb.TenSan, ds.NgayDat, ds.GioBatDau, ds.GioKetThuc, ds.TongTien, ds.TrangThai
                        FROM DatSan ds
                        JOIN SanBong sb ON ds.MaSan = sb.MaSan
                        WHERE ds.NgayDat = @NgayDat";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NgayDat", selectedDate);

                    using (SQLiteDataReader reader = (SQLiteDataReader)await cmd.ExecuteReaderAsync())
                    {
                        // Tạo các cột cho DataGridView
                        dgvLichDatSan.Columns.Clear();
                        dgvLichDatSan.Columns.Add("MaDatSan", "Mã đặt sân");
                        dgvLichDatSan.Columns.Add("TenSan", "Tên sân");
                        dgvLichDatSan.Columns.Add("NgayDat", "Ngày đặt");
                        dgvLichDatSan.Columns.Add("Gio", "Giờ");
                        dgvLichDatSan.Columns.Add("TongTien", "Tổng tiền");
                        dgvLichDatSan.Columns.Add("TrangThai", "Trạng thái");

                        // Đặt kích thước cột
                        dgvLichDatSan.Columns["MaDatSan"].Width = 100;
                        dgvLichDatSan.Columns["TenSan"].Width = 120;
                        dgvLichDatSan.Columns["NgayDat"].Width = 100;
                        dgvLichDatSan.Columns["Gio"].Width = 120;
                        dgvLichDatSan.Columns["TongTien"].Width = 100;
                        dgvLichDatSan.Columns["TrangThai"].Width = 120;

                        // Thêm dữ liệu vào DataGridView
                        while (await reader.ReadAsync())
                        {
                            string maDatSan = $"DS{reader["MaDatSan"]:D3}";
                            string tenSan = reader["TenSan"].ToString();
                            string ngayDat = reader["NgayDat"].ToString();
                            string gio = $"{reader["GioBatDau"]} - {reader["GioKetThuc"]}";
                            string trangThai = reader["TrangThai"].ToString();
                            string tongTienDisplay = trangThai == "Đã hủy" ? "Đã hủy" : Convert.ToDecimal(reader["TongTien"]).ToString("N0") + " VNĐ";

                            dgvLichDatSan.Rows.Add(maDatSan, tenSan, ngayDat, gio, tongTienDisplay, trangThai);
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lịch đặt sân: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý khi thay đổi ngày trong DateTimePicker
        private async void dtpNgayXem_ValueChanged(object sender, EventArgs e)
        {
            await LoadLichDatSanAsync(); // Tải lại danh sách khi ngày thay đổi
        }

        // Xử lý khi nhấn nút "Hủy lịch"
        private async void btnHuyLich_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (dgvLichDatSan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lịch đặt sân để hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã đặt sân và trạng thái từ dòng được chọn
            string maDatSan = dgvLichDatSan.SelectedRows[0].Cells["MaDatSan"].Value.ToString();
            string trangThai = dgvLichDatSan.SelectedRows[0].Cells["TrangThai"].Value.ToString();
            int maDatSanId = int.Parse(maDatSan.Replace("DS", ""));

            // Kiểm tra nếu lịch đã hủy hoặc đã thanh toán
            if (trangThai == "Đã hủy")
            {
                MessageBox.Show("Lịch này đã được hủy trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (trangThai == "Đã thanh toán")
            {
                MessageBox.Show("Không thể hủy lịch đã thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận trước khi hủy
            if (MessageBox.Show($"Bạn có chắc muốn hủy lịch đặt sân {maDatSan}?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    // Cập nhật trạng thái thành "Đã hủy"
                    string updateQuery = "UPDATE DatSan SET TrangThai = 'Đã hủy' WHERE MaDatSan = @MaDatSan";
                    SQLiteCommand updateCmd = new SQLiteCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@MaDatSan", maDatSanId);
                    await updateCmd.ExecuteNonQueryAsync();

                    conn.Close();
                }

                // Tải lại danh sách lịch đặt sân
                await LoadLichDatSanAsync();
                MessageBox.Show("Hủy lịch đặt sân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hủy lịch đặt sân: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
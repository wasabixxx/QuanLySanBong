using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace QuanLySanBong
{
    public partial class FormThanhToan : Form
    {
        private string maDatSan; // Mã đặt sân
        private decimal totalBill; // Tổng tiền cần thanh toán
        private string qrUrl; // URL của mã QR
        private readonly string sepayApiToken = "your_api_token_here"; // Thay bằng API Token thực tế từ SePay
        private readonly string sepayUsername = "your_username_here"; // Thay bằng username thực tế từ SePay
        private readonly string connectionString = "Data Source=QuanLySanBong.db;Version=3;";

        public FormThanhToan()
        {
            InitializeComponent();
            CreateLichSuThanhToanTable(); // Tạo bảng lịch sử thanh toán nếu chưa có
            LoadDatSanChuaThanhToanAsync(); // Tải danh sách bất đồng bộ
        }

        // Tạo bảng LichSuThanhToan nếu chưa có
        private void CreateLichSuThanhToanTable()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"CREATE TABLE IF NOT EXISTS LichSuThanhToan (
                    MaThanhToan INTEGER PRIMARY KEY AUTOINCREMENT,
                    MaDatSan TEXT NOT NULL,
                    SoTien DECIMAL NOT NULL,
                    NgayThanhToan TEXT NOT NULL,
                    NoiDungChuyenKhoan TEXT NOT NULL
                )";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        // Tải danh sách lịch đặt sân chưa thanh toán (bất đồng bộ)
        private async void LoadDatSanChuaThanhToanAsync()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = @"
                        SELECT ds.MaDatSan, ds.TongTien, sb.TenSan, ds.NgayDat, ds.GioBatDau, ds.GioKetThuc
                        FROM DatSan ds
                        JOIN SanBong sb ON ds.MaSan = sb.MaSan
                        WHERE ds.TrangThaiThanhToan = 0";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    // Ép kiểu từ DbDataReader sang SQLiteDataReader
                    using (SQLiteDataReader reader = (SQLiteDataReader)await cmd.ExecuteReaderAsync())
                    {
                        cmbDatSan.Items.Clear();
                        while (await reader.ReadAsync())
                        {
                            string maDatSan = $"DS{reader["MaDatSan"]:D3}";
                            string tenSan = reader["TenSan"].ToString();
                            string ngayDat = reader["NgayDat"].ToString();
                            string gio = $"{reader["GioBatDau"]} - {reader["GioKetThuc"]}";
                            decimal tongTien = Convert.ToDecimal(reader["TongTien"]);
                            string displayText = $"{maDatSan} - {tenSan} ({ngayDat}, {gio}) - {tongTien} VNĐ";

                            cmbDatSan.Items.Add(new
                            {
                                MaDatSan = maDatSan,
                                TongTien = tongTien,
                                DisplayText = displayText
                            });
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách lịch đặt sân: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Khi chọn lịch đặt sân, tạo mã QR
        private void cmbDatSan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDatSan.SelectedItem == null)
            {
                picQRCode.Image = null;
                lblQRInfo.Text = "Vui lòng chọn lịch đặt sân để thanh toán.";
                return;
            }

            var selectedItem = cmbDatSan.SelectedItem as dynamic;
            maDatSan = selectedItem.MaDatSan;
            totalBill = selectedItem.TongTien;

            GenerateQRCode();
        }

        // Tạo mã QR bằng VietQR API
        private void GenerateQRCode()
        {
            string bankId = "MB"; // Mã ngân hàng (MB Bank)
            string accountNo = "446619999"; // Số tài khoản
            string template = "print"; // Template của VietQR
            string accountName = "NGUYEN NGOC KHANH"; // Tên tài khoản
            string addInfo = $"Thanh toan san bong {maDatSan}"; // Nội dung chuyển khoản
            string encodedAddInfo = Uri.EscapeDataString(addInfo);
            string encodedAccountName = Uri.EscapeDataString(accountName);

            qrUrl = $"https://img.vietqr.io/image/{bankId}-{accountNo}-{template}.png?amount={totalBill}&addInfo={encodedAddInfo}&accountName={encodedAccountName}";
            picQRCode.ImageLocation = qrUrl;
            lblQRInfo.Text = $"Quét mã QR để thanh toán {totalBill} VNĐ\nNội dung: {addInfo}";
        }

        // Kiểm tra giao dịch khi nhấn nút "Kiểm tra"
        private async void btnKiemTra_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maDatSan) || totalBill == 0)
            {
                MessageBox.Show("Vui lòng chọn lịch đặt sân để kiểm tra thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string expectedContent = $"Thanh toan san bong {maDatSan}";
            string accountNumber = "446619999"; // Số tài khoản cần kiểm tra
            string transactionDateMin = DateTime.Now.AddMinutes(-30).ToString("yyyy-MM-dd HH:mm:ss"); // Kiểm tra giao dịch trong 30 phút gần nhất

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {sepayApiToken}");
                    client.DefaultRequestHeaders.Add("X-Username", sepayUsername);

                    string url = $"https://my.sepay.vn/userapi/transactions/list?account_number={accountNumber}&transaction_date_min={transactionDateMin}&amount_in={totalBill}";
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
                    {
                        JsonElement root = doc.RootElement;
                        JsonElement transactions = root.GetProperty("transactions");

                        bool paymentFound = false;
                        foreach (JsonElement transaction in transactions.EnumerateArray())
                        {
                            string transactionContent = transaction.GetProperty("transaction_content").GetString();
                            decimal amountIn = transaction.GetProperty("amount_in").GetDecimal();

                            if (transactionContent.Equals(expectedContent, StringComparison.OrdinalIgnoreCase) && amountIn == totalBill)
                            {
                                paymentFound = true;
                                break;
                            }
                        }

                        if (paymentFound)
                        {
                            // Cập nhật trạng thái thanh toán
                            UpdateTrangThaiThanhToan();
                            // Lưu lịch sử thanh toán
                            SavePaymentHistory(expectedContent);

                            MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDatSanChuaThanhToanAsync(); // Tải lại danh sách bất đồng bộ
                            picQRCode.Image = null;
                            lblQRInfo.Text = "Vui lòng chọn lịch đặt sân để thanh toán.";
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy giao dịch phù hợp. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kiểm tra giao dịch: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Cập nhật trạng thái thanh toán
        private void UpdateTrangThaiThanhToan()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE DatSan SET TrangThaiThanhToan = 1 WHERE MaDatSan = @MaDatSan";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDatSan", int.Parse(maDatSan.Replace("DS", "")));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        // Lưu lịch sử thanh toán
        private void SavePaymentHistory(string noiDungChuyenKhoan)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO LichSuThanhToan (MaDatSan, SoTien, NgayThanhToan, NoiDungChuyenKhoan) " +
                              "VALUES (@MaDatSan, @SoTien, @NgayThanhToan, @NoiDungChuyenKhoan)";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDatSan", maDatSan);
                cmd.Parameters.AddWithValue("@SoTien", totalBill);
                cmd.Parameters.AddWithValue("@NgayThanhToan", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@NoiDungChuyenKhoan", noiDungChuyenKhoan);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
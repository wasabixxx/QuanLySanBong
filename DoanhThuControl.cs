using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySanBong
{
    public partial class DoanhThuControl : UserControl
    {
        private string connectionString = "Data Source=QuanLySanBong.db;Version=3;";

        public DoanhThuControl()
        {
            InitializeComponent();
            SetupComboBoxes();
            SetupDataGridView();
            LoadDoanhThuData();
            this.Resize += new EventHandler(DoanhThuControl_Resize);
        }

        private void SetupComboBoxes()
        {
            // Setup tháng (thêm "Không chọn" và các tháng 01-12)
            comboBoxThang.Items.Add("Không chọn"); // Tùy chọn đầu tiên
            for (int i = 1; i <= 12; i++)
            {
                comboBoxThang.Items.Add(i.ToString("D2")); // Định dạng 2 chữ số (01, 02, ..., 12)
            }
            comboBoxThang.SelectedIndex = 0; // Mặc định chọn "Không chọn"

            // Setup năm (thêm "Không chọn" và các năm 2024-2028)
            comboBoxNam.Items.Add("Không chọn"); // Tùy chọn đầu tiên
            int currentYear = 2025; // Năm hiện tại
            for (int year = currentYear - 1; year <= currentYear + 3; year++)
            {
                comboBoxNam.Items.Add(year.ToString());
            }
            comboBoxNam.SelectedIndex = 0; // Mặc định chọn "Không chọn"
        }

        private void SetupDataGridView()
        {
            // Xóa các cột hiện có (nếu có)
            dataGridViewDoanhThu.Columns.Clear();
            // Thêm các cột
            dataGridViewDoanhThu.Columns.Add("MaSan", "Mã sân");
            dataGridViewDoanhThu.Columns.Add("TenSan", "Tên sân");
            dataGridViewDoanhThu.Columns.Add("NgayThanhToan", "Ngày thanh toán");
            dataGridViewDoanhThu.Columns.Add("DoanhThu", "Doanh thu (VNĐ)");
            // Định dạng cột DoanhThu để hiển thị tiền tệ
            dataGridViewDoanhThu.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
        }

        private void DoanhThuControl_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            labelTitle.Width = width;
            labelTongDoanhThu.Width = width - 20;
            dataGridViewDoanhThu.Width = width - 40;
            dataGridViewDoanhThu.Height = height - 150;
            labelThang.Location = new Point(10, 80);
            comboBoxThang.Location = new Point(70, 80);
            labelNam.Location = new Point(130, 80);
            comboBoxNam.Location = new Point(180, 80);
            buttonSearch.Location = new Point(width - 80, 80);
        }

        private void LoadDoanhThuData(string thangNam = "")
        {
            dataGridViewDoanhThu.Rows.Clear();
            decimal tongDoanhThu = 0;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // Truy vấn tổng doanh thu
                string queryTong = @"
                    SELECT SUM(SoTien) AS TongDoanhThu
                    FROM LichSuThanhToan
                    WHERE (@ThangNam = '' OR NgayThanhToan LIKE @ThangNam || '%')";
                using (SQLiteCommand cmdTong = new SQLiteCommand(queryTong, conn))
                {
                    cmdTong.Parameters.AddWithValue("@ThangNam", thangNam);
                    object result = cmdTong.ExecuteScalar();
                    tongDoanhThu = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }

                // Cập nhật label tổng doanh thu
                labelTongDoanhThu.Text = $"Tổng doanh thu: {tongDoanhThu:N0} VNĐ";

                // Truy vấn chi tiết doanh thu (bao gồm ngày thanh toán)
                string query = @"
                    SELECT sb.MaSan, sb.TenSan, lst.NgayThanhToan, lst.SoTien AS DoanhThu
                    FROM LichSuThanhToan lst
                    JOIN DatSan ds ON lst.MaDatSan = ds.MaDatSan
                    JOIN SanBong sb ON ds.MaSan = sb.MaSan
                    WHERE (@ThangNam = '' OR NgayThanhToan LIKE @ThangNam || '%')";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ThangNam", thangNam);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridViewDoanhThu.Rows.Add(
                                reader["MaSan"],
                                reader["TenSan"],
                                reader["NgayThanhToan"],
                                reader["DoanhThu"]
                            );
                        }
                    }
                }
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string thang = comboBoxThang.SelectedItem?.ToString();
            string nam = comboBoxNam.SelectedItem?.ToString();
            string thangNam = "";

            // Xử lý logic khi chọn "Không chọn"
            if (nam == "Không chọn" && thang == "Không chọn")
            {
                thangNam = ""; // Hiển thị tất cả dữ liệu (không lọc)
            }
            else if (nam == "Không chọn")
            {
                thangNam = ""; // Hiển thị tất cả năm, nhưng có thể lọc theo tháng nếu tháng được chọn
            }
            else if (thang == "Không chọn")
            {
                thangNam = $"{nam}-%"; // Hiển thị tất cả tháng trong năm được chọn
            }
            else
            {
                thangNam = $"{nam}-{thang}"; // Lọc theo tháng và năm cụ thể
            }

            LoadDoanhThuData(thangNam);
        }
    }
}
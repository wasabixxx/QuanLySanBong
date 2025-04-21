using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySanBong
{
    public partial class ThanhToanControl : UserControl
    {
        private string connectionString = "Data Source=QuanLySanBong.db;Version=3;";

        public ThanhToanControl()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadThanhToanData();
            this.Resize += new EventHandler(ThanhToanControl_Resize);
        }

        private void ThanhToanControl_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            labelTitle.Width = width;
            dataGridViewThanhToan.Width = width - 40;
            dataGridViewThanhToan.Height = height - 120;
            textBoxSearch.Width = width - 250;
        }

        private void SetupDataGridView()
        {
            dataGridViewThanhToan.Columns.Clear();
            dataGridViewThanhToan.Columns.Add("MaThanhToan", "Mã thanh toán");
            dataGridViewThanhToan.Columns.Add("MaDatSan", "Mã đặt sân");
            dataGridViewThanhToan.Columns.Add("SoTien", "Số tiền");
            dataGridViewThanhToan.Columns.Add("NgayThanhToan", "Ngày thanh toán");
            dataGridViewThanhToan.Columns.Add("NoiDungChuyenKhoan", "Nội dung chuyển khoản");
        }

        private void LoadThanhToanData(string searchMaDatSan = "")
        {
            dataGridViewThanhToan.Rows.Clear();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT * FROM LichSuThanhToan
                    WHERE (@SearchMaDatSan = '' OR MaDatSan = @SearchMaDatSan)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchMaDatSan", searchMaDatSan);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridViewThanhToan.Rows.Add(
                                reader["MaThanhToan"],
                                reader["MaDatSan"],
                                reader["SoTien"],
                                reader["NgayThanhToan"],
                                reader["NoiDungChuyenKhoan"]
                            );
                        }
                    }
                }
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchMaDatSan = textBoxSearch.Text.Trim();
            LoadThanhToanData(searchMaDatSan);
        }
    }
}
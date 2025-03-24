using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Data.SQLite;

namespace QuanLySanBong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=QuanLySanBong.db;Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    CREATE TABLE IF NOT EXISTS SanBong (
                        MaSan INTEGER PRIMARY KEY AUTOINCREMENT,
                        TenSan TEXT NOT NULL,
                        LoaiSan TEXT NOT NULL,
                        GiaThue INTEGER NOT NULL
                    );
                    CREATE TABLE IF NOT EXISTS KhachHang (
                        MaKH INTEGER PRIMARY KEY AUTOINCREMENT,
                        TenKH TEXT NOT NULL,
                        SoDienThoai TEXT NOT NULL
                    );
                    CREATE TABLE IF NOT EXISTS DatSan (
                        MaDatSan INTEGER PRIMARY KEY AUTOINCREMENT,
                        MaSan INTEGER NOT NULL,
                        MaKH INTEGER NOT NULL,
                        NgayDat TEXT NOT NULL,
                        GioBatDau TEXT NOT NULL,
                        GioKetThuc TEXT NOT NULL,
                        TongTien DECIMAL NOT NULL,
                        TrangThaiThanhToan INTEGER DEFAULT 0, -- Thêm cột trạng thái thanh toán
                        FOREIGN KEY (MaSan) REFERENCES SanBong(MaSan),
                        FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
                    );
                    CREATE TABLE IF NOT EXISTS LichSuThanhToan (
                        MaThanhToan INTEGER PRIMARY KEY AUTOINCREMENT,
                        MaDatSan TEXT NOT NULL,
                        SoTien DECIMAL NOT NULL,
                        NgayThanhToan TEXT NOT NULL,
                        NoiDungChuyenKhoan TEXT NOT NULL
                    );";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            // Khởi động ứng dụng
            Application.Run(new FormLogin());
        }
    }
}
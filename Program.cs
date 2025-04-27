using System;
using System.Windows.Forms;

namespace QuanLySanBong
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Khởi động ứng dụng với form đăng nhập
            Application.Run(new FormLogin());
        }
    }
}
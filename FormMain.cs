using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySanBong
{
    public partial class FormMain : Form
    {
        private UserControl currentControl;

        public FormMain()
        {
            InitializeComponent();
            CustomizeDesign();
            // Hiển thị TrangChuControl mặc định khi khởi động
            OpenUserControl(new TrangChuControl());
        }

        private void OpenUserControl(UserControl userControl)
        {
            if (currentControl != null)
            {
                panelMainContent.Controls.Remove(currentControl);
                currentControl.Dispose();
            }
            currentControl = userControl;
            userControl.Dock = DockStyle.Fill;
            panelMainContent.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void CustomizeDesign()
        {
            // Thêm icon cho các nút (giả định bạn đã có các icon trong Resources)
            // Ví dụ: btnTrangChu.Image = Properties.Resources.trangchu_icon;
            // Bạn có thể thêm icon trong Visual Studio designer
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            OpenUserControl(new TrangChuControl());
        }

        private void btnQuanLySan_Click(object sender, EventArgs e)
        {
            OpenUserControl(new QuanLySanControl());
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            OpenUserControl(new ThanhToanControl());
        }

        private void btnXemLich_Click(object sender, EventArgs e)
        {
            OpenUserControl(new XemLichControl());
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
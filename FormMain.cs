using System;
using System.Windows.Forms;

namespace QuanLySanBong
{
    public partial class FormMain : Form
    {
        private FormQuanLySan formQuanLySan;
        private FormDatSan formDatSan;
        private FormXemLich formXemLich;
        private FormThanhToan formThanhToan;

        public FormMain()
        {
            InitializeComponent();
        }

        private void CloseAllForms()
        {
            if (formQuanLySan != null && !formQuanLySan.IsDisposed)
            {
                formQuanLySan.Close();
                formQuanLySan = null;
            }
            if (formDatSan != null && !formDatSan.IsDisposed)
            {
                formDatSan.Close();
                formDatSan = null;
            }
            if (formXemLich != null && !formXemLich.IsDisposed)
            {
                formXemLich.Close();
                formXemLich = null;
            }
            if (formThanhToan != null && !formThanhToan.IsDisposed)
            {
                formThanhToan.Close();
                formThanhToan = null;
            }
        }

        private void mnuQuanLySan_Click(object sender, EventArgs e)
        {
            CloseAllForms();
            formQuanLySan = new FormQuanLySan();
            formQuanLySan.MdiParent = this;
            formQuanLySan.FormBorderStyle = FormBorderStyle.None;
            formQuanLySan.Dock = DockStyle.Fill;
            formQuanLySan.Show();
        }

        private void mnuDatSan_Click(object sender, EventArgs e)
        {
            CloseAllForms();
            formDatSan = new FormDatSan();
            formDatSan.MdiParent = this;
            formDatSan.FormBorderStyle = FormBorderStyle.None;
            formDatSan.Dock = DockStyle.Fill;
            formDatSan.Show();
        }

        private void mnuXemLich_Click(object sender, EventArgs e)
        {
            CloseAllForms();
            formXemLich = new FormXemLich();
            formXemLich.MdiParent = this;
            formXemLich.FormBorderStyle = FormBorderStyle.None;
            formXemLich.Dock = DockStyle.Fill;
            formXemLich.Show();
        }

        private void mnuThanhToan_Click(object sender, EventArgs e)
        {
            CloseAllForms();
            formThanhToan = new FormThanhToan();
            formThanhToan.MdiParent = this;
            formThanhToan.FormBorderStyle = FormBorderStyle.None;
            formThanhToan.Dock = DockStyle.Fill;
            formThanhToan.Show();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
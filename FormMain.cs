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

        private void mnuQuanLySan_Click(object sender, EventArgs e)
        {
            if (formQuanLySan == null || formQuanLySan.IsDisposed)
            {
                formQuanLySan = new FormQuanLySan();
                formQuanLySan.MdiParent = this;
                formQuanLySan.FormBorderStyle = FormBorderStyle.None;
                formQuanLySan.Dock = DockStyle.Fill;
                formQuanLySan.Show();
            }
            else
            {
                formQuanLySan.BringToFront();
            }

            if (formDatSan != null && !formDatSan.IsDisposed) formDatSan.Hide();
            if (formXemLich != null && !formXemLich.IsDisposed) formXemLich.Hide();
            if (formThanhToan != null && !formThanhToan.IsDisposed) formThanhToan.Hide();
        }

        private void mnuDatSan_Click(object sender, EventArgs e)
        {
            if (formDatSan == null || formDatSan.IsDisposed)
            {
                formDatSan = new FormDatSan();
                formDatSan.MdiParent = this;
                formDatSan.FormBorderStyle = FormBorderStyle.None;
                formDatSan.Dock = DockStyle.Fill;
                formDatSan.Show();
            }
            else
            {
                formDatSan.BringToFront();
            }

            if (formQuanLySan != null && !formQuanLySan.IsDisposed) formQuanLySan.Hide();
            if (formXemLich != null && !formXemLich.IsDisposed) formXemLich.Hide();
            if (formThanhToan != null && !formThanhToan.IsDisposed) formThanhToan.Hide();
        }

        private void mnuXemLich_Click(object sender, EventArgs e)
        {
            if (formXemLich == null || formXemLich.IsDisposed)
            {
                formXemLich = new FormXemLich();
                formXemLich.MdiParent = this;
                formXemLich.FormBorderStyle = FormBorderStyle.None;
                formXemLich.Dock = DockStyle.Fill;
                formXemLich.Show();
            }
            else
            {
                formXemLich.BringToFront();
            }

            if (formQuanLySan != null && !formQuanLySan.IsDisposed) formQuanLySan.Hide();
            if (formDatSan != null && !formDatSan.IsDisposed) formDatSan.Hide();
            if (formThanhToan != null && !formThanhToan.IsDisposed) formThanhToan.Hide();
        }

        private void mnuThanhToan_Click(object sender, EventArgs e)
        {
            if (formThanhToan == null || formThanhToan.IsDisposed)
            {
                formThanhToan = new FormThanhToan();
                formThanhToan.MdiParent = this;
                formThanhToan.FormBorderStyle = FormBorderStyle.None;
                formThanhToan.Dock = DockStyle.Fill;
                formThanhToan.Show();
            }
            else
            {
                formThanhToan.BringToFront();
            }

            if (formQuanLySan != null && !formQuanLySan.IsDisposed) formQuanLySan.Hide();
            if (formDatSan != null && !formDatSan.IsDisposed) formDatSan.Hide();
            if (formXemLich != null && !formXemLich.IsDisposed) formXemLich.Hide();
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
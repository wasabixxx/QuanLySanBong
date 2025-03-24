namespace QuanLySanBong
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuQuanLySan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatSan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXemLich = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThanhToan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuQuanLySan,
            this.mnuDatSan,
            this.mnuXemLich,
            this.mnuThanhToan,
            this.mnuThoat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuQuanLySan
            // 
            this.mnuQuanLySan.Name = "mnuQuanLySan";
            this.mnuQuanLySan.Size = new System.Drawing.Size(81, 20);
            this.mnuQuanLySan.Text = "Quản lý sân";
            this.mnuQuanLySan.Click += new System.EventHandler(this.mnuQuanLySan_Click);
            // 
            // mnuDatSan
            // 
            this.mnuDatSan.Name = "mnuDatSan";
            this.mnuDatSan.Size = new System.Drawing.Size(58, 20);
            this.mnuDatSan.Text = "Đặt sân";
            this.mnuDatSan.Click += new System.EventHandler(this.mnuDatSan_Click);
            // 
            // mnuXemLich
            // 
            this.mnuXemLich.Name = "mnuXemLich";
            this.mnuXemLich.Size = new System.Drawing.Size(65, 20);
            this.mnuXemLich.Text = "Xem lịch";
            this.mnuXemLich.Click += new System.EventHandler(this.mnuXemLich_Click);
            // 
            // mnuThanhToan
            // 
            this.mnuThanhToan.Name = "mnuThanhToan";
            this.mnuThanhToan.Size = new System.Drawing.Size(80, 20);
            this.mnuThanhToan.Text = "Thanh toán";
            this.mnuThanhToan.Click += new System.EventHandler(this.mnuThanhToan_Click);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(50, 20);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý sân bóng";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanLySan;
        private System.Windows.Forms.ToolStripMenuItem mnuDatSan;
        private System.Windows.Forms.ToolStripMenuItem mnuXemLich;
        private System.Windows.Forms.ToolStripMenuItem mnuThanhToan;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
    }
}
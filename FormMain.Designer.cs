using System.Windows.Forms;

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
            this.panelSideBar = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.iconButtonXemLich = new FontAwesome.Sharp.IconButton();
            this.iconButtonThoat = new FontAwesome.Sharp.IconButton();
            this.iconButtonQuanLySan = new FontAwesome.Sharp.IconButton();
            this.iconButtonThanhToan = new FontAwesome.Sharp.IconButton();
            this.iconButtonDatSan = new FontAwesome.Sharp.IconButton();
            this.iconButtonTrangChu = new FontAwesome.Sharp.IconButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMainContent = new System.Windows.Forms.Panel();
            this.iconButtonDoanhThu = new FontAwesome.Sharp.IconButton();
            this.panelSideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideBar
            // 
            this.panelSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.panelSideBar.Controls.Add(this.iconButtonDoanhThu);
            this.panelSideBar.Controls.Add(this.pictureBox1);
            this.panelSideBar.Controls.Add(this.iconButtonXemLich);
            this.panelSideBar.Controls.Add(this.iconButtonThoat);
            this.panelSideBar.Controls.Add(this.iconButtonQuanLySan);
            this.panelSideBar.Controls.Add(this.iconButtonThanhToan);
            this.panelSideBar.Controls.Add(this.iconButtonDatSan);
            this.panelSideBar.Controls.Add(this.iconButtonTrangChu);
            this.panelSideBar.Controls.Add(this.lblTitle);
            this.panelSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideBar.Location = new System.Drawing.Point(0, 0);
            this.panelSideBar.Name = "panelSideBar";
            this.panelSideBar.Size = new System.Drawing.Size(250, 661);
            this.panelSideBar.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLySanBong.Properties.Resources.default_venue_0_dc1f6687f619915230b62712508933a71a6e9529c390237b9766acc0d59539ab;
            this.pictureBox1.Location = new System.Drawing.Point(21, 75);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // iconButtonXemLich
            // 
            this.iconButtonXemLich.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.iconButtonXemLich.IconChar = FontAwesome.Sharp.IconChar.Neuter;
            this.iconButtonXemLich.IconColor = System.Drawing.Color.Black;
            this.iconButtonXemLich.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonXemLich.IconSize = 40;
            this.iconButtonXemLich.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonXemLich.Location = new System.Drawing.Point(21, 412);
            this.iconButtonXemLich.Name = "iconButtonXemLich";
            this.iconButtonXemLich.Size = new System.Drawing.Size(201, 47);
            this.iconButtonXemLich.TabIndex = 4;
            this.iconButtonXemLich.Text = "Xem Lịch Sân";
            this.iconButtonXemLich.UseVisualStyleBackColor = true;
            this.iconButtonXemLich.Click += new System.EventHandler(this.iconButtonXemLich_Click);
            // 
            // iconButtonThoat
            // 
            this.iconButtonThoat.BackColor = System.Drawing.Color.IndianRed;
            this.iconButtonThoat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.iconButtonThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.iconButtonThoat.ForeColor = System.Drawing.Color.Black;
            this.iconButtonThoat.IconChar = FontAwesome.Sharp.IconChar.ExclamationTriangle;
            this.iconButtonThoat.IconColor = System.Drawing.Color.Snow;
            this.iconButtonThoat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonThoat.Location = new System.Drawing.Point(0, 614);
            this.iconButtonThoat.Name = "iconButtonThoat";
            this.iconButtonThoat.Size = new System.Drawing.Size(250, 47);
            this.iconButtonThoat.TabIndex = 5;
            this.iconButtonThoat.Text = "Thoát";
            this.iconButtonThoat.UseVisualStyleBackColor = false;
            this.iconButtonThoat.Click += new System.EventHandler(this.iconButtonThoat_Click);
            // 
            // iconButtonQuanLySan
            // 
            this.iconButtonQuanLySan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.iconButtonQuanLySan.IconChar = FontAwesome.Sharp.IconChar.PaintBrush;
            this.iconButtonQuanLySan.IconColor = System.Drawing.Color.Black;
            this.iconButtonQuanLySan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonQuanLySan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonQuanLySan.Location = new System.Drawing.Point(21, 306);
            this.iconButtonQuanLySan.Name = "iconButtonQuanLySan";
            this.iconButtonQuanLySan.Size = new System.Drawing.Size(201, 47);
            this.iconButtonQuanLySan.TabIndex = 2;
            this.iconButtonQuanLySan.Text = "Quản Lý Sân";
            this.iconButtonQuanLySan.UseVisualStyleBackColor = true;
            this.iconButtonQuanLySan.Click += new System.EventHandler(this.iconButtonQuanLySan_Click);
            // 
            // iconButtonThanhToan
            // 
            this.iconButtonThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButtonThanhToan.IconChar = FontAwesome.Sharp.IconChar.MoneyBillAlt;
            this.iconButtonThanhToan.IconColor = System.Drawing.Color.Black;
            this.iconButtonThanhToan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonThanhToan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonThanhToan.Location = new System.Drawing.Point(21, 359);
            this.iconButtonThanhToan.Name = "iconButtonThanhToan";
            this.iconButtonThanhToan.Size = new System.Drawing.Size(201, 47);
            this.iconButtonThanhToan.TabIndex = 3;
            this.iconButtonThanhToan.Text = "Lịch Sử Thanh Toán";
            this.iconButtonThanhToan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButtonThanhToan.UseVisualStyleBackColor = true;
            this.iconButtonThanhToan.Click += new System.EventHandler(this.iconButtonThanhToan_Click);
            // 
            // iconButtonDatSan
            // 
            this.iconButtonDatSan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.iconButtonDatSan.IconChar = FontAwesome.Sharp.IconChar.Odysee;
            this.iconButtonDatSan.IconColor = System.Drawing.Color.Black;
            this.iconButtonDatSan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonDatSan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonDatSan.Location = new System.Drawing.Point(21, 253);
            this.iconButtonDatSan.Name = "iconButtonDatSan";
            this.iconButtonDatSan.Size = new System.Drawing.Size(201, 47);
            this.iconButtonDatSan.TabIndex = 1;
            this.iconButtonDatSan.Text = "Đặt Sân";
            this.iconButtonDatSan.UseVisualStyleBackColor = true;
            this.iconButtonDatSan.Click += new System.EventHandler(this.iconButtonDatSan_Click);
            // 
            // iconButtonTrangChu
            // 
            this.iconButtonTrangChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButtonTrangChu.IconChar = FontAwesome.Sharp.IconChar.House;
            this.iconButtonTrangChu.IconColor = System.Drawing.Color.Black;
            this.iconButtonTrangChu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonTrangChu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonTrangChu.Location = new System.Drawing.Point(21, 200);
            this.iconButtonTrangChu.Name = "iconButtonTrangChu";
            this.iconButtonTrangChu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.iconButtonTrangChu.Size = new System.Drawing.Size(201, 47);
            this.iconButtonTrangChu.TabIndex = 0;
            this.iconButtonTrangChu.Text = "Trang Chủ";
            this.iconButtonTrangChu.UseVisualStyleBackColor = true;
            this.iconButtonTrangChu.Click += new System.EventHandler(this.iconButtonTrangChu_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.DarkGreen;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(250, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ SÂN BÓNG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMainContent
            // 
            this.panelMainContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContent.Location = new System.Drawing.Point(250, 0);
            this.panelMainContent.Name = "panelMainContent";
            this.panelMainContent.Size = new System.Drawing.Size(934, 661);
            this.panelMainContent.TabIndex = 1;
            // 
            // iconButtonDoanhThu
            // 
            this.iconButtonDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.iconButtonDoanhThu.IconChar = FontAwesome.Sharp.IconChar.MoneyCheckDollar;
            this.iconButtonDoanhThu.IconColor = System.Drawing.Color.Black;
            this.iconButtonDoanhThu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonDoanhThu.IconSize = 40;
            this.iconButtonDoanhThu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonDoanhThu.Location = new System.Drawing.Point(21, 465);
            this.iconButtonDoanhThu.Name = "iconButtonDoanhThu";
            this.iconButtonDoanhThu.Size = new System.Drawing.Size(201, 47);
            this.iconButtonDoanhThu.TabIndex = 7;
            this.iconButtonDoanhThu.Text = "Doanh Thu";
            this.iconButtonDoanhThu.UseVisualStyleBackColor = true;
            this.iconButtonDoanhThu.Click += new System.EventHandler(this.iconButtonDoanhThu_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.panelMainContent);
            this.Controls.Add(this.panelSideBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Sân Bóng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelSideBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelSideBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMainContent;
        private FontAwesome.Sharp.IconButton iconButtonThoat;
        private FontAwesome.Sharp.IconButton iconButtonXemLich;
        private FontAwesome.Sharp.IconButton iconButtonThanhToan;
        private FontAwesome.Sharp.IconButton iconButtonQuanLySan;
        private FontAwesome.Sharp.IconButton iconButtonDatSan;
        private FontAwesome.Sharp.IconButton iconButtonTrangChu;
        private PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton iconButtonDoanhThu;
    }
}
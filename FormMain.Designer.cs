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
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnXemLich = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnQuanLySan = new System.Windows.Forms.Button();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMainContent = new System.Windows.Forms.Panel();
            this.panelSideBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSideBar
            // 
            this.panelSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.panelSideBar.Controls.Add(this.btnDangXuat);
            this.panelSideBar.Controls.Add(this.btnXemLich);
            this.panelSideBar.Controls.Add(this.btnThanhToan);
            this.panelSideBar.Controls.Add(this.btnQuanLySan);
            this.panelSideBar.Controls.Add(this.btnTrangChu);
            this.panelSideBar.Controls.Add(this.lblTitle);
            this.panelSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideBar.Location = new System.Drawing.Point(0, 0);
            this.panelSideBar.Name = "panelSideBar";
            this.panelSideBar.Size = new System.Drawing.Size(250, 661);
            this.panelSideBar.TabIndex = 0;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.Location = new System.Drawing.Point(10, 300);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(230, 40);
            this.btnDangXuat.TabIndex = 5;
            this.btnDangXuat.Text = "Thoát";
            this.btnDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnXemLich
            // 
            this.btnXemLich.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnXemLich.FlatAppearance.BorderSize = 0;
            this.btnXemLich.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemLich.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemLich.Location = new System.Drawing.Point(10, 250);
            this.btnXemLich.Name = "btnXemLich";
            this.btnXemLich.Size = new System.Drawing.Size(230, 40);
            this.btnXemLich.TabIndex = 4;
            this.btnXemLich.Text = "Xem lịch";
            this.btnXemLich.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemLich.UseVisualStyleBackColor = false;
            this.btnXemLich.Click += new System.EventHandler(this.btnXemLich_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.Location = new System.Drawing.Point(10, 200);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(230, 40);
            this.btnThanhToan.TabIndex = 3;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnQuanLySan
            // 
            this.btnQuanLySan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnQuanLySan.FlatAppearance.BorderSize = 0;
            this.btnQuanLySan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLySan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLySan.Location = new System.Drawing.Point(10, 150);
            this.btnQuanLySan.Name = "btnQuanLySan";
            this.btnQuanLySan.Size = new System.Drawing.Size(230, 40);
            this.btnQuanLySan.TabIndex = 2;
            this.btnQuanLySan.Text = "Quản lý sân";
            this.btnQuanLySan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLySan.UseVisualStyleBackColor = false;
            this.btnQuanLySan.Click += new System.EventHandler(this.btnQuanLySan_Click);
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnTrangChu.FlatAppearance.BorderSize = 0;
            this.btnTrangChu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrangChu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrangChu.Location = new System.Drawing.Point(10, 100);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(230, 40);
            this.btnTrangChu.TabIndex = 1;
            this.btnTrangChu.Text = "Trang chủ";
            this.btnTrangChu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrangChu.UseVisualStyleBackColor = false;
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Green;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(250, 50);
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.panelMainContent);
            this.Controls.Add(this.panelSideBar);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Sân Bóng";
            this.panelSideBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelSideBar;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnXemLich;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnQuanLySan;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMainContent;
    }
}
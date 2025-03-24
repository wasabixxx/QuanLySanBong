namespace QuanLySanBong
{
    partial class FormThanhToan
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
            this.cmbDatSan = new System.Windows.Forms.ComboBox();
            this.picQRCode = new System.Windows.Forms.PictureBox();
            this.lblQRInfo = new System.Windows.Forms.Label();
            this.btnKiemTra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbDatSan
            // 
            this.cmbDatSan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDatSan.FormattingEnabled = true;
            this.cmbDatSan.Location = new System.Drawing.Point(150, 30);
            this.cmbDatSan.Name = "cmbDatSan";
            this.cmbDatSan.Size = new System.Drawing.Size(500, 21);
            this.cmbDatSan.TabIndex = 0;
            this.cmbDatSan.SelectedIndexChanged += new System.EventHandler(this.cmbDatSan_SelectedIndexChanged);
            // 
            // picQRCode
            // 
            this.picQRCode.Location = new System.Drawing.Point(250, 70);
            this.picQRCode.Name = "picQRCode";
            this.picQRCode.Size = new System.Drawing.Size(200, 200);
            this.picQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQRCode.TabIndex = 1;
            this.picQRCode.TabStop = false;
            // 
            // lblQRInfo
            // 
            this.lblQRInfo.AutoSize = true;
            this.lblQRInfo.Location = new System.Drawing.Point(200, 280);
            this.lblQRInfo.Name = "lblQRInfo";
            this.lblQRInfo.Size = new System.Drawing.Size(300, 13);
            this.lblQRInfo.TabIndex = 2;
            this.lblQRInfo.Text = "Vui lòng chọn lịch đặt sân để thanh toán.";
            this.lblQRInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Location = new System.Drawing.Point(350, 310);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(100, 30);
            this.btnKiemTra.TabIndex = 3;
            this.btnKiemTra.Text = "Kiểm tra";
            this.btnKiemTra.UseVisualStyleBackColor = true;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // FormThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnKiemTra);
            this.Controls.Add(this.lblQRInfo);
            this.Controls.Add(this.picQRCode);
            this.Controls.Add(this.cmbDatSan);
            this.Name = "FormThanhToan";
            this.Text = "Thanh toán đặt sân";
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox cmbDatSan;
        private System.Windows.Forms.PictureBox picQRCode;
        private System.Windows.Forms.Label lblQRInfo;
        private System.Windows.Forms.Button btnKiemTra;
    }
}
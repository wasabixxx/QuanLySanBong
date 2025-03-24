namespace QuanLySanBong
{
    partial class FormDatSan
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSanBong = new System.Windows.Forms.ComboBox();
            this.dtpNgayDat = new System.Windows.Forms.DateTimePicker();
            this.txtGioBatDau = new System.Windows.Forms.TextBox();
            this.txtGioKetThuc = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.btnDatSan = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sân bóng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày đặt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giờ bắt đầu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Giờ kết thúc";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tên khách hàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Số điện thoại";
            // 
            // cmbSanBong
            // 
            this.cmbSanBong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSanBong.FormattingEnabled = true;
            this.cmbSanBong.Location = new System.Drawing.Point(120, 27);
            this.cmbSanBong.Name = "cmbSanBong";
            this.cmbSanBong.Size = new System.Drawing.Size(150, 21);
            this.cmbSanBong.TabIndex = 6;
            // 
            // dtpNgayDat
            // 
            this.dtpNgayDat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayDat.Location = new System.Drawing.Point(120, 57);
            this.dtpNgayDat.Name = "dtpNgayDat";
            this.dtpNgayDat.Size = new System.Drawing.Size(150, 20);
            this.dtpNgayDat.TabIndex = 7;
            // 
            // txtGioBatDau
            // 
            this.txtGioBatDau.Location = new System.Drawing.Point(120, 87);
            this.txtGioBatDau.Name = "txtGioBatDau";
            this.txtGioBatDau.Size = new System.Drawing.Size(150, 20);
            this.txtGioBatDau.TabIndex = 8;
            // 
            // txtGioKetThuc
            // 
            this.txtGioKetThuc.Location = new System.Drawing.Point(120, 117);
            this.txtGioKetThuc.Name = "txtGioKetThuc";
            this.txtGioKetThuc.Size = new System.Drawing.Size(150, 20);
            this.txtGioKetThuc.TabIndex = 9;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(120, 147);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(150, 20);
            this.txtTenKH.TabIndex = 10;
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(120, 177);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(150, 20);
            this.txtSoDienThoai.TabIndex = 11;
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Location = new System.Drawing.Point(50, 220);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(90, 30);
            this.btnKiemTra.TabIndex = 12;
            this.btnKiemTra.Text = "Kiểm tra";
            this.btnKiemTra.UseVisualStyleBackColor = true;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // btnDatSan
            // 
            this.btnDatSan.Location = new System.Drawing.Point(150, 220);
            this.btnDatSan.Name = "btnDatSan";
            this.btnDatSan.Size = new System.Drawing.Size(90, 30);
            this.btnDatSan.TabIndex = 13;
            this.btnDatSan.Text = "Đặt sân";
            this.btnDatSan.UseVisualStyleBackColor = true;
            this.btnDatSan.Click += new System.EventHandler(this.btnDatSan_Click);
            // 
            // FormDatSan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 280);
            this.Controls.Add(this.btnDatSan);
            this.Controls.Add(this.btnKiemTra);
            this.Controls.Add(this.txtSoDienThoai);
            this.Controls.Add(this.txtTenKH);
            this.Controls.Add(this.txtGioKetThuc);
            this.Controls.Add(this.txtGioBatDau);
            this.Controls.Add(this.dtpNgayDat);
            this.Controls.Add(this.cmbSanBong);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormDatSan";
            this.Text = "Đặt sân bóng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSanBong;
        private System.Windows.Forms.DateTimePicker dtpNgayDat;
        private System.Windows.Forms.TextBox txtGioBatDau;
        private System.Windows.Forms.TextBox txtGioKetThuc;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.Button btnDatSan;
    }
}
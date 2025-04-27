namespace QuanLySanBong
{
    partial class DatSanControl
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelThongTinDatSan = new System.Windows.Forms.Panel();
            this.buttonDatSan = new System.Windows.Forms.Button();
            this.textBoxSoDienThoai = new System.Windows.Forms.TextBox();
            this.labelSoDienThoai = new System.Windows.Forms.Label();
            this.textBoxTenKH = new System.Windows.Forms.TextBox();
            this.labelTenKH = new System.Windows.Forms.Label();
            this.dateTimePickerGioKetThuc = new System.Windows.Forms.DateTimePicker();
            this.labelGioKetThuc = new System.Windows.Forms.Label();
            this.dateTimePickerGioBatDau = new System.Windows.Forms.DateTimePicker();
            this.labelGioBatDau = new System.Windows.Forms.Label();
            this.dateTimePickerNgayDat = new System.Windows.Forms.DateTimePicker();
            this.labelNgayDat = new System.Windows.Forms.Label();
            this.comboBoxSan = new System.Windows.Forms.ComboBox();
            this.labelSan = new System.Windows.Forms.Label();
            this.panelThongTinDatSan.SuspendLayout();
            this.SuspendLayout();

            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.labelTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(934, 40);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "ĐẶT SÂN BÓNG";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // panelThongTinDatSan
            // 
            this.panelThongTinDatSan.BackColor = System.Drawing.Color.White;
            this.panelThongTinDatSan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelThongTinDatSan.Controls.Add(this.buttonDatSan);
            this.panelThongTinDatSan.Controls.Add(this.textBoxSoDienThoai);
            this.panelThongTinDatSan.Controls.Add(this.labelSoDienThoai);
            this.panelThongTinDatSan.Controls.Add(this.textBoxTenKH);
            this.panelThongTinDatSan.Controls.Add(this.labelTenKH);
            this.panelThongTinDatSan.Controls.Add(this.dateTimePickerGioKetThuc);
            this.panelThongTinDatSan.Controls.Add(this.labelGioKetThuc);
            this.panelThongTinDatSan.Controls.Add(this.dateTimePickerGioBatDau);
            this.panelThongTinDatSan.Controls.Add(this.labelGioBatDau);
            this.panelThongTinDatSan.Controls.Add(this.dateTimePickerNgayDat);
            this.panelThongTinDatSan.Controls.Add(this.labelNgayDat);
            this.panelThongTinDatSan.Controls.Add(this.comboBoxSan);
            this.panelThongTinDatSan.Controls.Add(this.labelSan);
            this.panelThongTinDatSan.Location = new System.Drawing.Point(20, 60);
            this.panelThongTinDatSan.Name = "panelThongTinDatSan";
            this.panelThongTinDatSan.Size = new System.Drawing.Size(894, 400);
            this.panelThongTinDatSan.TabIndex = 1;
            this.panelThongTinDatSan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // buttonDatSan
            // 
            this.buttonDatSan.BackColor = System.Drawing.Color.Green;
            this.buttonDatSan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDatSan.ForeColor = System.Drawing.Color.White;
            this.buttonDatSan.Location = new System.Drawing.Point(397, 340);
            this.buttonDatSan.Name = "buttonDatSan";
            this.buttonDatSan.Size = new System.Drawing.Size(100, 40);
            this.buttonDatSan.TabIndex = 11;
            this.buttonDatSan.Text = "Đặt sân";
            this.buttonDatSan.UseVisualStyleBackColor = false;
            this.buttonDatSan.Click += new System.EventHandler(this.buttonDatSan_Click);

            // 
            // textBoxSoDienThoai
            // 
            this.textBoxSoDienThoai.Location = new System.Drawing.Point(120, 250);
            this.textBoxSoDienThoai.Name = "textBoxSoDienThoai";
            this.textBoxSoDienThoai.Size = new System.Drawing.Size(754, 20);
            this.textBoxSoDienThoai.TabIndex = 10;
            this.textBoxSoDienThoai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // labelSoDienThoai
            // 
            this.labelSoDienThoai.Font = new System.Drawing.Font("Arial", 10F);
            this.labelSoDienThoai.Location = new System.Drawing.Point(10, 250);
            this.labelSoDienThoai.Name = "labelSoDienThoai";
            this.labelSoDienThoai.Size = new System.Drawing.Size(100, 30);
            this.labelSoDienThoai.TabIndex = 9;
            this.labelSoDienThoai.Text = "Số điện thoại:";

            // 
            // textBoxTenKH
            // 
            this.textBoxTenKH.Location = new System.Drawing.Point(120, 210);
            this.textBoxTenKH.Name = "textBoxTenKH";
            this.textBoxTenKH.Size = new System.Drawing.Size(754, 20);
            this.textBoxTenKH.TabIndex = 8;
            this.textBoxTenKH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // labelTenKH
            // 
            this.labelTenKH.Font = new System.Drawing.Font("Arial", 10F);
            this.labelTenKH.Location = new System.Drawing.Point(10, 210);
            this.labelTenKH.Name = "labelTenKH";
            this.labelTenKH.Size = new System.Drawing.Size(100, 30);
            this.labelTenKH.TabIndex = 7;
            this.labelTenKH.Text = "Tên khách hàng:";

            // 
            // dateTimePickerGioKetThuc
            // 
            this.dateTimePickerGioKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerGioKetThuc.CustomFormat = "HH:mm";
            this.dateTimePickerGioKetThuc.ShowUpDown = true;
            this.dateTimePickerGioKetThuc.Location = new System.Drawing.Point(462, 170);
            this.dateTimePickerGioKetThuc.Name = "dateTimePickerGioKetThuc";
            this.dateTimePickerGioKetThuc.Size = new System.Drawing.Size(412, 20);
            this.dateTimePickerGioKetThuc.TabIndex = 6;
            this.dateTimePickerGioKetThuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // labelGioKetThuc
            // 
            this.labelGioKetThuc.Font = new System.Drawing.Font("Arial", 10F);
            this.labelGioKetThuc.Location = new System.Drawing.Point(352, 170);
            this.labelGioKetThuc.Name = "labelGioKetThuc";
            this.labelGioKetThuc.Size = new System.Drawing.Size(100, 30);
            this.labelGioKetThuc.TabIndex = 5;
            this.labelGioKetThuc.Text = "Giờ kết thúc:";

            // 
            // dateTimePickerGioBatDau
            // 
            this.dateTimePickerGioBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerGioBatDau.CustomFormat = "HH:mm";
            this.dateTimePickerGioBatDau.ShowUpDown = true;
            this.dateTimePickerGioBatDau.Location = new System.Drawing.Point(120, 170);
            this.dateTimePickerGioBatDau.Name = "dateTimePickerGioBatDau";
            this.dateTimePickerGioBatDau.Size = new System.Drawing.Size(212, 20);
            this.dateTimePickerGioBatDau.TabIndex = 4;

            // 
            // labelGioBatDau
            // 
            this.labelGioBatDau.Font = new System.Drawing.Font("Arial", 10F);
            this.labelGioBatDau.Location = new System.Drawing.Point(10, 170);
            this.labelGioBatDau.Name = "labelGioBatDau";
            this.labelGioBatDau.Size = new System.Drawing.Size(100, 30);
            this.labelGioBatDau.TabIndex = 3;
            this.labelGioBatDau.Text = "Giờ bắt đầu:";

            // 
            // dateTimePickerNgayDat
            // 
            this.dateTimePickerNgayDat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNgayDat.Location = new System.Drawing.Point(120, 90);
            this.dateTimePickerNgayDat.Name = "dateTimePickerNgayDat";
            this.dateTimePickerNgayDat.Size = new System.Drawing.Size(754, 20);
            this.dateTimePickerNgayDat.TabIndex = 2;
            this.dateTimePickerNgayDat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // labelNgayDat
            // 
            this.labelNgayDat.Font = new System.Drawing.Font("Arial", 10F);
            this.labelNgayDat.Location = new System.Drawing.Point(10, 90);
            this.labelNgayDat.Name = "labelNgayDat";
            this.labelNgayDat.Size = new System.Drawing.Size(100, 30);
            this.labelNgayDat.TabIndex = 1;
            this.labelNgayDat.Text = "Ngày đặt:";

            // 
            // comboBoxSan
            // 
            this.comboBoxSan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSan.FormattingEnabled = true;
            this.comboBoxSan.Location = new System.Drawing.Point(120, 10);
            this.comboBoxSan.Name = "comboBoxSan";
            this.comboBoxSan.Size = new System.Drawing.Size(754, 21);
            this.comboBoxSan.TabIndex = 0;
            this.comboBoxSan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // labelSan
            // 
            this.labelSan.Font = new System.Drawing.Font("Arial", 10F);
            this.labelSan.Location = new System.Drawing.Point(10, 10);
            this.labelSan.Name = "labelSan";
            this.labelSan.Size = new System.Drawing.Size(100, 30);
            this.labelSan.TabIndex = 0;
            this.labelSan.Text = "Chọn sân:";

            // 
            // DatSanControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelThongTinDatSan);
            this.Controls.Add(this.labelTitle);
            this.Name = "DatSanControl";
            this.Size = new System.Drawing.Size(934, 661);
            this.panelThongTinDatSan.ResumeLayout(false);
            this.panelThongTinDatSan.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelThongTinDatSan;
        private System.Windows.Forms.Label labelSan;
        private System.Windows.Forms.ComboBox comboBoxSan;
        private System.Windows.Forms.Label labelNgayDat;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayDat;
        private System.Windows.Forms.Label labelGioBatDau;
        private System.Windows.Forms.DateTimePicker dateTimePickerGioBatDau;
        private System.Windows.Forms.Label labelGioKetThuc;
        private System.Windows.Forms.DateTimePicker dateTimePickerGioKetThuc;
        private System.Windows.Forms.Label labelTenKH;
        private System.Windows.Forms.TextBox textBoxTenKH;
        private System.Windows.Forms.Label labelSoDienThoai;
        private System.Windows.Forms.TextBox textBoxSoDienThoai;
        private System.Windows.Forms.Button buttonDatSan;
    }
}
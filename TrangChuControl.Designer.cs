namespace QuanLySanBong
{
    partial class TrangChuControl
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
            this.flowLayoutPanelSan = new System.Windows.Forms.FlowLayoutPanel();
            this.panelThongTinDatSan = new System.Windows.Forms.Panel();
            this.dataGridViewDatSan = new System.Windows.Forms.DataGridView();
            this.labelThongTinDatSan = new System.Windows.Forms.Label();
            this.panelThongTinThanhToan = new System.Windows.Forms.Panel();
            this.buttonInHoaDon = new System.Windows.Forms.Button();
            this.pictureBoxQRCode = new System.Windows.Forms.PictureBox();
            this.buttonThanhToan = new System.Windows.Forms.Button();
            this.comboBoxPhuongThuc = new System.Windows.Forms.ComboBox();
            this.labelPhuongThuc = new System.Windows.Forms.Label();
            this.textBoxTongTien = new System.Windows.Forms.TextBox();
            this.labelTongTien = new System.Windows.Forms.Label();
            this.textBoxNguoiDat = new System.Windows.Forms.TextBox();
            this.labelNguoiDat = new System.Windows.Forms.Label();
            this.labelThongTinThanhToan = new System.Windows.Forms.Label();
            this.panelThongTinDatSan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatSan)).BeginInit();
            this.panelThongTinThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.labelTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(1101, 40);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "THÔNG TIN TRẠNG THÁI CÁC KHUNG GIỜ CỦA SÂN";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanelSan
            // 
            this.flowLayoutPanelSan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanelSan.AutoScroll = true;
            this.flowLayoutPanelSan.Location = new System.Drawing.Point(20, 60);
            this.flowLayoutPanelSan.Name = "flowLayoutPanelSan";
            this.flowLayoutPanelSan.Size = new System.Drawing.Size(400, 624);
            this.flowLayoutPanelSan.TabIndex = 1;
            // 
            // panelThongTinDatSan
            // 
            this.panelThongTinDatSan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelThongTinDatSan.BackColor = System.Drawing.Color.White;
            this.panelThongTinDatSan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelThongTinDatSan.Controls.Add(this.dataGridViewDatSan);
            this.panelThongTinDatSan.Controls.Add(this.labelThongTinDatSan);
            this.panelThongTinDatSan.Location = new System.Drawing.Point(617, 60);
            this.panelThongTinDatSan.Name = "panelThongTinDatSan";
            this.panelThongTinDatSan.Size = new System.Drawing.Size(450, 324);
            this.panelThongTinDatSan.TabIndex = 2;
            // 
            // dataGridViewDatSan
            // 
            this.dataGridViewDatSan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDatSan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDatSan.Location = new System.Drawing.Point(10, 50);
            this.dataGridViewDatSan.Name = "dataGridViewDatSan";
            this.dataGridViewDatSan.Size = new System.Drawing.Size(430, 224);
            this.dataGridViewDatSan.TabIndex = 1;
            // 
            // labelThongTinDatSan
            // 
            this.labelThongTinDatSan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.labelThongTinDatSan.Location = new System.Drawing.Point(10, 10);
            this.labelThongTinDatSan.Name = "labelThongTinDatSan";
            this.labelThongTinDatSan.Size = new System.Drawing.Size(300, 30);
            this.labelThongTinDatSan.TabIndex = 0;
            this.labelThongTinDatSan.Text = "THÔNG TIN CHI TIẾT SÂN ĐẶT";
            // 
            // panelThongTinThanhToan
            // 
            this.panelThongTinThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelThongTinThanhToan.BackColor = System.Drawing.Color.White;
            this.panelThongTinThanhToan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelThongTinThanhToan.Controls.Add(this.buttonInHoaDon);
            this.panelThongTinThanhToan.Controls.Add(this.pictureBoxQRCode);
            this.panelThongTinThanhToan.Controls.Add(this.buttonThanhToan);
            this.panelThongTinThanhToan.Controls.Add(this.comboBoxPhuongThuc);
            this.panelThongTinThanhToan.Controls.Add(this.labelPhuongThuc);
            this.panelThongTinThanhToan.Controls.Add(this.textBoxTongTien);
            this.panelThongTinThanhToan.Controls.Add(this.labelTongTien);
            this.panelThongTinThanhToan.Controls.Add(this.textBoxNguoiDat);
            this.panelThongTinThanhToan.Controls.Add(this.labelNguoiDat);
            this.panelThongTinThanhToan.Controls.Add(this.labelThongTinThanhToan);
            this.panelThongTinThanhToan.Location = new System.Drawing.Point(617, 404);
            this.panelThongTinThanhToan.Name = "panelThongTinThanhToan";
            this.panelThongTinThanhToan.Size = new System.Drawing.Size(450, 381);
            this.panelThongTinThanhToan.TabIndex = 3;
            // 
            // buttonInHoaDon
            // 
            this.buttonInHoaDon.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonInHoaDon.BackColor = System.Drawing.Color.Green;
            this.buttonInHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInHoaDon.ForeColor = System.Drawing.Color.White;
            this.buttonInHoaDon.Location = new System.Drawing.Point(320, 264);
            this.buttonInHoaDon.Name = "buttonInHoaDon";
            this.buttonInHoaDon.Size = new System.Drawing.Size(100, 40);
            this.buttonInHoaDon.TabIndex = 10;
            this.buttonInHoaDon.Text = "In hóa đơn";
            this.buttonInHoaDon.UseVisualStyleBackColor = false;
            this.buttonInHoaDon.Click += new System.EventHandler(this.buttonInHoaDon_Click);
            // 
            // pictureBoxQRCode
            // 
            this.pictureBoxQRCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBoxQRCode.Location = new System.Drawing.Point(87, 163);
            this.pictureBoxQRCode.Name = "pictureBoxQRCode";
            this.pictureBoxQRCode.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxQRCode.TabIndex = 9;
            this.pictureBoxQRCode.TabStop = false;
            // 
            // buttonThanhToan
            // 
            this.buttonThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonThanhToan.BackColor = System.Drawing.Color.Orange;
            this.buttonThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonThanhToan.ForeColor = System.Drawing.Color.White;
            this.buttonThanhToan.Location = new System.Drawing.Point(320, 180);
            this.buttonThanhToan.Name = "buttonThanhToan";
            this.buttonThanhToan.Size = new System.Drawing.Size(100, 40);
            this.buttonThanhToan.TabIndex = 8;
            this.buttonThanhToan.Text = "THANH TOÁN";
            this.buttonThanhToan.UseVisualStyleBackColor = false;
            this.buttonThanhToan.Click += new System.EventHandler(this.buttonThanhToan_Click);
            // 
            // comboBoxPhuongThuc
            // 
            this.comboBoxPhuongThuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPhuongThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPhuongThuc.FormattingEnabled = true;
            this.comboBoxPhuongThuc.Location = new System.Drawing.Point(120, 130);
            this.comboBoxPhuongThuc.Name = "comboBoxPhuongThuc";
            this.comboBoxPhuongThuc.Size = new System.Drawing.Size(300, 21);
            this.comboBoxPhuongThuc.TabIndex = 6;
            // 
            // labelPhuongThuc
            // 
            this.labelPhuongThuc.Font = new System.Drawing.Font("Arial", 10F);
            this.labelPhuongThuc.Location = new System.Drawing.Point(10, 130);
            this.labelPhuongThuc.Name = "labelPhuongThuc";
            this.labelPhuongThuc.Size = new System.Drawing.Size(100, 30);
            this.labelPhuongThuc.TabIndex = 5;
            this.labelPhuongThuc.Text = "Phương thức thanh toán:";
            // 
            // textBoxTongTien
            // 
            this.textBoxTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTongTien.Location = new System.Drawing.Point(120, 90);
            this.textBoxTongTien.Name = "textBoxTongTien";
            this.textBoxTongTien.Size = new System.Drawing.Size(300, 20);
            this.textBoxTongTien.TabIndex = 4;
            // 
            // labelTongTien
            // 
            this.labelTongTien.Font = new System.Drawing.Font("Arial", 10F);
            this.labelTongTien.Location = new System.Drawing.Point(10, 90);
            this.labelTongTien.Name = "labelTongTien";
            this.labelTongTien.Size = new System.Drawing.Size(100, 30);
            this.labelTongTien.TabIndex = 3;
            this.labelTongTien.Text = "Tổng tiền:";
            // 
            // textBoxNguoiDat
            // 
            this.textBoxNguoiDat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNguoiDat.Location = new System.Drawing.Point(120, 50);
            this.textBoxNguoiDat.Name = "textBoxNguoiDat";
            this.textBoxNguoiDat.Size = new System.Drawing.Size(300, 20);
            this.textBoxNguoiDat.TabIndex = 2;
            // 
            // labelNguoiDat
            // 
            this.labelNguoiDat.Font = new System.Drawing.Font("Arial", 10F);
            this.labelNguoiDat.Location = new System.Drawing.Point(10, 50);
            this.labelNguoiDat.Name = "labelNguoiDat";
            this.labelNguoiDat.Size = new System.Drawing.Size(100, 30);
            this.labelNguoiDat.TabIndex = 1;
            this.labelNguoiDat.Text = "Người đặt:";
            // 
            // labelThongTinThanhToan
            // 
            this.labelThongTinThanhToan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.labelThongTinThanhToan.Location = new System.Drawing.Point(10, 10);
            this.labelThongTinThanhToan.Name = "labelThongTinThanhToan";
            this.labelThongTinThanhToan.Size = new System.Drawing.Size(300, 30);
            this.labelThongTinThanhToan.TabIndex = 0;
            this.labelThongTinThanhToan.Text = "THÔNG TIN THANH TOÁN GIAO DỊCH";
            // 
            // TrangChuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelThongTinThanhToan);
            this.Controls.Add(this.panelThongTinDatSan);
            this.Controls.Add(this.flowLayoutPanelSan);
            this.Controls.Add(this.labelTitle);
            this.Name = "TrangChuControl";
            this.Size = new System.Drawing.Size(1101, 785);
            this.panelThongTinDatSan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatSan)).EndInit();
            this.panelThongTinThanhToan.ResumeLayout(false);
            this.panelThongTinThanhToan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQRCode)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSan;
        private System.Windows.Forms.Panel panelThongTinDatSan;
        private System.Windows.Forms.Label labelThongTinDatSan;
        private System.Windows.Forms.DataGridView dataGridViewDatSan;
        private System.Windows.Forms.Panel panelThongTinThanhToan;
        private System.Windows.Forms.Label labelThongTinThanhToan;
        private System.Windows.Forms.Label labelNguoiDat;
        private System.Windows.Forms.TextBox textBoxNguoiDat;
        private System.Windows.Forms.Label labelTongTien;
        private System.Windows.Forms.TextBox textBoxTongTien;
        private System.Windows.Forms.Label labelPhuongThuc;
        private System.Windows.Forms.ComboBox comboBoxPhuongThuc;
        private System.Windows.Forms.Button buttonThanhToan;
        private System.Windows.Forms.PictureBox pictureBoxQRCode;
        private System.Windows.Forms.Button buttonInHoaDon;
    }
}
namespace QuanLySanBong
{
    partial class QuanLySanControl
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
            this.dataGridViewSan = new System.Windows.Forms.DataGridView();
            this.panelThongTinSan = new System.Windows.Forms.Panel();
            this.buttonXoa = new System.Windows.Forms.Button();
            this.buttonSua = new System.Windows.Forms.Button();
            this.buttonThem = new System.Windows.Forms.Button();
            this.comboBoxTrangThai = new System.Windows.Forms.ComboBox();
            this.labelTrangThai = new System.Windows.Forms.Label();
            this.textBoxGiaThue = new System.Windows.Forms.TextBox();
            this.labelGiaThue = new System.Windows.Forms.Label();
            this.textBoxTenSan = new System.Windows.Forms.TextBox();
            this.labelTenSan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSan)).BeginInit();
            this.panelThongTinSan.SuspendLayout();
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
            this.labelTitle.Text = "QUẢN LÝ SÂN BÓNG";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // dataGridViewSan
            // 
            this.dataGridViewSan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSan.Location = new System.Drawing.Point(20, 60);
            this.dataGridViewSan.Name = "dataGridViewSan";
            this.dataGridViewSan.Size = new System.Drawing.Size(894, 200);
            this.dataGridViewSan.TabIndex = 1;
            this.dataGridViewSan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // panelThongTinSan
            // 
            this.panelThongTinSan.BackColor = System.Drawing.Color.White;
            this.panelThongTinSan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelThongTinSan.Controls.Add(this.buttonXoa);
            this.panelThongTinSan.Controls.Add(this.buttonSua);
            this.panelThongTinSan.Controls.Add(this.buttonThem);
            this.panelThongTinSan.Controls.Add(this.comboBoxTrangThai);
            this.panelThongTinSan.Controls.Add(this.labelTrangThai);
            this.panelThongTinSan.Controls.Add(this.textBoxGiaThue);
            this.panelThongTinSan.Controls.Add(this.labelGiaThue);
            this.panelThongTinSan.Controls.Add(this.textBoxTenSan);
            this.panelThongTinSan.Controls.Add(this.labelTenSan);
            this.panelThongTinSan.Location = new System.Drawing.Point(20, 270);
            this.panelThongTinSan.Name = "panelThongTinSan";
            this.panelThongTinSan.Size = new System.Drawing.Size(894, 200);
            this.panelThongTinSan.TabIndex = 2;
            this.panelThongTinSan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // buttonXoa
            // 
            this.buttonXoa.BackColor = System.Drawing.Color.Red;
            this.buttonXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonXoa.ForeColor = System.Drawing.Color.White;
            this.buttonXoa.Location = new System.Drawing.Point(690, 130);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(100, 40);
            this.buttonXoa.TabIndex = 8;
            this.buttonXoa.Text = "Xóa sân";
            this.buttonXoa.UseVisualStyleBackColor = false;
            this.buttonXoa.Click += new System.EventHandler(this.buttonXoa_Click);
            this.buttonXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // buttonSua
            // 
            this.buttonSua.BackColor = System.Drawing.Color.Orange;
            this.buttonSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSua.ForeColor = System.Drawing.Color.White;
            this.buttonSua.Location = new System.Drawing.Point(580, 130);
            this.buttonSua.Name = "buttonSua";
            this.buttonSua.Size = new System.Drawing.Size(100, 40);
            this.buttonSua.TabIndex = 7;
            this.buttonSua.Text = "Sửa sân";
            this.buttonSua.UseVisualStyleBackColor = false;
            this.buttonSua.Click += new System.EventHandler(this.buttonSua_Click);
            this.buttonSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // buttonThem
            // 
            this.buttonThem.BackColor = System.Drawing.Color.Green;
            this.buttonThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonThem.ForeColor = System.Drawing.Color.White;
            this.buttonThem.Location = new System.Drawing.Point(470, 130);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(100, 40);
            this.buttonThem.TabIndex = 6;
            this.buttonThem.Text = "Thêm sân";
            this.buttonThem.UseVisualStyleBackColor = false;
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            this.buttonThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // comboBoxTrangThai
            // 
            this.comboBoxTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTrangThai.FormattingEnabled = true;
            this.comboBoxTrangThai.Location = new System.Drawing.Point(120, 90);
            this.comboBoxTrangThai.Name = "comboBoxTrangThai";
            this.comboBoxTrangThai.Size = new System.Drawing.Size(754, 21);
            this.comboBoxTrangThai.TabIndex = 5;
            this.comboBoxTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // labelTrangThai
            // 
            this.labelTrangThai.Font = new System.Drawing.Font("Arial", 10F);
            this.labelTrangThai.Location = new System.Drawing.Point(10, 90);
            this.labelTrangThai.Name = "labelTrangThai";
            this.labelTrangThai.Size = new System.Drawing.Size(100, 30);
            this.labelTrangThai.TabIndex = 4;
            this.labelTrangThai.Text = "Trạng thái:";

            // 
            // textBoxGiaThue
            // 
            this.textBoxGiaThue.Location = new System.Drawing.Point(120, 50);
            this.textBoxGiaThue.Name = "textBoxGiaThue";
            this.textBoxGiaThue.Size = new System.Drawing.Size(754, 20);
            this.textBoxGiaThue.TabIndex = 3;
            this.textBoxGiaThue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // labelGiaThue
            // 
            this.labelGiaThue.Font = new System.Drawing.Font("Arial", 10F);
            this.labelGiaThue.Location = new System.Drawing.Point(10, 50);
            this.labelGiaThue.Name = "labelGiaThue";
            this.labelGiaThue.Size = new System.Drawing.Size(100, 30);
            this.labelGiaThue.TabIndex = 2;
            this.labelGiaThue.Text = "Giá thuê (VND/giờ):";

            // 
            // textBoxTenSan
            // 
            this.textBoxTenSan.Location = new System.Drawing.Point(120, 10);
            this.textBoxTenSan.Name = "textBoxTenSan";
            this.textBoxTenSan.Size = new System.Drawing.Size(754, 20);
            this.textBoxTenSan.TabIndex = 1;
            this.textBoxTenSan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // labelTenSan
            // 
            this.labelTenSan.Font = new System.Drawing.Font("Arial", 10F);
            this.labelTenSan.Location = new System.Drawing.Point(10, 10);
            this.labelTenSan.Name = "labelTenSan";
            this.labelTenSan.Size = new System.Drawing.Size(100, 30);
            this.labelTenSan.TabIndex = 0;
            this.labelTenSan.Text = "Tên sân:";

            // 
            // QuanLySanControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelThongTinSan);
            this.Controls.Add(this.dataGridViewSan);
            this.Controls.Add(this.labelTitle);
            this.Name = "QuanLySanControl";
            this.Size = new System.Drawing.Size(934, 661);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSan)).EndInit();
            this.panelThongTinSan.ResumeLayout(false);
            this.panelThongTinSan.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.DataGridView dataGridViewSan;
        private System.Windows.Forms.Panel panelThongTinSan;
        private System.Windows.Forms.Label labelTenSan;
        private System.Windows.Forms.TextBox textBoxTenSan;
        private System.Windows.Forms.Label labelGiaThue;
        private System.Windows.Forms.TextBox textBoxGiaThue;
        private System.Windows.Forms.Label labelTrangThai;
        private System.Windows.Forms.ComboBox comboBoxTrangThai;
        private System.Windows.Forms.Button buttonThem;
        private System.Windows.Forms.Button buttonSua;
        private System.Windows.Forms.Button buttonXoa;
    }
}
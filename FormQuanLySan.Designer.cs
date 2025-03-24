namespace QuanLySanBong
{
    partial class FormQuanLySan
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
            this.txtTenSan = new System.Windows.Forms.TextBox();
            this.txtLoaiSan = new System.Windows.Forms.TextBox();
            this.txtGiaThue = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.dgvSanBong = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanBong)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên sân";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Loại sân";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giá thuê";
            // 
            // txtTenSan
            // 
            this.txtTenSan.Location = new System.Drawing.Point(100, 27);
            this.txtTenSan.Name = "txtTenSan";
            this.txtTenSan.Size = new System.Drawing.Size(150, 20);
            this.txtTenSan.TabIndex = 3;
            // 
            // txtLoaiSan
            // 
            this.txtLoaiSan.Location = new System.Drawing.Point(100, 57);
            this.txtLoaiSan.Name = "txtLoaiSan";
            this.txtLoaiSan.Size = new System.Drawing.Size(150, 20);
            this.txtLoaiSan.TabIndex = 4;
            // 
            // txtGiaThue
            // 
            this.txtGiaThue.Location = new System.Drawing.Point(100, 87);
            this.txtGiaThue.Name = "txtGiaThue";
            this.txtGiaThue.Size = new System.Drawing.Size(150, 20);
            this.txtGiaThue.TabIndex = 5;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(30, 120);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 30);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(110, 120);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 30);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(190, 120);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 30);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // dgvSanBong
            // 
            this.dgvSanBong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanBong.Location = new System.Drawing.Point(30, 160);
            this.dgvSanBong.Name = "dgvSanBong";
            this.dgvSanBong.Size = new System.Drawing.Size(500, 250);
            this.dgvSanBong.TabIndex = 9;
            this.dgvSanBong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanBong_CellClick);
            // 
            // FormQuanLySan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 450);
            this.Controls.Add(this.dgvSanBong);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtGiaThue);
            this.Controls.Add(this.txtLoaiSan);
            this.Controls.Add(this.txtTenSan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormQuanLySan";
            this.Text = "Quản lý sân bóng";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanBong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenSan;
        private System.Windows.Forms.TextBox txtLoaiSan;
        private System.Windows.Forms.TextBox txtGiaThue;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridView dgvSanBong;
    }
}
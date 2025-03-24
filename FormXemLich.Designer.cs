namespace QuanLySanBong
{
    partial class FormXemLich
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
            this.dtpNgayXem = new System.Windows.Forms.DateTimePicker();
            this.btnXemLich = new System.Windows.Forms.Button();
            this.dgvLichDat = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichDat)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn ngày";
            // 
            // dtpNgayXem
            // 
            this.dtpNgayXem.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayXem.Location = new System.Drawing.Point(100, 27);
            this.dtpNgayXem.Name = "dtpNgayXem";
            this.dtpNgayXem.Size = new System.Drawing.Size(150, 20);
            this.dtpNgayXem.TabIndex = 1;
            // 
            // btnXemLich
            // 
            this.btnXemLich.Location = new System.Drawing.Point(260, 25);
            this.btnXemLich.Name = "btnXemLich";
            this.btnXemLich.Size = new System.Drawing.Size(80, 25);
            this.btnXemLich.TabIndex = 2;
            this.btnXemLich.Text = "Xem lịch";
            this.btnXemLich.UseVisualStyleBackColor = true;
            this.btnXemLich.Click += new System.EventHandler(this.btnXemLich_Click);
            // 
            // dgvLichDat
            // 
            this.dgvLichDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichDat.Location = new System.Drawing.Point(30, 70);
            this.dgvLichDat.Name = "dgvLichDat";
            this.dgvLichDat.Size = new System.Drawing.Size(600, 300);
            this.dgvLichDat.TabIndex = 3;
            // 
            // FormXemLich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 400);
            this.Controls.Add(this.dgvLichDat);
            this.Controls.Add(this.btnXemLich);
            this.Controls.Add(this.dtpNgayXem);
            this.Controls.Add(this.label1);
            this.Name = "FormXemLich";
            this.Text = "Xem lịch đặt sân";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichDat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNgayXem;
        private System.Windows.Forms.Button btnXemLich;
        private System.Windows.Forms.DataGridView dgvLichDat;
    }
}
namespace QuanLySanBong
{
    partial class FormXemLich
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvLichDatSan = new System.Windows.Forms.DataGridView();
            this.btnHuyLich = new System.Windows.Forms.Button();
            this.dtpNgayXem = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichDatSan)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLichDatSan
            // 
            this.dgvLichDatSan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichDatSan.Location = new System.Drawing.Point(30, 60);
            this.dgvLichDatSan.Name = "dgvLichDatSan";
            this.dgvLichDatSan.Size = new System.Drawing.Size(740, 270);
            this.dgvLichDatSan.TabIndex = 0;
            this.dgvLichDatSan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichDatSan.MultiSelect = false;
            // 
            // btnHuyLich
            // 
            this.btnHuyLich.Location = new System.Drawing.Point(670, 340);
            this.btnHuyLich.Name = "btnHuyLich";
            this.btnHuyLich.Size = new System.Drawing.Size(100, 30);
            this.btnHuyLich.TabIndex = 1;
            this.btnHuyLich.Text = "Hủy lịch";
            this.btnHuyLich.UseVisualStyleBackColor = true;
            this.btnHuyLich.Click += new System.EventHandler(this.btnHuyLich_Click);
            // 
            // dtpNgayXem
            // 
            this.dtpNgayXem.Location = new System.Drawing.Point(30, 20);
            this.dtpNgayXem.Name = "dtpNgayXem";
            this.dtpNgayXem.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayXem.TabIndex = 2;
            this.dtpNgayXem.ValueChanged += new System.EventHandler(this.dtpNgayXem_ValueChanged);
            // 
            // FormXemLich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.dtpNgayXem);
            this.Controls.Add(this.btnHuyLich);
            this.Controls.Add(this.dgvLichDatSan);
            this.Name = "FormXemLich";
            this.Text = "Xem lịch đặt sân";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichDatSan)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLichDatSan;
        private System.Windows.Forms.Button btnHuyLich;
        private System.Windows.Forms.DateTimePicker dtpNgayXem;
    }
}
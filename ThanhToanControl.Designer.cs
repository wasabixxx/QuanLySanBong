using System.Drawing;
using System.Windows.Forms;

namespace QuanLySanBong
{
    partial class ThanhToanControl
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
            this.labelSearch = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dataGridViewThanhToan = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewThanhToan)).BeginInit();
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
            this.labelTitle.Text = "LỊCH SỬ THANH TOÁN";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // labelSearch
            // 
            this.labelSearch.Font = new System.Drawing.Font("Arial", 10F);
            this.labelSearch.Location = new System.Drawing.Point(20, 50);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(150, 30);
            this.labelSearch.TabIndex = 1;
            this.labelSearch.Text = "Tìm kiếm theo mã đặt sân:";

            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(170, 50);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(600, 20);
            this.textBoxSearch.TabIndex = 2;
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.ForeColor = System.Drawing.Color.White;
            this.buttonSearch.Location = new System.Drawing.Point(780, 50);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(100, 30);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "Tìm kiếm";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // dataGridViewThanhToan
            // 

            this.dataGridViewThanhToan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dataGridViewThanhToan.BackgroundColor = Color.White;
            this.dataGridViewThanhToan.BorderStyle = BorderStyle.None;
            this.dataGridViewThanhToan.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewThanhToan.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            this.dataGridViewThanhToan.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dataGridViewThanhToan.EnableHeadersVisualStyles = false;

            this.dataGridViewThanhToan.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            this.dataGridViewThanhToan.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dataGridViewThanhToan.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            this.dataGridViewThanhToan.RowTemplate.Height = 30; // tăng chiều cao dòng

            this.dataGridViewThanhToan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewThanhToan.Location = new System.Drawing.Point(20, 90);
            this.dataGridViewThanhToan.Name = "dataGridViewThanhToan";
            this.dataGridViewThanhToan.Size = new System.Drawing.Size(860, 540);
            this.dataGridViewThanhToan.TabIndex = 4;
            this.dataGridViewThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // ThanhToanControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewThanhToan);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.labelTitle);
            this.Name = "ThanhToanControl";
            this.Size = new System.Drawing.Size(934, 661);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewThanhToan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridView dataGridViewThanhToan;
    }
}
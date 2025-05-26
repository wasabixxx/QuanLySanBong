using System.Drawing;
using System.Windows.Forms;

namespace QuanLySanBong
{
    partial class DoanhThuControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelTongDoanhThu = new System.Windows.Forms.Label();
            this.dataGridViewDoanhThu = new System.Windows.Forms.DataGridView();
            this.labelThang = new System.Windows.Forms.Label();
            this.comboBoxThang = new System.Windows.Forms.ComboBox();
            this.labelNam = new System.Windows.Forms.Label();
            this.comboBoxNam = new System.Windows.Forms.ComboBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDoanhThu)).BeginInit();
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
            this.labelTitle.Size = new System.Drawing.Size(934, 40);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "TỔNG HỢP DOANH THU";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTongDoanhThu
            // 
            this.labelTongDoanhThu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTongDoanhThu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTongDoanhThu.Location = new System.Drawing.Point(10, 50);
            this.labelTongDoanhThu.Name = "labelTongDoanhThu";
            this.labelTongDoanhThu.Size = new System.Drawing.Size(400, 25);
            this.labelTongDoanhThu.TabIndex = 1;
            this.labelTongDoanhThu.Text = "Tổng doanh thu: 0 VNĐ";
            // 
            // dataGridViewDoanhThu
            // 
            this.dataGridViewDoanhThu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDoanhThu.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewDoanhThu.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDoanhThu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDoanhThu.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewDoanhThu.EnableHeadersVisualStyles = false;
            this.dataGridViewDoanhThu.Location = new System.Drawing.Point(13, 431);
            this.dataGridViewDoanhThu.Name = "dataGridViewDoanhThu";
            this.dataGridViewDoanhThu.RowTemplate.Height = 30;
            this.dataGridViewDoanhThu.Size = new System.Drawing.Size(400, 200);
            this.dataGridViewDoanhThu.TabIndex = 2;
            // 
            // labelThang
            // 
            this.labelThang.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelThang.AutoSize = true;
            this.labelThang.Location = new System.Drawing.Point(10, 80);
            this.labelThang.Name = "labelThang";
            this.labelThang.Size = new System.Drawing.Size(41, 13);
            this.labelThang.TabIndex = 3;
            this.labelThang.Text = "Tháng:";
            // 
            // comboBoxThang
            // 
            this.comboBoxThang.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBoxThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxThang.Location = new System.Drawing.Point(70, 80);
            this.comboBoxThang.Name = "comboBoxThang";
            this.comboBoxThang.Size = new System.Drawing.Size(50, 21);
            this.comboBoxThang.TabIndex = 4;
            // 
            // labelNam
            // 
            this.labelNam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelNam.AutoSize = true;
            this.labelNam.Location = new System.Drawing.Point(130, 80);
            this.labelNam.Name = "labelNam";
            this.labelNam.Size = new System.Drawing.Size(32, 13);
            this.labelNam.TabIndex = 5;
            this.labelNam.Text = "Năm:";
            // 
            // comboBoxNam
            // 
            this.comboBoxNam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBoxNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNam.Location = new System.Drawing.Point(180, 80);
            this.comboBoxNam.Name = "comboBoxNam";
            this.comboBoxNam.Size = new System.Drawing.Size(70, 21);
            this.comboBoxNam.TabIndex = 6;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSearch.BackColor = System.Drawing.Color.Green;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.ForeColor = System.Drawing.Color.White;
            this.buttonSearch.Location = new System.Drawing.Point(13, 123);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(80, 25);
            this.buttonSearch.TabIndex = 7;
            this.buttonSearch.Text = "Tìm kiếm";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // DoanhThuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.comboBoxNam);
            this.Controls.Add(this.labelNam);
            this.Controls.Add(this.comboBoxThang);
            this.Controls.Add(this.labelThang);
            this.Controls.Add(this.dataGridViewDoanhThu);
            this.Controls.Add(this.labelTongDoanhThu);
            this.Controls.Add(this.labelTitle);
            this.Name = "DoanhThuControl";
            this.Size = new System.Drawing.Size(934, 661);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDoanhThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelTongDoanhThu;
        private System.Windows.Forms.DataGridView dataGridViewDoanhThu;
        private System.Windows.Forms.Label labelThang;
        private System.Windows.Forms.ComboBox comboBoxThang;
        private System.Windows.Forms.Label labelNam;
        private System.Windows.Forms.ComboBox comboBoxNam;
        private System.Windows.Forms.Button buttonSearch;
    }
}
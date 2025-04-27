using System.Drawing;
using System.Windows.Forms;

namespace QuanLySanBong
{
    partial class XemLichControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelLocLich = new System.Windows.Forms.Panel();
            this.buttonXemLich = new System.Windows.Forms.Button();
            this.dateTimePickerNgayXem = new System.Windows.Forms.DateTimePicker();
            this.comboBoxSan = new System.Windows.Forms.ComboBox();
            this.dataGridViewLichDat = new System.Windows.Forms.DataGridView();
            this.buttonHuyDat = new System.Windows.Forms.Button();
            this.panelLocLich.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLichDat)).BeginInit();
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
            this.labelTitle.Size = new System.Drawing.Size(1494, 40);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "XEM LỊCH ĐẶT SÂN";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelLocLich
            // 
            this.panelLocLich.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLocLich.BackColor = System.Drawing.Color.White;
            this.panelLocLich.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLocLich.Controls.Add(this.buttonXemLich);
            this.panelLocLich.Controls.Add(this.dateTimePickerNgayXem);
            this.panelLocLich.Controls.Add(this.comboBoxSan);
            this.panelLocLich.Location = new System.Drawing.Point(20, 60);
            this.panelLocLich.Name = "panelLocLich";
            this.panelLocLich.Size = new System.Drawing.Size(1454, 126);
            this.panelLocLich.TabIndex = 1;
            // 
            // buttonXemLich
            // 
            this.buttonXemLich.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonXemLich.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.buttonXemLich.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonXemLich.ForeColor = System.Drawing.Color.White;
            this.buttonXemLich.Location = new System.Drawing.Point(1349, 41);
            this.buttonXemLich.Name = "buttonXemLich";
            this.buttonXemLich.Size = new System.Drawing.Size(100, 40);
            this.buttonXemLich.TabIndex = 4;
            this.buttonXemLich.Text = "Xem lịch";
            this.buttonXemLich.UseVisualStyleBackColor = false;
            this.buttonXemLich.Click += new System.EventHandler(this.buttonXemLich_Click);
            // 
            // dateTimePickerNgayXem
            // 
            this.dateTimePickerNgayXem.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNgayXem.Location = new System.Drawing.Point(106, 61);
            this.dateTimePickerNgayXem.Name = "dateTimePickerNgayXem";
            this.dateTimePickerNgayXem.Size = new System.Drawing.Size(304, 20);
            this.dateTimePickerNgayXem.TabIndex = 3;
            // 
            // comboBoxSan
            // 
            this.comboBoxSan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSan.FormattingEnabled = true;
            this.comboBoxSan.Location = new System.Drawing.Point(106, 14);
            this.comboBoxSan.Name = "comboBoxSan";
            this.comboBoxSan.Size = new System.Drawing.Size(304, 21);
            this.comboBoxSan.TabIndex = 1;
            // 
            // dataGridViewLichDat
            // 
            this.dataGridViewLichDat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLichDat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLichDat.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLichDat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewLichDat.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLichDat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLichDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewLichDat.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewLichDat.EnableHeadersVisualStyles = false;
            this.dataGridViewLichDat.Location = new System.Drawing.Point(20, 229);
            this.dataGridViewLichDat.Name = "dataGridViewLichDat";
            this.dataGridViewLichDat.RowTemplate.Height = 30;
            this.dataGridViewLichDat.Size = new System.Drawing.Size(1454, 405);
            this.dataGridViewLichDat.TabIndex = 2;
            // 
            // buttonHuyDat
            // 
            this.buttonHuyDat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHuyDat.BackColor = System.Drawing.Color.Red;
            this.buttonHuyDat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHuyDat.ForeColor = System.Drawing.Color.White;
            this.buttonHuyDat.Location = new System.Drawing.Point(1374, 661);
            this.buttonHuyDat.Name = "buttonHuyDat";
            this.buttonHuyDat.Size = new System.Drawing.Size(100, 40);
            this.buttonHuyDat.TabIndex = 3;
            this.buttonHuyDat.Text = "Hủy đặt";
            this.buttonHuyDat.UseVisualStyleBackColor = false;
            this.buttonHuyDat.Click += new System.EventHandler(this.buttonHuyDat_Click);
            // 
            // XemLichControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonHuyDat);
            this.Controls.Add(this.dataGridViewLichDat);
            this.Controls.Add(this.panelLocLich);
            this.Controls.Add(this.labelTitle);
            this.Name = "XemLichControl";
            this.Size = new System.Drawing.Size(1494, 825);
            this.panelLocLich.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLichDat)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelLocLich;
        private System.Windows.Forms.ComboBox comboBoxSan;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayXem;
        private System.Windows.Forms.Button buttonXemLich;
        private System.Windows.Forms.DataGridView dataGridViewLichDat;
        private System.Windows.Forms.Button buttonHuyDat;
    }
}
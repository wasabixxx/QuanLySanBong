namespace YourNamespace
{
    partial class FormSplash
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelPercent;
        private System.Windows.Forms.PictureBox pictureBoxBackground;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelPercent = new System.Windows.Forms.Label();
            this.pictureBoxBackground = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.RosyBrown;
            this.progressBar1.Location = new System.Drawing.Point(86, 321);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(514, 22);
            this.progressBar1.TabIndex = 0;
            // 
            // labelPercent
            // 
            this.labelPercent.AutoSize = true;
            this.labelPercent.BackColor = System.Drawing.Color.Black;
            this.labelPercent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPercent.ForeColor = System.Drawing.Color.White;
            this.labelPercent.Location = new System.Drawing.Point(558, 297);
            this.labelPercent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(33, 21);
            this.labelPercent.TabIndex = 1;
            this.labelPercent.Text = "0%";
            // 
            // pictureBoxBackground
            // 
            this.pictureBoxBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxBackground.Image = global::QuanLySanBong.Properties.Resources._13307081;
            this.pictureBoxBackground.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBackground.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxBackground.Name = "pictureBoxBackground";
            this.pictureBoxBackground.Size = new System.Drawing.Size(686, 390);
            this.pictureBoxBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBackground.TabIndex = 2;
            this.pictureBoxBackground.TabStop = false;
            // 
            // FormSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.labelPercent);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBoxBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading...";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

using System;
using System.Windows.Forms;
using QuanLySanBong;

namespace YourNamespace
{
    public partial class FormSplash : Form
    {
        Timer timer;

        public FormSplash()
        {
            InitializeComponent();
            StartTimer();
        }

        private void StartTimer()
        {
            timer = new Timer();
            timer.Interval = 30; // mỗi 30ms tăng 1%
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 1;
                labelPercent.Text = progressBar1.Value.ToString() + "%";
            }
            else
            {
                timer.Stop();
                this.Hide();
                FormLogin loginForm = new FormLogin();
                loginForm.Show();
            }
        }
    }
}

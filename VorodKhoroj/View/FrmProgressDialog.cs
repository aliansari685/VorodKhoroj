namespace VorodKhoroj.View
{
    public partial class FrmProgressDialog : Form
    {
        public FrmProgressDialog(int count)
        {
            InitializeComponent();
            ControlBox = false;
            progressBar1.Maximum = count;
        }
        public FrmProgressDialog()
        {
            InitializeComponent();
            ControlBox = false;
            progressBar1.Style = ProgressBarStyle.Marquee;
            lbl_percent.Visible = false;
        }
        public void SetValue(int value)
        {
            //بررسی می‌کنه که آیا در ترد درست (UI thread) هستی یا نه
            if (InvokeRequired)//thread-safe
            {
                Invoke(() => SetValue(value));
            }
            else
            {
                progressBar1.Value = value;
                lbl_percent.Text = $"{(value * 100) / progressBar1.Maximum}%";
            }
        }
    }
}

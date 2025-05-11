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

        public void SetValue(int value)
        {

            if (InvokeRequired)
            {
                Invoke(() => SetValue(value));
            }
            else
            {
                progressBar1.Value = value;
                lbl_percent.Text = $"{(value * 100) / progressBar1.Maximum}%";
            }

            //var index = value;
            //Invoke(() => { lbl_percent.Text = (progressBar1.Value = index).ToString(); });
        }
    }
}

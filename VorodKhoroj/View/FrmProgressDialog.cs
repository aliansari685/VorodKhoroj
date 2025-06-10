namespace VorodKhoroj.View
{
    /// <summary>
    /// فرم نمایش پیشرفت عملیات و نمودار پردازش
    /// </summary>
    public partial class FrmProgressDialog : Form
    {
        #region Constructors

        /// <summary>
        /// سازنده برای نمایش درصدی پیشرفت
        /// </summary>
        /// <param name="count">مقدار نهایی ProgressBar</param>
        public FrmProgressDialog(int count)
        {
            InitializeComponent();
            progressBar1.Maximum = count;
        }

        /// <summary>
        /// سازنده برای حالت Marquee (بدون درصد)
        /// </summary>
        public FrmProgressDialog()
        {
            InitializeComponent();
            progressBar1.Style = ProgressBarStyle.Marquee;
            lbl_percent.Visible = false;
        }
        #endregion

        #region Core Logic

        /// <summary>
        /// تنظیم مقدار ProgressBar همراه با آپدیت درصد به صورت ایمن در UI Thread
        /// </summary>
        /// <param name="value">مقدار فعلی پیشرفت</param>
        public void SetValue(int value)
        {
            if (InvokeRequired)
                Invoke(() => SetValue(value));
            else
            {
                progressBar1.Value = value;
                lbl_percent.Text = $"{(value * 100) / progressBar1.Maximum}%";
            }
        }
        #endregion
    }
}
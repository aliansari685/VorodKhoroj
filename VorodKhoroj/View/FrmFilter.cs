namespace VorodKhoroj.View
{
    public partial class FrmFilter : Form
    {
        private readonly AppServices _services;

        public FrmFilter(AppServices service)
        {
            _services = service;
            InitializeComponent();
        }

        private void btn_applyfilter_Click(object sender, EventArgs e)
        {
            try
            {
                using (FrmCalc frm = new(_services))
                {
                    frm.userid = userid_txtbox.Text;
                    frm.FromDateTime = FromDateTime_txtbox.Text;
                    frm.toDateTime = toDateTime_txtbox.Text;
                    frm.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            FromDateTime_txtbox.Text = userid_txtbox.Text = "";
            toDateTime_txtbox.Text = PersianDateHelper.PersianCalenderDateNow();
        }
    }
}

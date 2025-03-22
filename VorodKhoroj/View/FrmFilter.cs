using System.Data;

namespace VorodKhoroj.View
{
    public partial class FrmFilter : Form
    {
        public FrmFilter()
        {
            InitializeComponent();
        }

        private void btn_applyfilter_Click(object sender, EventArgs e)
        {
            try
            {
                using (FrmCalc frm=new())
                {
                    frm.userid = userid_txtbox.Text;
                    frm.FromDateTime = FromDateTime_txtbox.Text;
                    frm.toDateTime = toDateTime_txtbox.Text;
                    frm.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmFilter_Load(object sender, EventArgs e)
        {
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            FromDateTime_txtbox.Text = userid_txtbox.Text = "";
            toDateTime_txtbox.Text = CommonHelpers.PersianCalenderDateNow();
        }
    }
}

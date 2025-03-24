using VorodKhoroj.Data;

namespace VorodKhoroj
{
    public partial class Frm_Main : Form
    {
        internal AppServices Services { get; set; }
        private Attendance[] _array;
        private DataTable _temp;

        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            TextBoxClear();
            Services = new AppServices();
        }
        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var OpenFile = new OpenFileDialog { Filter = @"Output Files|*.txt;*.dat;" })
            {
                try
                {
                    if (OpenFile.ShowDialog() == DialogResult.OK)
                    {
                        Services.LoadRecordsFromFile(OpenFile.FileName);
                        userid_txtbox.Items.AddRange(_array = Services.Records.DistinctBy(x => x.UserId).ToArray());

                        DataGridConfig();
                    }
                }
                catch (Exception ex)
                {
                    CommonHelper.ShowMessage(ex);
                }
            }
        }

        private void DataGridConfig()
        {
            dataView.DataSource = _temp?.Rows?.Count == 0 || _temp == null
                ? _temp = Services.Records.ToDataTable()
                : _temp;
            DataGridViewConfig();
        }

        private void DataGridViewConfig()
        {
            dataView.Columns[0].HeaderText = "کاربر";
            dataView.Columns[1].HeaderText = "تاریخ و زمان ورود";
            dataView.Columns[2].HeaderText = " نوع ورود";
            dataView.Columns[1].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
        }

        private void Btn_ApplyFilter_Click(object sender, EventArgs e)
        {
            if (dataView.Rows.Count == 0) return;

            try
            {
                dataView.DataSource = DataFilterService.ApplyFilter(Services.Records, FromDateTime_txtbox.Text, toDateTime_txtbox.Text, int.Parse(userid_txtbox.Text)).ToDataTable();
                DataGridViewConfig();
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            TextBoxClear();
            DataGridConfig();
        }

        private void TextBoxClear()
        {
            FromDateTime_txtbox.Text = userid_txtbox.Text = "";
            toDateTime_txtbox.Text = PersianDateHelper.PersianCalenderDateNow();
        }

        private void MajmoEkhtelafToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataView.Rows.Count == 0) throw new ArgumentNullException("داده ای وجود ندارد");

                using (FrmFilter frm = new(Services))
                {
                    frm.FromDateTime_txtbox.Text = this.FromDateTime_txtbox.Text;
                    frm.toDateTime_txtbox.Text = this.toDateTime_txtbox.Text;
                    frm.userid_txtbox.Items.AddRange(_array);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }

        }
        private void dataView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataView.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(@"آیا می‌خواهید از برنامه خارج شوید؟", "خروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Services?.Dispose();
            }
        }

        private void DBConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataView.Rows.Count == 0) throw new ArgumentNullException("داده ای وجود ندارد");

                using (FrmSetting frm = new(Services))
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }

        }

        private void SwitchDataSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

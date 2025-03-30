namespace VorodKhoroj;

public partial class Frm_Main : Form
{
    private readonly AppServices _services;
    public Attendance[] Array;
    private DataTable _temp;

    public Frm_Main(AppServices services)
    {
        InitializeComponent();
        _services = services;
    }

    private void Frm_Main_Load(object sender, EventArgs e)
    {
        TextBoxClear();
    }

    public void DataGridConfig()
    {
        if (_services.Records == null) return;

        dataView.DataSource = _temp?.Rows?.Count == 0 || _temp == null
            ? _temp = _services?.Records?.ToDataTable()
            : _temp;
        DataGridViewConfig();
        userid_txtbox.Items.AddRange(Array = _services.Records.DistinctBy(x => x.UserId).ToArray());

    }

    private void DataGridViewConfig()
    {
        dataView.Columns[0].HeaderText = "کاربر";
        dataView.Columns[1].HeaderText = "تاریخ و زمان ورود و خروج";
        dataView.Columns[2].HeaderText = " نوع ورود";
        dataView.Columns[1].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
    }

    private void Btn_ApplyFilter_Click(object sender, EventArgs e)
    {
        if (_services.Records == null) return;

        try
        {
            DataGridConfig();
            dataView.DataSource = DataFilterService.ApplyFilter(_services.Records, FromDateTime_txtbox.Text,
                toDateTime_txtbox.Text, int.Parse(userid_txtbox.Text)).ToDataTable();
            DataGridViewConfig();
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }

    private void btn_clear_Click(object sender, EventArgs e)
    {
        foreach (var var in PersianDateHelper.GetWorkDays_Farvardin())
        {
            MessageBox.Show(var.ToShortDateString());
        }
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
            if (_services?.Records?.Count == 0) throw new ArgumentNullException("داده ای وجود ندارد");

            using (FrmFilter frm = new(_services))
            {
                frm.FromDateTime_txtbox.Text = FromDateTime_txtbox.Text;
                frm.toDateTime_txtbox.Text = toDateTime_txtbox.Text;
                frm.userid_txtbox.Items.AddRange(Array);
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
        //if (MessageBox.Show(@"آیا می‌خواهید از برنامه خارج شوید؟", "خروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        //{
        //    e.Cancel = true;
        //}
        //else
        {
            _services?.Dispose();
        }
    }

    private void DBConfigToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (dataView.Rows.Count == 0) throw new ArgumentNullException("داده ای وجود ندارد");

            using (FrmSetting frm = new(_services))
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
        try
        {
            using (FrmSetSource frm = new(_services))
            {
                frm.ShowDialog();
            }

            DataGridConfig();
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }

    private void راهاندازیمجددToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Application.Restart();
    }

    private void گزارشماهانهToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }
}
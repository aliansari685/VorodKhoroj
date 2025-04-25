namespace VorodKhoroj;

public partial class FrmMain : Form
{
    private bool _isRestarting = false;
    private readonly AppServices _services;
    private readonly AttendanceCalculationService _calcServices;

    public FrmMain(AppServices services, AttendanceCalculationService calculationService)
    {
        InitializeComponent();
        _services = services;
        _calcServices = calculationService;
    }

    private void Frm_Main_Load(object sender, EventArgs e)
    {
        TextBoxClear();
    }

    public void DataGridConfig()
    {
        if (CommonHelper.IsValid(_services.Records.Count) == false) return;

        dataView.DataSource = _services.TempDataTable;
        DataGridViewConfig();
        Userid_txtbox.DataSource = _services.GetUsers();

    }

    private void DataGridViewConfig()
    {
        dataView.Columns[2].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";

        dataView.Columns["User"].Visible = false;
        new Attendance().SetDisplayNameInDataGrid(dataView);
    }

    private void Btn_ApplyFilter_Click(object sender, EventArgs e)
    {
        try
        {
            if (CommonHelper.IsValid(_services.Records.Count) == false)
                throw new NullReferenceException("داده ای وجود ندارد");

            dataView.DataSource = DataFilterService.ApplyFilter(_services.Records, FromDateTime_txtbox.Text,
                toDateTime_txtbox.Text, int.Parse(Userid_txtbox.Text)).ToList().ToDataTable();
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
        FromDateTime_txtbox.Text = Userid_txtbox.Text = "";
        toDateTime_txtbox.Text = PersianDateHelper.PersianCalenderDateNow();
    }

    private void DetailReportToolStripMenuItem_Click(object sender, EventArgs e) //Go To FrmFilter:
    {
        try
        {
            if (CommonHelper.IsValid(_services.Records.Count) == false) throw new ArgumentNullException($"داده ای وجود ندارد");

            using FrmFilter frm = new(_services, _calcServices, FromDateTime_txtbox.Text, toDateTime_txtbox.Text, Userid_txtbox.Text);
            frm.ShowDialog();
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }

    public void dataView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
    {
        dataView.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
    }


    private void DBConfigToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (CommonHelper.IsValid(dataView.Rows.Count) == false) throw new ArgumentNullException($"داده ای وجود ندارد");

            using FrmSetting frm = new(_services);
            frm.ShowDialog();
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
                dataView.DataSource = null;
                frm.ShowDialog();
            }

            DataGridConfig();
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }

    private void MonthlyReportToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using FrmFilter_Monthly frm = new(_services, _calcServices, Userid_txtbox.Text);
        frm.ShowDialog();
    }

    private void FastExportToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (CommonHelper.IsValid(_services.Records.Count) == false) throw new ArgumentNullException($"داده ای وجود ندارد");

            var date = $"{PersianDateHelper.PersianCalendar.GetYear(DateTime.Now)}/{PersianDateHelper.PersianCalendar.GetMonth(DateTime.Now):D2}/{(PersianDateHelper.PersianCalendar.GetDayOfMonth(DateTime.Now) - 1):D2}";

            using FrmFilter frm = new(_services, _calcServices, date, date, Userid_txtbox.Text, true);
            frm.ShowDialog();
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }
    private void AppRestartToolStripMenuItem_Click(object sender, EventArgs e)
    {
        _isRestarting = true;
        Application.Restart();
    }
    private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (_isRestarting) return;

        if (MessageBox.Show(@"آیا می‌خواهید از برنامه خارج شوید؟", @"خروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        {
            e.Cancel = true;
        }
    }

    private void UsersEditToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }
}
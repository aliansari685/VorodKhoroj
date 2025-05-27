namespace VorodKhoroj;

public partial class FrmMain : Form
{
    private bool _isRestarting;
    private readonly AppCoordinator _services;
    private readonly AttendanceFullCalculationService _calcServices;

    public FrmMain(AppCoordinator services, AttendanceFullCalculationService calculationService)
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
        if (!CommonHelper.IsValid(_services.DataLoaderCoordinator.Records.Count)) return;

        dataView.DataSource = _services.DataLoaderCoordinator.Records.ToDataTableWithDisplayedName();

        Userid_txtbox.DataSource = _services.DataLoaderCoordinator.UsersList;

        if (_services is { DataLoaderCoordinator.UserListProvider: DbProvider })
        {
            CommonItems.SetDisplayAndValueMemberComboBox(ref Userid_txtbox);
        }
        DataGridViewConfig();
    }

    private void DataGridViewConfig()
    {
        dataView.Columns[2].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";

        if (dataView.Columns[nameof(Attendance.Id)] is not null and var dV)
        {
            dV.Visible = false;
        }
    }

    private void Btn_ApplyFilter_Click(object sender, EventArgs e)
    {
        try
        {
            if (CommonHelper.IsValid(_services.DataLoaderCoordinator.Records.Count) == false)
                throw new NullReferenceException("داده ای وجود ندارد");

            dataView.DataSource = DataFilterService.ApplyFilter(_services.DataLoaderCoordinator.Records, FromDateTime_txtbox.Text,
                toDateTime_txtbox.Text, int.Parse(CommonItems.GetUserIdValueToString(Userid_txtbox))).ToList().ToDataTableWithDisplayedName();

            DataGridViewConfig();
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }

    private void btn_clear_Click(object sender, EventArgs e)
    {
        ReloadGrid();
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
            if (CommonHelper.IsValid(_services.DataLoaderCoordinator.Records.Count) == false) throw new ArgumentNullException($"داده ای وجود ندارد");

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
            if (CommonHelper.IsValid(_services.DataLoaderCoordinator.Records.Count) == false) throw new ArgumentNullException($"داده ای وجود ندارد");

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
        if (_services is { DataLoaderCoordinator.UserListProvider: DbProvider, DataLoaderCoordinator.DbContext: not null })
        {
            using var frm = new FrmUsers(_services);
            frm.ShowDialog();
            ReloadGrid();
        }
        else
        {
            CommonHelper.ShowMessage("پایگاه داده وجود ندارد . لطفا منبع داده ها رو پایگاه داده انتخاب کنید");
        }

    }

    private void AttendanceEditToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (_services is { DataLoaderCoordinator.DbContext: not null, DataLoaderCoordinator.UserListProvider: DbProvider, DataLoaderCoordinator.Records.Count: not 0 })
        {
            using var frm = new FrmAttendance(_services, _calcServices);
            frm.ShowDialog();
            ReloadGrid();
        }
        else
        {
            CommonHelper.ShowMessage("پایگاه داده وجود ندارد . لطفا منبع داده ها رو پایگاه داده انتخاب کنید");
        }
    }

    private void AddAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (_services is { DataLoaderCoordinator.DbContext: not null, DataLoaderCoordinator.UserListProvider: DbProvider, DataLoaderCoordinator.Records.Count: not 0 })
        {
            using var frm = new FrmAttendanceAddRange(_services);
            frm.ShowDialog();

            ReloadGrid();
        }
        else
        {
            CommonHelper.ShowMessage("پایگاه داده وجود ندارد . لطفا منبع داده ها رو پایگاه داده انتخاب کنید");
        }
    }

    private void ReloadGrid()
    {
        TextBoxClear();
        DataGridConfig();
    }
}
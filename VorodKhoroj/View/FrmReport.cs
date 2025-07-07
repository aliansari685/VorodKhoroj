namespace VorodKhoroj.View;

/// <summary>
/// فرم محاسبه گزارش‌های ورود و خروج.
/// </summary>
public partial class FrmReport : Form
{
    #region Fields
    public enum XGridExport
    {
        None, LateGrid, CalculateGrid
    }
    private readonly MainCoordinator _appCoordinator;
    private readonly AttendanceFullCalculationService _calcServices;

    private readonly string _fromDateTime;
    private readonly string _toDateTime;
    private string _username = "";
    private string _userid;
    #endregion

    #region Form Event
    /// <summary>
    /// سازنده فرم محاسبه.
    /// </summary>
    public FrmReport(MainCoordinator mainCoordinator, AttendanceFullCalculationService calcServices, string fromDateTime,
        string toDateTime, string userid)
    {
        InitializeComponent();
        _appCoordinator = mainCoordinator;
        _calcServices = calcServices;
        _fromDateTime = fromDateTime;
        _toDateTime = toDateTime;
        _userid = userid;
    }

    private void FrmCalc_Load(object sender, EventArgs e) => Configure();

    private void checkBox_ApplyStyles_CheckedChanged(object sender, EventArgs e) => dataView_Calculate.Invalidate();

    private void checkBox_AutoEdit_CheckedChanged(object sender, EventArgs e) => ReloadData();

    //دکمه اعمال شرط ها در تب تنظیم شرطها
    private void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            _calcServices
                .WithLateTime(TimeSpan.Parse(txtbox_late.Text))
                .WithFullWorkTime(TimeSpan.Parse(txtbox_fullwork.Text))
                .WithFullWorkThursdayTime(TimeSpan.Parse(txtbox_fullwork_thursday.Text))
                .WithFullWorkFarvardinTime(TimeSpan.Parse(txtbox_fullwork_farvardin.Text))
                .WithFullWorkRamadanTime(TimeSpan.Parse(txtbox_fullwork_ramadan.Text))
                .WithinCompleteWorkTime(TimeSpan.Parse(txtbox_incomplete_normal.Text))
                .WithinCompleteWorkThursdayTime(TimeSpan.Parse(txtbox_incomplete_thrusday.Text))
                .WithinCompleteWorkFarvardinTime(TimeSpan.Parse(txtbox_incomplete_farvardin.Text))
                .WithinCompleteWorkRamadanTime(TimeSpan.Parse(txtbox_incomplete_ramazan.Text));

            ReloadGrid();
            CommonHelper.ShowMessage("انجام شد");
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }

    private void btn_next_Click(object sender, EventArgs e) => ChangeUser(true);

    private void btn_perv_Click(object sender, EventArgs e) => ChangeUser(false);

    private void OutputExcelToolStripMenuItem_Click(object sender, EventArgs e) => CalculateGridToExcel();

    private void userid_txtBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyData == Keys.Enter) ReloadData();
    }
    //اضافه کردن ستون شمارش ردیف ها 
    private void DataViewCalculateRowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
    {
        var data = (DataGridView)sender;
        data.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
    }
    //اعمال رنگ ها روی ردیف ها به‌صورت لحظه ای
    private void DataViewCalculateRowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        try
        {
            if (dataView_Calculate?.Rows.Count > e.RowIndex)
            {
                var row = dataView_Calculate.Rows[e.RowIndex];

                if (row.Cells[nameof(WorkRecord.IsLate)]?.Value is true && checkBox_Islate.Checked)
                    row.DefaultCellStyle.BackColor = Color.Red;
                else if (row.Cells[nameof(WorkRecord.IsNaghes)]?.Value is true && checkBox_Isincomplete.Checked)
                    row.DefaultCellStyle.BackColor = Color.Orange;
                else if (checkBox_workinholiday.Checked && DateTime.TryParse(row.Cells[nameof(WorkRecord.Date)]?.Value?.ToString(), out var date)
                         && _calcServices.OverTimeHolidayList.Contains(date))
                    row.DefaultCellStyle.BackColor = Color.CadetBlue;
                else
                    row.DefaultCellStyle.BackColor = Color.White;
            }
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }
    #endregion

    #region Core Logic
    /// <summary>
    /// راه اندازی فرم
    /// </summary>
    public void Configure()
    {
        userid_txtbox.DataSource = _appCoordinator.UsersList;

        if (_appCoordinator.UsersListProvider is DbProvider)
            CommonItems.SetDisplayAndValueMemberComboBox(ref userid_txtbox);

        ReloadGrid();

        if (dataView_Calculate.DataSource == null)
            Close();
    }

    /// <summary>
    ///درصورتی که فرم فقط برای ساخت اکسل صدا زده شود بدون نمایش آن متیونید از این متد استفاده کنید
    /// </summary>
    public void ExportToExcel(XGridExport gridExport)
    {
        switch (gridExport)
        {
            case XGridExport.CalculateGrid:
                {
                    CalculateGridToExcel();
                    Close();
                    break;
                }

            case XGridExport.LateGrid:
                {
                    LateGridToExcel();
                    Close();
                    break;
                }
        }
    }
    /// <summary>
    /// خروجی اکسل دیتاگرید تاخیر و مرخصی
    /// </summary>
    public void LateGridToExcel()
    {
        try
        {
            DataExporter.ExportDataGrid(dataView_late);
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }
    private void CalculateGridToExcel()
    {
        try
        {
            _calcServices.TitleReport = $"{_fromDateTime} -- {_toDateTime} \t\t User:{userid_txtbox.DisplayMember}";
            DataExporter.ExportDataGrid(dataView_Calculate, _calcServices.GetDataWithTitle(), _calcServices.TitleReport);
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }

    /// <summary>
    /// تغییر کاربر جاری و بارگذاری مجدد داده‌ها.
    /// </summary>
    private void ChangeUser(bool plusNumber)
    {
        try
        {
            if (_appCoordinator is { UsersList: null }) return;

            List<int> users = [];
            switch (_appCoordinator)
            {
                case { UsersListProvider: DbProvider, DbContext: not null }:
                    users.AddRange((_appCoordinator.UsersList as List<User> ?? []).Select(u => u.UserId));
                    break;
                case { UsersListProvider: FileProvider }:
                    users = (_appCoordinator.UsersList as int[])?.ToList() ?? [];
                    break;
            }

            if (!int.TryParse(_userid, out var currentId)) return;
            var currentIndex = users.IndexOf(currentId);
            if (currentIndex == -1) return;

            var nextIndex = plusNumber ? currentIndex + 1 : currentIndex - 1;
            if (nextIndex < 0 || nextIndex >= users.Count) return;

            _userid = users[nextIndex].ToString();
            ReloadGrid();

            CommonHelper.ShowMessage("انجام شد");
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }
    /// <summary>
    /// پرسیدن ایا داده ها دوباره بروز شود؟
    /// </summary>
    private void ReloadData()
    {
        if (MessageBox.Show("آیا از کار خود اطمینان دارید؟", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            _userid = CommonItems.GetUserIdValueToString(userid_txtbox);
            ReloadGrid();
            CommonHelper.ShowMessage("انجام شد");
        }
    }
    /// <summary>
    /// عملیات بروزرسانی داده در دیتاگرید و نمایش آن
    /// </summary>
    private void ReloadGrid()
    {
        DataGridConfig();
        DataGridViewConfig();
    }
    /// <summary>
    /// بروزرسانی دیتاگرید
    /// </summary>
    private void DataGridConfig()
    {
        try
        {
            //بررسی منبع دریافت کاربران 
            if (_appCoordinator is { UsersListProvider: FileProvider })
                _username = userid_txtbox.Text = _userid;
            else
                userid_txtbox.Text = _username = (_appCoordinator.UsersList as List<User>)!.First(x => x.UserId == int.Parse(_userid)).Name;

            dataView_Calculate.DataSource = _calcServices
                .Calculate(_userid, _fromDateTime, _toDateTime, checkBox_AutoEdit.Checked)
                .ToDataTable();

            Part2_Load();
            UpdateLabels();
        }
        catch (Exception ex)
        {
            dataView_Calculate.DataSource = null;
            CommonHelper.ShowMessage(ex);
        }
    }
    /// <summary>
    /// بروزرسانی استایل نمایش داده در دیتاگرید
    /// </summary>
    private void DataGridViewConfig()
    {
        if (dataView_Calculate.DataSource == null) return;
        dataView_Calculate.ApplyDisplayNames<WorkRecord>();
        dataView_Calculate.Columns[nameof(WorkRecord.UserId)]!.Visible = false;
    }

    /// <summary>
    /// مقدار دهی تمامی لیبل ها
    /// </summary>
    private void UpdateLabels()
    {
        if (_calcServices.Report is not null and var temp)
        {
            lbl_sumdayworker.Text = temp.TotalWorkDays;
            lbl_fullwork.Text = temp.TotalFullWorkDays;
            lbl_sumhour.Text = temp.TotalWorkingHours;
            lbl_summinute.Text = temp.TotalMinutesWorked;
            lbl_sumentryDelay.Text = temp.TotalLateDays;
            lbl_sumlate.Text = temp.TotalLateTime;
            lbl_nofull.Text = temp.TotalIncompleteDays;
            lbl_sumOff.Text = temp.TotalAbsenceDays;
            lbl_sumaddwork.Text = temp.TotalOvertimeDays;
            lbl_sumaddworkhour.Text = temp.TotalOvertimeAfterWork;
            lbl_minEntry.Text = temp.EarliestEntryTime;
            lbl_MaxExitTime.Text = temp.LatestExitTime;
            lbl_avgentry.Text = temp.AverageEntryTime;
            lbl_avgexit.Text = temp.AverageExitTime;
            lbl_avgtimework.Text = temp.AverageWorkdayHours;
            lbl_sumFraction.Text = temp.TotalFractionTime;
            lbl_tadil.Text = temp.TotalAdjustmentOrOvertime;
            lbl_Information.Text = @$"{_fromDateTime} -- {_toDateTime} -- {_username}";
        }
    }
    #endregion

    #region TabPage2: Late, Absence, Holidays
    private void Part2_Load() => radioButton_CheckedChanged(null, null);

    private void dataView_late_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        if (_calcServices.OverTimeHolidayList.Contains(DateTime.Parse(dataView_late?.Rows[e.RowIndex].Cells[nameof(WorkRecord.Date)]?.Value?.ToString()!)))
            dataView_late!.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.CadetBlue;
    }

    private void BtnExportExcelClick(object sender, EventArgs e) => DataExporter.ExportDataGrid(dataView_late);

    private void radioButton_CheckedChanged(object? sender, EventArgs? e)
    {
        try
        {
            RadioButtonChecker();
            DataGridViewConfig1();
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }

    /// <summary>
    /// انجام عملیات مرتبط به رادیو باتن ها
    /// </summary>
    private void RadioButtonChecker()
    {
        var fromDt = DateTime.Parse(_fromDateTime);
        var toDt = DateTime.Parse(_toDateTime);

        if (radioButton_qeybat.Checked)
        {
            dataView_late.DataSource = _calcServices.AbsenceDaysList
                .Select(g => new { DayOfWeek = g.Date.ToString("dddd"), Date = g.Date.ToString("yyyy/MM/dd") })
                .ToList()
                .ToDataTableWithDisplayedName();
        }
        else if (radioButton_holidays.Checked)
        {
            dataView_late.DataSource = _calcServices.HolidaysDaysList
                .Select(g => new { DayOfWeek = g.Date.ToString("dddd"), Date = g.Date.ToString("yyyy/MM/dd") })
                .ToList()
                .ToDataTableWithDisplayedName();
        }
        else if (radioButton_ramadan.Checked)
        {
            dataView_late.DataSource = _calcServices.RamadanDaysList
                .Where(x => x.Date.Date >= fromDt && x.Date.Date <= toDt)
                .Select(g => new { DayOfWeek = g.Date.ToString("dddd"), Date = g.Date.ToString("yyyy/MM/dd"), g.Title })
                .ToList()
                .ToDataTableWithDisplayedName();
        }
    }
    /// <summary>
    /// اعمال استایل ظاهری مرتبط به دیتاگرید دوم
    /// </summary>
    private void DataGridViewConfig1()
    {
        dataView_late.Columns[0].HeaderText = "روز در هفته";
        dataView_late.Columns[1].HeaderText = "تاریخ";
        if (dataView_late.Columns.Count == 3)
            dataView_late.Columns[2].HeaderText = "عنوان";
    }
    #endregion
}
namespace VorodKhoroj.View;

public partial class FrmCalc : Form
{
    private readonly AppCoordinator _service;
    private readonly AttendanceFullCalculationService _calcServices;

    private readonly string _fromDateTime;
    private readonly string _toDateTime;
    private string _username;
    private string _userid;
    private readonly bool _justExcel;

    public FrmCalc(AppCoordinator services, AttendanceFullCalculationService calcServices, string fromDateTime,
        string toDateTime, string userid, bool justExcel = false)
    {
        InitializeComponent();
        _service = services;
        _calcServices = calcServices;
        _fromDateTime = fromDateTime;
        _toDateTime = toDateTime;
        _userid = userid;
        _justExcel = justExcel;
    }

    private void FrmCalc_Load(object sender, EventArgs e)
    {
        userid_txtbox.DataSource = _service.UsersList;
        if (_service.UserListProvider is DbProvider)
        {
            CommonItems.SetDisplayAndValueMemberComboBox(ref userid_txtbox);
        }
        ReloadGrid();

        if (dataView_Calculate.DataSource == null)
        {
            Close();
            return;
        }

        if (_justExcel)
        {
            OutputExcelToolStripMenuItem_Click(this, e);
            Close();
        }
    }

    private void DataViewCalculateRowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
    {
        var data = (DataGridView)sender;

        data.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
    }

    private void btn_Submit_Click(object sender, EventArgs e)
    {
        _calcServices
            .WithLateTime(TimeSpan.Parse(txtbox_late.Text))
            .WithFullWorkTime(TimeSpan.Parse(txtbox_fullwork.Text))
            .WithFullWorkThursdayTime(TimeSpan.Parse(txtbox_fullwork_thursday.Text))
            .WithFullWorkFarvardinTime(TimeSpan.Parse(txtbox_fullwork_farvardin.Text))
            .WithFullWorkRamadanTime(TimeSpan.Parse(txtbox_fullwork_ramadan.Text))
            .WithNaqesWorkTime(TimeSpan.Parse(txtbox_naqes_normal.Text))
            .WithNaqesWorkThursdayTime(TimeSpan.Parse(txtbox_naqes_thrusday.Text))
            .WithNaqesWorkFarvardinTime(TimeSpan.Parse(txtbox_naqes_farvardin.Text))
            .WithNaqesWorkRamadanTime(TimeSpan.Parse(txtbox_naqes_ramazan.Text));

        ReloadGrid();

        CommonHelper.ShowMessage("انجام شد");
    }

    private void checkBox_ApplyStyles_CheckedChanged(object sender, EventArgs e)
    {
        dataView_Calculate.Invalidate();
    }

    private void DataViewCalculateRowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        if (dataView_Calculate?.Rows.Count > e.RowIndex)
        {
            var row = dataView_Calculate.Rows[e.RowIndex];

            if (row.Cells["IsLate"]?.Value is true && checkBox_Islate.Checked)
                row.DefaultCellStyle.BackColor = Color.Red;

            else if (row.Cells["IsNaghes"]?.Value is true && checkBox_IsNaqes.Checked)
                row.DefaultCellStyle.BackColor = Color.Orange;

            else if (checkBox_workinholiday.Checked && DateTime.TryParse(row.Cells["Date"]?.Value?.ToString(), out var date)
                     && _calcServices.OvertimeinHoliday.Contains(date))
                row.DefaultCellStyle.BackColor = Color.CadetBlue;
            else
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }
    }

    private void OutputExcelToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            _calcServices.TitleReport = $"{_fromDateTime} -- {_toDateTime} {'\t'}{'\t'} User:{userid_txtbox.DisplayMember}";

            DataExporter.ExportDataGrid(dataView_Calculate, _calcServices.GetDataWithTitle(), _calcServices.TitleReport);
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }

    private void userid_txtBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyData == Keys.Enter && MessageBox.Show(@"آیا از کار خود اطمینان دارید؟", @"Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            _username = userid_txtbox.Text;
            _userid = CommonItems.GetUserIdValueToString(userid_txtbox);
            ReloadGrid();
            CommonHelper.ShowMessage("انجام شد");
        }
    }

    private void btn_next_Click(object sender, EventArgs e)
    {
        ChangeUser(true);
    }

    private void btn_perv_Click(object sender, EventArgs e)
    {
        ChangeUser(false);
    }

    private void ChangeUser(bool plusNumber)
    {
        try
        {
            if (_service is { UsersList: null }) return; // or:     if (_service.UsersList == null) return;

            ////Convert IList(object) to List<int>:
            //var users = _service.UsersList is IEnumerable list
            //    ? list.Cast<object>()
            //        .Select(x => int.TryParse(x?.ToString(), out var n) ? n : 0)
            //        .ToList()
            //    : [];
            //ToDo: tommorow doing convert ilist to list<int> as database and file:
            var usersList = _service.UsersList as List<User>;

            List<int> users = [];

            users.AddRange(usersList!.Select(variable => variable.UserId));

            if (!int.TryParse(_userid, out var currentId)) return;

            var currentIndex = users.IndexOf(currentId);

            if (currentIndex == -1) return;

            var nextIndex = plusNumber ? currentIndex + 1 : currentIndex - 1;
            if (nextIndex < 0 || nextIndex >= users.Count)
                return;

            _userid = users[nextIndex].ToString();

            ReloadGrid();

            CommonHelper.ShowMessage("انجام شد");
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }

    }


    private void DataGridConfig()
    {
        try
        {
            userid_txtbox.Text = _userid;

            if (userid_txtbox.Text != _userid) throw new ArgumentOutOfRangeException($@"{nameof(_userid)}", @"خطای داخلی ");

            dataView_Calculate.DataSource = _calcServices
                .Calculate(_userid, _fromDateTime, _toDateTime, checkBox_AutoEdit.Checked).ToDataTable();

            Part2_Load();

            UpdateLabels();
        }
        catch (Exception ex)
        {
            dataView_Calculate.DataSource = null;

            CommonHelper.ShowMessage(ex);
        }
    }

    private void DataGridViewConfig()
    {
        if (dataView_Calculate.DataSource == null) return;

        new WorkRecord().SetDisplayNameInDataGrid(dataView_Calculate);
    }

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
            lbl_sumkasri.Text = temp.TotalKasriTime;
            lbl_tadil.Text = temp.TotalAdjustmentOrOvertime;
            lbl_Information.Text = @$"{_fromDateTime} -- {_toDateTime} -- {_username}";

        }
    }

    private void ReloadGrid()
    {
        DataGridConfig();
        DataGridViewConfig();
    }


    #region TabPage2:
    private void dataView_late_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        if (_calcServices.OvertimeinHoliday.Contains(DateTime.Parse(dataView_late?.Rows[e.RowIndex].Cells[nameof(WorkRecord.Date)]?.Value?.ToString()!)))
            dataView_late!.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.CadetBlue;
    }

    private void BtnExportExcelClick(object sender, EventArgs e)
    {
        DataExporter.ExportDataGrid(dataView_late);
    }

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

    private void Part2_Load()
    {
        radioButton_CheckedChanged(null, null);
    }

    private void DataGridViewConfig1()
    {
        dataView_late.Columns[0].HeaderText = @"روز در هفته";
        dataView_late.Columns[1].HeaderText = @"تاریخ";
        _ = dataView_late.Columns.Count == 3 ? dataView_late.Columns[2].HeaderText = @"عنوان" : "";

    }

    private void RadioButtonChecker()
    {
        var fromDt = DateTime.Parse(_fromDateTime);
        var toDt = DateTime.Parse(_toDateTime);

        if (radioButton_qeybat.Checked)
            dataView_late.DataSource = _calcServices.QeybathaDaysList.Select(g => new
            {
                DayOfWeek = g.Date.ToString("dddd"),
                Date = g.Date.ToString("yyyy/MM/dd")
            }).ToList().ToDataTable();


        else if (radioButton_holidays.Checked)
            dataView_late.DataSource = _calcServices.HolidaysDaysList.Select(g => new
            {
                DayOfWeek = g.Date.ToString("dddd"),
                Date = g.Date.ToString("yyyy/MM/dd"),
            }).ToList().ToDataTable();


        else if (radioButton_ramadan.Checked)
            dataView_late.DataSource = _calcServices.RamadanDaysList.Where(x => x.Date.Date >= fromDt && x.Date.Date <= toDt).Select(g =>
                new
                {
                    DayOfWeek = g.Date.ToString("dddd"),
                    Date = g.Date.ToString("yyyy/MM/dd"),
                    g.Title,
                }).ToList().ToDataTable();
    }
    #endregion


}
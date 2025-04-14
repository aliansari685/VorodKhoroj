namespace VorodKhoroj.View;

public partial class FrmCalc : Form
{
    private readonly AppServices _service;
    private readonly AttendanceCalculationService _calcServices;

    private readonly string _fromDateTime;
    private readonly string _toDateTime;
    private string _userid;
    private readonly bool _justExcel;

    public FrmCalc(AppServices services, AttendanceCalculationService calcServices, string fromDateTime,
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
        lbl_FromTo.Text = @$"{_fromDateTime} -- {_toDateTime}";
        userid_txtbox.DataSource = _service.GetUsers();
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
            .WithFullWorkFarvardinTime(TimeSpan.Parse(txtbox_fullwork_farvardin.Text));

        ReloadGrid();

        CommonHelper.ShowMessage("انجام شد");
    }

    private void DataViewCalculateRowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        if (dataView_Calculate?.Rows?.Count > e.RowIndex)
        {
            var row = dataView_Calculate.Rows[e.RowIndex];

            if (row?.Cells["IsLate"]?.Value is true)
                row.DefaultCellStyle.BackColor = Color.Red;

            else if (row?.Cells["IsNaghes"]?.Value is true)
                row.DefaultCellStyle.BackColor = Color.Orange;

            else if (DateTime.TryParse(row?.Cells["Date"]?.Value?.ToString(), out var date)
                     && _calcServices.OvertimeinHoliday.Contains(date))
                row.DefaultCellStyle.BackColor = Color.CadetBlue;
        }
    }

    private void OutputExcelToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            var title = @$"{lbl_FromTo.Text} {'\t'}{'\t'} User:{_userid}";
            DataExporter.ExportDataGrid(dataView_Calculate, _calcServices.GetDataWithTitle(), title);
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }

    private void userid_txtbox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyData == Keys.Enter)
            if (MessageBox.Show(@"آیا از کار خود اطمینان دارید؟", @"Confirm", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _userid = userid_txtbox.Text;
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
        var users = _service.GetUsers();
        var now = Array.IndexOf(users, int.Parse(_userid));

        if (plusNumber && now < users.Length - 1)
            now++;
        else if (!plusNumber && now > 0)
            now++;
        else
            return;

        _userid = users[now].ToString();
        ReloadGrid();
        CommonHelper.ShowMessage("انجام شد");
    }

    private void DataGridConfig()
    {
        try
        {
            userid_txtbox.Text = _userid;

            if (userid_txtbox.Text != _userid) throw new ArgumentOutOfRangeException($@"_userId", @$"خطای داخلی ");

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

        for (var i = 0; i < _calcServices.PersianColumnHeader.Count; i++)
            dataView_Calculate.Columns[i].HeaderText = _calcServices.PersianColumnHeader[i];
    }

    private void UpdateLabels()
    {
        var temp = _calcServices.Report;

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
    }

    private void ReloadGrid()
    {
        DataGridConfig();
        DataGridViewConfig();
    }
}
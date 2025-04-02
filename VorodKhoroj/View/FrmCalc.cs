namespace VorodKhoroj.View;

public partial class FrmCalc : Form
{
    //TabPage 0_VorodKhoroj:

    public Dictionary<string, string> Labels;

    private List<DateTime> _qeybathaDaysList = [];
    private List<DateTime> _holidaysDaysList;
    private readonly string _fromDateTime, _toDateTime, _userid;
    private readonly AppServices _service;

    private TimeSpan _lateTm = new(08, 30, 00);

    //  private TimeSpan _late_exitTm = new(16, 45, 00);
    private TimeSpan _fullworkTm = new(08, 30, 00);
    private TimeSpan _fullwork_thursdayTm = new(05, 30, 00);
    private TimeSpan _fullwork_farvardinTm = new(07, 45, 00);


    public FrmCalc(AppServices services, string fromDateTime, string toDateTime, string userid)
    {
        InitializeComponent();
        _service = services;
        _fromDateTime = fromDateTime;
        _toDateTime = toDateTime;
        _userid = userid;
    }

    private void FrmCalc_Load(object sender, EventArgs e)
    {
        lbl_FromTo.Text = @$"{_fromDateTime} تا {_toDateTime}";
        lbl_user.Text = _userid;
        DataGridConfig();
    }

    private void DataGridConfig()
    {
        try
        {
            CalculatorData();
            DataGridViewConfig();
            Part2_Load();
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
            Close();
        }
    }

    public void CalculatorData()
    {
        var dataFiltered
            = DataFilterService.ApplyFilter(_service.Records, _fromDateTime, _toDateTime, int.Parse(_userid));
        if (dataFiltered.Count == 0) throw new ArgumentNullException("داده ای وجود ندارد");


        var groupedData = dataFiltered
            .GroupBy(x => (x.UserId, x.DateTime.Date))
            .Select(g =>
            {
                TimeSpan overtime = new(0);

                var orderedTimes = g.Select(x => x.DateTime).OrderBy(dt => dt).ToList();

                // بررسی لیست که خالی نباشه
                if (!orderedTimes.Any())
                    return null; // یا هر مقدار پیش‌فرض دیگه‌ای که مناسب باشه

                // اولین ورود و خروج
                var minDateTime = orderedTimes.FirstOrDefault();
                var maxDateTime = orderedTimes.ElementAtOrDefault(1); // به جای FirstOrDefault()

                if (maxDateTime == DateTime.MinValue) maxDateTime = minDateTime; // 0 دقیقه کار

                DateTime? minDateTime2 = null;
                DateTime? maxDateTime2 = null;

                if (orderedTimes.Count > 2)
                {
                    minDateTime2 = orderedTimes.ElementAtOrDefault(2);
                    maxDateTime2 = orderedTimes.LastOrDefault();

                    if (minDateTime2 != DateTime.MinValue && maxDateTime2 == DateTime.MinValue) maxDateTime2 = minDateTime2;
                }

                var _thursday = minDateTime.DayOfWeek == DayOfWeek.Thursday &&
                                maxDateTime.DayOfWeek == DayOfWeek.Thursday;

                var _farvardin = PersianDateHelper.GetWorkDays_Farvardin()
                    .Any(d => d.Date == minDateTime.Date && d.Date == maxDateTime.Date);

                var duration = maxDateTime - minDateTime;

                var duration2 = TimeSpan.Zero;
                if (maxDateTime2 != null || minDateTime2 != null) duration2 = (TimeSpan)(maxDateTime2 - minDateTime2);

                var totalDuration = duration + duration2;

                var lateMinutes = minDateTime.TimeOfDay > _lateTm && totalDuration.TotalMinutes > 60
                    ? minDateTime.TimeOfDay - _lateTm
                    : TimeSpan.Zero;

                if (_thursday && totalDuration > _fullwork_thursdayTm)
                    overtime = totalDuration - _fullwork_thursdayTm;

                else if (_farvardin && totalDuration > _fullwork_farvardinTm)
                    overtime = (totalDuration - _fullwork_farvardinTm)!;

                else if (totalDuration > _fullworkTm) overtime = (totalDuration - _fullworkTm)!;

                return new
                {
                    DayOfWeek = g.Key.Date.ToString("dddd"),
                    Date = g.Key.Date.ToString("yyyy/MM/dd"),
                    EntryTime = minDateTime.ToString("HH:mm:ss"), //datetime
                    ExitTime = maxDateTime.ToString("HH:mm:ss"),
                    EntryTime2 = minDateTime2?.ToString("HH:mm:ss"),
                    ExitTime2 = maxDateTime2?.ToString("HH:mm:ss"),
                    DurationMin = totalDuration.TotalMinutes,
                    DurationHour = $"{(int)totalDuration.TotalHours!:D2}h {totalDuration.Minutes:D2}m",
                    IsLate = lateMinutes != TimeSpan.Zero,
                    LateMinutes = lateMinutes,
                    Overtime = overtime.ToString(
                        @"hh\:mm\:ss"), //or: Overtime = @$"{(int)overtime.TotalHours:D2}:{overtime.Minutes:D2}:{overtime.Seconds:D2}",
                    FullWork = totalDuration >= _fullworkTm || (_thursday && totalDuration > _fullwork_thursdayTm) ||
                               (_farvardin && totalDuration > _fullwork_farvardinTm),
                    IsComplete = totalDuration.TotalMinutes < 60,
                };
            })
            .ToList();

        // محاسبه مجموع تاخیر
        var totalLateMinutes = TimeSpan.FromMinutes(groupedData.Sum(x => x.LateMinutes.TotalMinutes));
        lbl_sumlate.Text =
            $@"{(int)totalLateMinutes.TotalHours:D2}:{totalLateMinutes.Minutes:D2}:{totalLateMinutes.Seconds:D2}";

        // محاسبه مجموع اضافه ساعت کاری
        var totalOvertimeMinutes = TimeSpan.FromMinutes(groupedData.Sum(x => TimeSpan.Parse(x.Overtime).TotalMinutes));
        lbl_sumaddworkhour.Text =
            $@"{(int)totalOvertimeMinutes.TotalHours:D2}:{totalOvertimeMinutes.Minutes:D2}:{totalOvertimeMinutes.Seconds:D2}";

        // محاسبه مجموع ناقصی
        var totalling = groupedData.Count(x => x.DurationMin < 60);
        lbl_nofull.Text = totalling.ToString();

        // محاسبه مجموع دقایق کاری
        var totalMinutes = groupedData.Sum(x => x.DurationMin);
        lbl_summinute.Text = totalMinutes.ToString("0") + @"m"; //رند  به سمت بالا

        // محاسبه میانگین ساعت ورود
        var entryTimes = groupedData
            .Select(x => TimeSpan.Parse(x.EntryTime))
            .ToList();
        var avgEntryTime = TimeSpan.FromTicks((long)entryTimes.Average(t => t.Ticks));
        lbl_avgentry.Text = avgEntryTime.ToString(@"hh\:mm\:ss");

        // محاسبه میانگین ساعت خروج
        var exitTimes = groupedData
            .Select(x => TimeSpan.Parse(x.ExitTime))
            .ToList();
        var avgExitTime = TimeSpan.FromTicks((long)exitTimes.Average(t => t.Ticks));
        lbl_avgexit.Text = avgExitTime.ToString(@"hh\:mm\:ss");

        // محاسبه مجموع روزهای کاری
        lbl_sumdayworker.Text = groupedData.Count().ToString();

        // محاسبه مجموع ساعت کاری
        var totalHours = TimeSpan.FromMinutes(totalMinutes);
        lbl_sumhour.Text = $@"{(int)totalHours.TotalHours:D2}:{totalHours.Minutes:D2}";

        // محاسبه مجموع روز کامل
        var total = groupedData.Count(x => x.FullWork);
        lbl_fullwork.Text = total.ToString();

        // محاسبه تعداد روزهایی که ورود با تأخیر داشته‌اند)
        var lateDays = groupedData.Count(x => DateTime.Parse(x.EntryTime).TimeOfDay > _lateTm);
        lbl_sumentryDelay.Text = lateDays.ToString();

        //مجموع غیبت
        var holidays = PersianDateHelper.GetHolidays().Select(h => h.Date.Date).ToList(); // تاریخ تعطیلات

        // تولید لیست تاریخ‌های بین دو بازه
        var workDays = Enumerable.Range(0, (DateTime.Parse(_toDateTime) - DateTime.Parse(_fromDateTime)).Days + 1)
            .Select(i => DateTime.Parse(_fromDateTime).AddDays(i))
            .ToList(); // تمامی روزها از `_fromDateTime` تا `_toDateTime`

        var presentDays = groupedData
            .Select(g => DateTime.ParseExact(g.Date, "yyyy/MM/dd", null).Date)
            .ToList(); // تاریخ‌هایی که کارمند حضور داشته است

        // محاسبه تعداد روزهای غیبت (روز کاری باشد، حضور نداشته باشد، تعطیل رسمی هم نباشد)
        var absence = workDays.Where(day => !presentDays.Contains(day) && !holidays.Contains(day));

        var absenceCount = absence.Count();
        lbl_sumOff.Text = absenceCount.ToString();

        _qeybathaDaysList = absence.ToList();

        _holidaysDaysList = workDays.Where(day => holidays.Contains(day)).ToList();

        //اضافه کاری
        var overtimeCount = presentDays.Count(day => holidays.Contains(day));
        lbl_sumaddwork.Text = overtimeCount.ToString();

        //زودترین ورود
        var minEntryTime = TimeSpan.FromTicks(entryTimes.Min(t => t.Ticks));
        lbl_minEntry.Text = minEntryTime.ToString(@"hh\:mm\:ss");

        //دیرترین خروج
        var maxExitTime = TimeSpan.FromTicks(exitTimes.Max(t => t.Ticks));
        lbl_MaxExitTime.Text = maxExitTime.ToString(@"hh\:mm\:ss");

        //میانگین ساعت کاری
        var avgMinutes = totalMinutes / groupedData.Count;
        var avgTimeSpan = TimeSpan.FromMinutes(avgMinutes);
        lbl_avgtimework.Text = avgTimeSpan.ToString(@"hh\:mm\:ss");


        Labels = new Dictionary<string, string>
        {
            {"مجموع روز های کاری", lbl_sumdayworker.Text},
            { "مجموع روز کاری کامل طبق 8 ساعت 30 دقیقه کار", lbl_fullwork.Text },
            { "مجموع ساعات کاری", lbl_sumhour.Text },
            { "مجموع دقایق کاری", lbl_summinute.Text },
            { "مجموع روز های ورود باتاخیر", lbl_sumentryDelay.Text },
            { "مجموع تاخیر ها به ساعت", lbl_sumlate.Text },
            { "مجموع روز های ناقص", lbl_nofull.Text },
            { "مجموع غیبت (غیر تعطیلات)", lbl_sumOff.Text },
            { "مجموع اضافه کاری", lbl_sumaddwork.Text },
            { " مجموع اضافه کاری بعد ساعت کاری", lbl_sumaddworkhour.Text },
            { "زودترین زمان ورود", lbl_minEntry.Text },
            { "دیرترین زمان خروج", lbl_MaxExitTime.Text },
            { "میانگین ساعت های ورود", lbl_avgentry.Text },
            { "میانگین ساعت های خروج", lbl_avgexit.Text },
            { "میانگین ساعت کاری روزانه", lbl_avgtimework.Text }
        };

        dataView_calender.DataSource = groupedData.ToDataTable();
    }

    private void DataGridViewConfig()
    {
        dataView_calender.Columns[0].HeaderText = @"روز در هفته";
        dataView_calender.Columns[1].HeaderText = @"تاریخ";
        dataView_calender.Columns[2].HeaderText = @"ساعت ورود";
        dataView_calender.Columns[3].HeaderText = @"ساعت خروج";
        dataView_calender.Columns[4].HeaderText = @"ساعت ورود 2";
        dataView_calender.Columns[5].HeaderText = @"ساعت خروج 2";
        dataView_calender.Columns[6].HeaderText = @"حضور به دقیقه";
        dataView_calender.Columns[7].HeaderText = @"حضور به ساعت";
        dataView_calender.Columns[8].HeaderText = @"ورود با تاخیر";
        dataView_calender.Columns[9].HeaderText = @"اختلاف تاخیر به دقیقه";
        dataView_calender.Columns[10].HeaderText = @"اختلاف اضافه کاری به ساعت";
        dataView_calender.Columns[11].HeaderText = @"روز کاری کامل";
        dataView_calender.Columns[12].HeaderText = @"روز ناقص";
    }

    private void dataView_calender_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
    {
        var data = (DataGridView)sender;

        data.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
    }

    private void btn_Submit_Click(object sender, EventArgs e)
    {
        _lateTm = TimeSpan.Parse(txtbox_late.Text);
        _fullworkTm = TimeSpan.Parse(txtbox_fullwork.Text);
        _fullwork_thursdayTm = TimeSpan.Parse(txtbox_fullwork_thursday.Text);
        _fullwork_farvardinTm = TimeSpan.Parse(txtbox_fullwork_farvardin.Text);
        DataGridConfig();
        CommonHelper.ShowMessage("انجام شد");
    }

    private void dataView_calender_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        if (dataView_calender.Rows[e.RowIndex].Cells["IsLate"].Value is true)
            dataView_calender.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;

        if (dataView_calender.Rows[e.RowIndex].Cells["IsComplete"].Value is true)
            dataView_calender.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Orange;

        //  dataView_calender.Columns[12]
    }

    private void OutputExcelToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            CommonHelper.DataGridToExcel(dataView_calender, Labels);
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }
}
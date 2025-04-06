namespace VorodKhoroj.View;

public partial class FrmCalc : Form
{
    private readonly AppServices _service;
    private readonly AttendanceCalculationService _calcServices;

    //TabPage 0_VorodKhoroj:
    private readonly string _fromDateTime;
    private readonly string _toDateTime;
    private string _userid;

    public FrmCalc(AppServices services, AttendanceCalculationService calcServices, string fromDateTime, string toDateTime, string userid)
    {
        InitializeComponent();
        _service = services;
        _calcServices = calcServices;
        _fromDateTime = fromDateTime;
        _toDateTime = toDateTime;
        _userid = userid;
    }

    private void FrmCalc_Load(object sender, EventArgs e)
    {
        lbl_FromTo.Text = @$"{_fromDateTime} تا {_toDateTime}";
        userid_txtbox.DataSource = _service?.GetUsers();
        DataGridConfig();
        DataGridViewConfig();

    }

    private void DataGridConfig()
    {
        try
        {
            userid_txtbox.Text = _userid;

            if (userid_txtbox.Text != _userid) throw new ArgumentOutOfRangeException("_userId", "خطای داخلی ");

            dataView_Calculate.DataSource = _calcServices.Calculate(_userid, _fromDateTime, _toDateTime);

            Part2_Load();

            UpdateLabels();
        }
        catch (Exception ex)
        {
            dataView_Calculate.DataSource = null;

            CommonHelper.ShowMessage(ex);
        }
    }

    private void UpdateLabels()
    {
        var _temp = _calcServices.Report;

        lbl_sumdayworker.Text = _temp.TotalWorkDays;
        lbl_fullwork.Text = _temp.TotalFullWorkDays;
        lbl_sumhour.Text = _temp.TotalWorkingHours;
        lbl_summinute.Text = _temp.TotalMinutesWorked;
        lbl_sumentryDelay.Text = _temp.TotalLateTime;
        lbl_sumlate.Text = _temp.TotalLateDays;
        lbl_nofull.Text = _temp.TotalIncompleteDays;
        lbl_sumOff.Text = _temp.TotalAbsenceDays;
        lbl_sumaddwork.Text = _temp.TotalOvertimeDays;
        lbl_sumaddworkhour.Text = _temp.TotalOvertimeAfterWork;
        lbl_minEntry.Text = _temp.EarliestEntryTime;
        lbl_MaxExitTime.Text = _temp.LatestExitTime;
        lbl_avgentry.Text = _temp.AverageEntryTime;
        lbl_avgexit.Text = _temp.AverageExitTime;
        lbl_avgtimework.Text = _temp.AverageWorkdayHours;
        lbl_sumkasri.Text = _temp.KasriTime;
        lbl_tadil.Text = _temp.TotalAdjustmentOrOvertime;
    }

    private void DataGridViewConfig()
    {
        dataView_Calculate.Columns[0].HeaderText = @"روز در هفته";
        dataView_Calculate.Columns[1].HeaderText = @"تاریخ";
        dataView_Calculate.Columns[2].HeaderText = @"ساعت ورود";
        dataView_Calculate.Columns[3].HeaderText = @"ساعت خروج";
        dataView_Calculate.Columns[4].HeaderText = @"ساعت ورود 2";
        dataView_Calculate.Columns[5].HeaderText = @"ساعت خروج 2";
        dataView_Calculate.Columns[6].HeaderText = @"حضور به دقیقه";
        dataView_Calculate.Columns[7].HeaderText = @"حضور به ساعت";
        dataView_Calculate.Columns[8].HeaderText = @"ورود با تاخیر";
        dataView_Calculate.Columns[9].HeaderText = @"اختلاف تاخیر به دقیقه";
        dataView_Calculate.Columns[10].HeaderText = @"اختلاف اضافه کاری به ساعت";
        dataView_Calculate.Columns[11].HeaderText = @"روز کاری کامل";
        dataView_Calculate.Columns[12].HeaderText = @"مقدار کسری";
        dataView_Calculate.Columns[13].HeaderText = @"روز ناقص";
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

        DataGridConfig();

        CommonHelper.ShowMessage("انجام شد");
    }

    private void DataViewCalculateRowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        if (dataView_Calculate.Rows[e.RowIndex].Cells["IsLate"].Value is true)
            dataView_Calculate.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;

        if (dataView_Calculate.Rows[e.RowIndex].Cells["IsNaghes"].Value is true)
            dataView_Calculate.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Orange;

        if (_calcServices.overtimeinHoliday.Contains(DateTime.Parse(dataView_Calculate?.Rows[e.RowIndex]?.Cells["Date"]?.Value?.ToString())))
            dataView_Calculate.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.CadetBlue;
    }

    private void OutputExcelToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            CommonHelper.DataGridToExcel(dataView_Calculate, _calcServices.DataWithTitle);
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }
    private void userid_txtbox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyData == Keys.Enter)
        {
            _userid = userid_txtbox.Text;
            DataGridConfig();
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

        if (plusNumber)
            now++;
        else
            now--;

        _userid = users[now].ToString();
        DataGridConfig();
    }



    //private void ChangeUser()
    //{
    //    DataGridConfig();
    //}
}

//public void CalculatorData()
//{
//    var filtered = DataFilterService.ApplyFilter(_service.Records, _fromDateTime, _toDateTime, int.Parse(_userid));

//    if (filtered?.Any() == false)
//        throw new ArgumentNullException("داده ای وجود ندارد");

//    var farvardinDays = PersianDateHelper.GetWorkDays_Farvardin().Select(d => d.Date).ToHashSet();

//    var dataFiltered = filtered?.Select(x => new { x.UserId, x.DateTime })
//        .OrderBy(x => x.DateTime);

//    var dataFilteredGrouped = dataFiltered?.GroupBy(x => (x.UserId, x.DateTime.Date)).ToList();

//    // تاریخ‌هایی که کارمند حضور داشته است
//    var pr = dataFilteredGrouped?
//        .Select(g => g.Key.Date)
//        .ToList();

//    var holidays = PersianDateHelper.GetHolidays().Select(h => h.Date.Date).ToList(); // تاریخ تعطیلات

//    overtimeinHoliday = pr.Where(day => holidays.Contains(day)).Select(g => g.Date.Date).ToList();

//    var groupedData = dataFilteredGrouped.Select(g =>
//        {
//            var overtime = TimeSpan.Zero;
//            var kasri = TimeSpan.Zero;

//            var orderedTimes = g.Select(x => x.DateTime).ToArray();

//            // تعیین اولین و آخرین ورود و خروج
//            var minDateTime = orderedTimes.First();
//            var maxDateTime = orderedTimes.ElementAtOrDefault(1);
//            if (maxDateTime == DateTime.MinValue) maxDateTime = minDateTime; // جلوگیری از مقدار نامعتبر

//            //ورود خروج دوم
//            DateTime? minDateTime2 = orderedTimes.Count() > 2 ? orderedTimes.ElementAt(2) : null;
//            DateTime? maxDateTime2 = orderedTimes.Count() > 2 ? orderedTimes.Last() : null;

//            //بررسی اینکه روز کاری تعطیل نباشد
//            var IsWorkinginHoliday = overtimeinHoliday.Contains(minDateTime.Date.Date);

//            // بررسی پنجشنبه 
//            var isThursday = minDateTime.DayOfWeek == DayOfWeek.Thursday;

//            //  فروردین
//            var isFarvardin = farvardinDays.Contains(minDateTime.Date);

//            // محاسبه زمان حضور
//            var duration = maxDateTime - minDateTime;
//            var duration2 = minDateTime2.HasValue && maxDateTime2.HasValue
//                ? maxDateTime2.Value - minDateTime2.Value
//                : TimeSpan.Zero;

//            var totalDuration = duration + duration2;

//            //روز ناقص؟
//            var isNaghes = totalDuration.TotalMinutes < 60 && IsWorkinginHoliday == false;

//            // محاسبه تأخیر
//            var lateMinutes = minDateTime.TimeOfDay > _lateTm && totalDuration.TotalMinutes > 60 &&
//                              IsWorkinginHoliday == false
//                ? minDateTime.TimeOfDay - _lateTm
//                : TimeSpan.Zero;

//            // تعیین ساعت کار استاندارد برای مقایسه
//            var standardWorkTime = isThursday ? _fullwork_thursdayTm
//            : isFarvardin ? _fullwork_farvardinTm
//            : _fullworkTm;

//            // محاسبه اضافه‌کار و کسری‌کار
//            var fullWork = false;

//            if (totalDuration >= standardWorkTime)
//            {
//                overtime = totalDuration - standardWorkTime;

//                // بررسی تکمیل بودن ساعت کار
//                fullWork = true;
//            }
//            else if (totalDuration < standardWorkTime && IsWorkinginHoliday == false && isNaghes == false)
//                kasri = standardWorkTime - totalDuration;

//            return new
//            {
//                DayOfWeek = g.Key.Date.ToString("dddd"),
//                Date = g.Key.Date.ToString("yyyy/MM/dd"),
//                EntryTime = minDateTime.ToString("HH:mm:ss"), //datetime
//                ExitTime = maxDateTime.ToString("HH:mm:ss"),
//                EntryTime2 = minDateTime2?.ToString("HH:mm:ss"),
//                ExitTime2 = maxDateTime2?.ToString("HH:mm:ss"),
//                DurationMin = totalDuration.TotalMinutes,
//                DurationHour = $"{(int)totalDuration.TotalHours!:D2}h {totalDuration.Minutes:D2}m",
//                IsLate = lateMinutes != TimeSpan.Zero && IsWorkinginHoliday == false,
//                LateMinutes = lateMinutes,
//                Overtime = overtime.ToString(@"hh\:mm\:ss"), //timespan
//                FullWork = fullWork,
//                IsKasri = kasri.TotalMinutes,
//                IsNaghes = isNaghes,
//            };
//        }).ToArray();

//    // محاسبه مجموع تاخیر
//    var totalLateMinutes = TimeSpan.FromMinutes(groupedData.Sum(x => x.LateMinutes.TotalMinutes));
//    lbl_sumlate.Text =
//        $@"{(int)totalLateMinutes.TotalHours:D2}:{totalLateMinutes.Minutes:D2}:{totalLateMinutes.Seconds:D2}";

//    // محاسبه مجموع اضافه ساعت کاری
//    var totalOvertimeMinutes = TimeSpan.FromMinutes(groupedData.Sum(x => TimeSpan.Parse(x.Overtime).TotalMinutes));
//    lbl_sumaddworkhour.Text =
//        $@"{(int)totalOvertimeMinutes.TotalHours:D2}:{totalOvertimeMinutes.Minutes:D2}:{totalOvertimeMinutes.Seconds:D2}";

//    // محاسبه مجموع ناقصی
//    var totalling = groupedData.Count(x => x.DurationMin < 60);
//    lbl_nofull.Text = totalling.ToString();

//    // محاسبه مجموع دقایق کاری
//    var totalMinutes = groupedData.Sum(x => x.DurationMin);
//    lbl_summinute.Text = totalMinutes.ToString("0") + @"m"; //رند  به سمت بالا

//    // محاسبه میانگین ساعت ورود
//    var entryTimes = groupedData
//        .Select(x => TimeSpan.Parse(x.EntryTime))
//        .ToList();
//    var avgEntryTime = TimeSpan.FromTicks((long)entryTimes.Average(t => t.Ticks));
//    lbl_avgentry.Text = avgEntryTime.ToString(@"hh\:mm\:ss");

//    // محاسبه میانگین ساعت خروج
//    var exitTimes = groupedData
//        .Select(x => TimeSpan.Parse(x.ExitTime))
//        .ToList();
//    var avgExitTime = TimeSpan.FromTicks((long)exitTimes.Average(t => t.Ticks));
//    lbl_avgexit.Text = avgExitTime.ToString(@"hh\:mm\:ss");

//    // محاسبه مجموع ساعت کاری
//    var totalHours = TimeSpan.FromMinutes(totalMinutes);
//    lbl_sumhour.Text = $@"{(int)totalHours.TotalHours:D2}:{totalHours.Minutes:D2}";

//    // محاسبه مجموع روز کامل
//    var total = groupedData.Count(x => x.FullWork);
//    lbl_fullwork.Text = total.ToString();

//    // محاسبه تعداد روزهایی که ورود با تأخیر داشته‌اند)
//    var lateDays = groupedData.Count(x => x.IsLate == true);
//    lbl_sumentryDelay.Text = lateDays.ToString();

//    // تولید لیست تاریخ‌های بین دو بازه
//    var workDays = Enumerable.Range(0, (DateTime.Parse(_toDateTime) - DateTime.Parse(_fromDateTime)).Days + 1)
//        .Select(i => DateTime.Parse(_fromDateTime).AddDays(i))
//        .ToList(); // تمامی روزها از `_fromDateTime` تا `_toDateTime`

//    // محاسبه تعداد روزهای غیبت (روز کاری باشد، حضور نداشته باشد، تعطیل رسمی هم نباشد)
//    var absence = workDays.Where(day => !pr.Contains(day) && !holidays.Contains(day));

//    var absenceCount = absence.Count();
//    lbl_sumOff.Text = absenceCount.ToString();

//    //لیست تعطیلات و غیبت ها
//    _qeybathaDaysList = absence.ToList();
//    _holidaysDaysList = workDays.Where(day => holidays.Contains(day)).ToList();

//    // محاسبه مجموع روزهای کاری
//    lbl_sumdayworker.Text = @$"{groupedData?.Count()} از {groupedData.Count() + absenceCount}";

//    //اضافه کاری
//    var overtimeCount = pr.Count(day => holidays.Contains(day));
//    lbl_sumaddwork.Text = overtimeCount.ToString();

//    //زودترین ورود
//    var minEntryTime = TimeSpan.FromTicks(entryTimes.Min(t => t.Ticks));
//    lbl_minEntry.Text = minEntryTime.ToString(@"hh\:mm\:ss");

//    //دیرترین خروج
//    var maxExitTime = TimeSpan.FromTicks(exitTimes.Max(t => t.Ticks));
//    lbl_MaxExitTime.Text = maxExitTime.ToString(@"hh\:mm\:ss");

//    //میانگین ساعت کاری
//    var avgMinutes = totalMinutes / groupedData.Count();
//    var avgTimeSpan = TimeSpan.FromMinutes(avgMinutes);
//    lbl_avgtimework.Text = avgTimeSpan.ToString(@"hh\:mm\:ss");

//    //محاسبه کسری
//    var kasriTime = TimeSpan.FromMinutes(groupedData.Sum(x => x.IsKasri));
//    lbl_sumkasri.Text = $@"{(int)kasriTime.TotalHours:D2}:{kasriTime.Minutes:D2}:{kasriTime.Seconds:D2}";

//    //محاسبه تعدیل
//    var tadil = totalOvertimeMinutes - kasriTime;
//    //     lbl_tadil.Text = $@"{(int)tadil.TotalHours:D2}:{tadil.Minutes:D2}:{tadil.Seconds:D2}";
//    lbl_tadil.Text = tadil.TotalMinutes.ToString();
//    dataView_calender.DataSource = groupedData.ToList().ToDataTable();

//    DataWithTitle = new Dictionary<string, string>
//    {
//        { "مجموع روز های کاری", lbl_sumdayworker.Text },
//        { "مجموع روز کاری کامل طبق 8 ساعت 30 دقیقه کار", lbl_fullwork.Text },
//        { "مجموع ساعات کاری", lbl_sumhour.Text },
//        { "مجموع دقایق کاری", lbl_summinute.Text },
//        { "مجموع روز های ورود باتاخیر", lbl_sumentryDelay.Text },
//        { "مجموع تاخیر ها به ساعت", lbl_sumlate.Text },
//        { "مجموع روز های ناقص", lbl_nofull.Text },
//        { "مجموع غیبت (غیر تعطیلات)", lbl_sumOff.Text },
//        { "مجموع اضافه کاری", lbl_sumaddwork.Text },
//        { " مجموع اضافه کاری بعد ساعت کاری", lbl_sumaddworkhour.Text },
//        { "زودترین زمان ورود", lbl_minEntry.Text },
//        { "دیرترین زمان خروج", lbl_MaxExitTime.Text },
//        { "میانگین ساعت های ورود", lbl_avgentry.Text },
//        { "میانگین ساعت های خروج", lbl_avgexit.Text },
//        { "میانگین ساعت کاری روزانه", lbl_avgtimework.Text },
//        { "مقدار کسری به ساعت", lbl_sumkasri.Text },
//        { "مقدار تعدیل یا اضافه ساعت کاری خالص", lbl_tadil.Text }
//    };
//}

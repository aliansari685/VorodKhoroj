namespace VorodKhoroj.Services;

public class AttendanceFullCalculationService(MainCoordinator recordService)
{
    public AttendanceReport? Report { get; private set; }

    private TimeSpan _lateTm = TimeSpan.Parse("08:30:00");

    private TimeSpan _fullWorkTm = TimeSpan.Parse("08:30:00");
    private TimeSpan _fullWorkThursdayTm = TimeSpan.Parse("05:30:00");
    private TimeSpan _fullWorkFarvardinTm = TimeSpan.Parse("07:45:00");
    private TimeSpan _fullWorkRamadanTm = TimeSpan.Parse("06:45:00");

    private TimeSpan _incompleteWorkTm = TimeSpan.Parse("16:45:00");
    private TimeSpan _incompleteWorkThursdayTm = TimeSpan.Parse("13:45:00");
    private TimeSpan _incompleteWorkFarvardinTm = TimeSpan.Parse("15:45:00");
    private TimeSpan _incompleteWorkRamadanTm = TimeSpan.Parse("14:45:00");

    public string TitleReport { get; set; } = "";
    public List<DateTime> AbsenceDaysList { get; private set; } = [];//غیبت ها
    public List<DateTime> HolidaysDaysList { get; private set; } = [];
    public List<TemplateDays> RamadanDaysList { get; private set; } = [];
    public List<DateTime> OverTimeHolidayList { get; private set; } = [];//کار در تعطیلات

    public AttendanceFullCalculationService WithLateTime(TimeSpan lateTime)
    {
        _lateTm = lateTime;
        return this;
    }

    public AttendanceFullCalculationService WithFullWorkTime(TimeSpan fullWorkTime)
    {
        _fullWorkTm = fullWorkTime;
        return this;
    }

    public AttendanceFullCalculationService WithFullWorkThursdayTime(TimeSpan thursdayTime)
    {
        _fullWorkThursdayTm = thursdayTime;
        return this;
    }

    public AttendanceFullCalculationService WithFullWorkFarvardinTime(TimeSpan farvardinTime)
    {
        _fullWorkFarvardinTm = farvardinTime;
        return this;
    }

    public AttendanceFullCalculationService WithFullWorkRamadanTime(TimeSpan ramadanTime)
    {
        _fullWorkRamadanTm = ramadanTime;
        return this;
    }

    public AttendanceFullCalculationService WithinCompleteWorkTime(TimeSpan fullWorkTime)
    {
        _incompleteWorkTm = fullWorkTime;
        return this;
    }

    public AttendanceFullCalculationService WithinCompleteWorkThursdayTime(TimeSpan thursdayTime)
    {
        _incompleteWorkThursdayTm = thursdayTime;
        return this;
    }

    public AttendanceFullCalculationService WithinCompleteWorkFarvardinTime(TimeSpan farvardinTime)
    {
        _incompleteWorkFarvardinTm = farvardinTime;
        return this;
    }

    public AttendanceFullCalculationService WithinCompleteWorkRamadanTime(TimeSpan ramadanTime)
    {
        _incompleteWorkRamadanTm = ramadanTime;
        return this;
    }

    public List<WorkRecord> Calculate(string userId, string fromDateTime, string toDateTime, bool autoEditIncompleteDays = true)
    {
        if (CommonHelper.IsValid(userId) == false) userId = "0";

        var filtered = DataFilterService.ApplyFilter(recordService.AttendancesList, fromDateTime, toDateTime, int.Parse(userId)).ToArray();

        if (filtered.Any() == false)
            //    throw new ArgumentNullException($"داده ای وجود ندارد");
            return [];


        // دریافت روزهای کاری فروردین (تقویم شمسی)
        var farvardinDays = PersianDateHelper.GetWorkDays_Farvardin().Select(d => d.Date).ToHashSet();

        //رمضان
        RamadanDaysList = PersianDateHelper.GetRamadanDays();
        var ramadanDays = RamadanDaysList.Select(d => d.Date).ToHashSet();

        // مرتب کردن داده‌ها بر اساس تاریخ و زمان
        var dataFiltered = filtered.Select(x => new { x.UserId, x.DateTime })
            .OrderBy(x => x.DateTime);

        // گروه‌بندی داده‌ها بر اساس شناسه کاربری و تاریخ
        var dataFilteredGrouped = dataFiltered.GroupBy(x => (x.UserId, x.DateTime.Date)).ToList();

        // تاریخ‌هایی که کارمند حضور داشته است
        var pr = dataFilteredGrouped.Select(g => g.Key.Date).ToList();

        // دریافت تعطیلات از تقویم شمسی
        var holidays = PersianDateHelper.GetHolidays().Select(h => h.Date.Date).ToList(); // تاریخ تعطیلات

        // تاریخ‌های تعطیل که کارمند حضور داشته است
        OverTimeHolidayList = pr.Where(holidays.Contains).Select(g => g.Date.Date).ToList();

        //رمضان
        var ramadanDaysList = pr.Where(ramadanDays.Contains).Select(g => g.Date.Date).ToList();

        var groupedData = dataFilteredGrouped.Select(g =>
        {
            var overtime = TimeSpan.Zero; // مقدار پیش‌فرض اضافه کاری

            var fraction = TimeSpan.Zero; // مقدار پیش‌فرض کسری ساعت

            var orderedTimes = g.Select(x => x.DateTime).ToArray(); // آرایه‌ای از زمان‌های ورودی و خروجی

            var minDateTime = orderedTimes.First(); // زمان ورودی اولین کارمند
            var maxDateTime = orderedTimes.ElementAtOrDefault(1); // زمان خروج اولین کارمند

            // بررسی اینکه آیا فرد در تعطیلات کار کرده است
            var isWorkinginHoliday = OverTimeHolidayList.Contains(minDateTime.Date.Date);

            // بررسی اینکه آیا روز جاری پنجشنبه است
            var isThursday = minDateTime.DayOfWeek == DayOfWeek.Thursday;

            //ایا رمضان است روز جاری؟
            var isRamadan = ramadanDaysList.Contains((minDateTime.Date));

            // بررسی اینکه آیا روز جاری در ماه فروردین است
            var isFarvardin = farvardinDays.Contains(minDateTime.Date);


            if (autoEditIncompleteDays && orderedTimes.Length == 1)
            {
                var isLateThursday = isThursday && minDateTime.Hour >= 13;
                var isLateStandardDay = !isThursday && minDateTime.Hour > 14;

                if (isLateThursday || isLateStandardDay)
                {
                    minDateTime = minDateTime.Date + new TimeSpan(08, 15, 00);
                    maxDateTime = orderedTimes.First();
                }
            }

            //خروج ناقص
            var exitincompleteWorkTm = _incompleteWorkTm;
            if (isThursday)
                exitincompleteWorkTm = _incompleteWorkThursdayTm;
            if (isRamadan)
                exitincompleteWorkTm = _incompleteWorkRamadanTm;
            if (isFarvardin)
                exitincompleteWorkTm = _incompleteWorkFarvardinTm;

            if (maxDateTime == DateTime.MinValue)
            {
                maxDateTime = autoEditIncompleteDays
                    ? minDateTime.Date + exitincompleteWorkTm
                    : minDateTime;
            }

            // اگر زمان ورودی و خروجی دوم وجود داشته باشد
            DateTime? minDateTime2 = orderedTimes.Count() > 2 ? orderedTimes.ElementAt(2) : null;
            DateTime? maxDateTime2 = orderedTimes.Count() > 2 && orderedTimes.Last() != minDateTime2 ? orderedTimes.Last() : null;

            // محاسبه مدت زمان حضور (ورود - خروج)
            var duration = (maxDateTime) - minDateTime;
            var duration2 = minDateTime2.HasValue && maxDateTime2.HasValue
                ? maxDateTime2.Value - minDateTime2.Value
                : TimeSpan.Zero;

            // جمع مدت زمان حضور
            var totalDuration = duration + duration2;

            // بررسی اینکه آیا مدت زمان کاری کمتر از یک ساعت است و فرد در تعطیلات نبوده است
            var isNaghes = totalDuration.TotalMinutes < 60 && !isWorkinginHoliday;

            // محاسبه زمان تاخیر
            var lateMinutes = minDateTime.TimeOfDay > _lateTm && totalDuration.TotalMinutes > 60 && !isWorkinginHoliday
                ? minDateTime.TimeOfDay - _lateTm
                : TimeSpan.Zero;

            // تعیین ساعات کاری استاندارد بر اساس روز هفته
            var standardWorkTime =
            isRamadan ? _fullWorkRamadanTm : isFarvardin ? _fullWorkFarvardinTm
            : isThursday ? _fullWorkThursdayTm : _fullWorkTm;

            // بررسی اینکه آیا فرد ساعت کامل کار کرده است یا نه
            var fullWork = false;
            if (totalDuration >= standardWorkTime)
            {
                overtime = totalDuration - standardWorkTime; // اضافه کاری محاسبه می‌شود
                fullWork = true;
            }
            if (totalDuration < standardWorkTime && !isWorkinginHoliday && !isNaghes)
            {
                fraction = standardWorkTime - totalDuration; // کسری ساعت محاسبه می‌شود
            }

            return new WorkRecord
            {
                UserId = g.Key.UserId.ToString(),
                DayOfWeek = g.Key.Date.ToString("dddd"),
                Date = g.Key.Date.ToString("yyyy/MM/dd"),
                EntryTime = minDateTime.ToString("HH:mm:ss"),
                ExitTime = (maxDateTime).ToString("HH:mm:ss"),
                EntryTime2 = minDateTime2?.ToString("HH:mm:ss"),
                ExitTime2 = maxDateTime2?.ToString("HH:mm:ss"),
                DurationMin = totalDuration.TotalMinutes,
                DurationHour = $"{(int)totalDuration.TotalHours:D2}h {totalDuration.Minutes:D2}m",
                IsLate = lateMinutes != TimeSpan.Zero && !isWorkinginHoliday,
                LateMinutes = lateMinutes,
                IsFullWork = fullWork,
                Overtime = overtime.ToString(@"hh\:mm\:ss"),
                Fraction = fraction.TotalMinutes,
                IsNaghes = isNaghes
            };
        }).ToArray();

        #region GroupingAttendanceCalculation

        // محاسبه جمع دقیقه‌های تاخیر
        var totalLateMinutes = TimeSpan.FromMinutes(groupedData.Sum(x => x.LateMinutes.TotalMinutes));

        // محاسبه جمع دقیقه‌های اضافه کاری
        var totalOvertimeMinutes =
            TimeSpan.FromMinutes(groupedData.Sum(x => TimeSpan.Parse(x.Overtime ?? string.Empty).TotalMinutes));

        // تعداد روزهای ناقص که مدت زمان آن‌ها کمتر از یک ساعت بوده است
        var totalling = groupedData.Count(x => x.DurationMin < 60);

        // جمع کل دقایق کاری
        var totalMinutes = groupedData.Sum(x => x.DurationMin);

        // محاسبه میانگین زمان ورود
        var entryTimes = groupedData.Select(x => TimeSpan.Parse(x.EntryTime ?? string.Empty)).ToList();
        var avgEntryTime = TimeSpan.FromTicks((long)entryTimes.Average(t => t.Ticks));

        // محاسبه میانگین زمان خروج
        var exitTimes = groupedData.Select(x => TimeSpan.Parse(x.ExitTime ?? string.Empty)).ToList();
        var avgExitTime = TimeSpan.FromTicks((long)exitTimes.Average(t => t.Ticks));

        // جمع ساعات کاری کل
        var totalHours = TimeSpan.FromMinutes(totalMinutes);

        // تعداد روزهایی که فرد ساعت کامل کار کرده است
        var total = groupedData.Count(x => x.IsFullWork);

        // تعداد روزهای تاخیر
        var lateDays = groupedData.Count(x => x.IsLate);

        // بدست آوردن روزهای کاری در بازه زمانی مشخص
        var workDays = Enumerable.Range(0, (DateTime.Parse(toDateTime) - DateTime.Parse(fromDateTime)).Days + 1)
            .Select(i => DateTime.Parse(fromDateTime).AddDays(i))
            .ToList();

        // محاسبه روزهای غیبت
        var absence = workDays.Where(day => !pr.Contains(day) && !holidays.Contains(day)).ToArray();
        var absenceCount = absence.Count();

        // تعیین روزهای غیبت و تعطیلات
        AbsenceDaysList = absence.ToList();
        HolidaysDaysList = workDays.Where(day => holidays.Contains(day)).ToList();

        // تعداد روزهای اضافه کاری
        var overtimeCount = pr.Count(day => holidays.Contains(day));

        // بدست آوردن زودترین زمان ورود
        var minEntryTime = TimeSpan.FromTicks(entryTimes.Min(t => t.Ticks));

        // بدست آوردن دیرترین زمان خروج
        var maxExitTime = TimeSpan.FromTicks(exitTimes.Max(t => t.Ticks));

        // محاسبه میانگین دقایق کاری در هر روز
        var avgMinutes = totalMinutes / groupedData.Count();

        // محاسبه میانگین ساعات کاری روزانه
        var avgTimeSpan = TimeSpan.FromMinutes(avgMinutes);

        // محاسبه مجموع کسری زمان
        var fractionTime = TimeSpan.FromMinutes(groupedData.Sum(x => x.Fraction));

        // محاسبه تعدیل یا اضافه کاری خالص
        var pureTime = totalOvertimeMinutes - fractionTime;

        #endregion

        Report = new AttendanceReport
        {
            // مجموع روزهای کاری (تعداد کل روزهای کاری که فرد در سیستم ثبت کرده است)
            TotalWorkDays = $"{groupedData.Length} از {groupedData.Count() + absenceCount}",

            // مجموع روزهای کاری کامل طبق 8 ساعت و 30 دقیقه کار (تعداد روزهای کاری که فرد کار کامل داشته)
            TotalFullWorkDays = total.ToString(),

            // مجموع ساعات کاری (تعداد ساعات کاری کل در فرمت ساعت:دقیقه)
            TotalWorkingHours = $@"{(int)totalHours.TotalHours:D2}:{totalHours.Minutes:D2}",

            // مجموع دقایق کاری (تعداد دقایق کاری کل به صورت دقیقه)
            TotalMinutesWorked = totalMinutes.ToString("0") + "m",

            // مجموع روزهای ورود با تاخیر (تعداد روزهایی که فرد با تاخیر وارد شده)
            TotalLateDays = lateDays.ToString(),

            // مجموع تاخیرها به ساعت (زمان تاخیر کل در فرمت ساعت:دقیقه:ثانیه)
            TotalLateTime =
                        $@"{(int)totalLateMinutes.TotalHours:D2}:{totalLateMinutes.Minutes:D2}:{totalLateMinutes.Seconds:D2}",

            // مجموع روزهای ناقص (تعداد روزهایی که فرد کار ناقص داشته)
            TotalIncompleteDays = totalling.ToString(),

            // مجموع غیبت‌ها (تعداد روزهایی که فرد غیبت داشته غیر از تعطیلات)
            TotalAbsenceDays = absenceCount.ToString(),

            // مجموع روزهای اضافه کاری (تعداد روزهایی که فرد اضافه کار داشته)
            TotalOvertimeDays = overtimeCount.ToString(),

            // مجموع اضافه کاری بعد از ساعت کاری (زمان اضافه کاری کل فرد بعد از ساعت کاری رسمی در فرمت ساعت:دقیقه:ثانیه)
            TotalOvertimeAfterWork =
                        $@"{(int)totalOvertimeMinutes.TotalHours:D2}:{totalOvertimeMinutes.Minutes:D2}:{totalOvertimeMinutes.Seconds:D2}",

            // زودترین زمان ورود (اولین زمان ورود فرد در طول دوره)
            EarliestEntryTime = minEntryTime.ToString(@"hh\:mm\:ss"),

            // دیرترین زمان خروج (آخرین زمان خروج فرد در طول دوره)
            LatestExitTime = maxExitTime.ToString(@"hh\:mm\:ss"),

            // میانگین ساعت‌های ورود (میانگین زمان‌های ورود فرد در طول دوره به صورت ساعت:دقیقه:ثانیه)
            AverageEntryTime = avgEntryTime.ToString(@"hh\:mm\:ss"),

            // میانگین ساعت‌های خروج (میانگین زمان‌های خروج فرد در طول دوره به صورت ساعت:دقیقه:ثانیه)
            AverageExitTime = avgExitTime.ToString(@"hh\:mm\:ss"),

            // میانگین ساعت کاری روزانه (میانگین ساعات کاری فرد در هر روز به صورت ساعت:دقیقه:ثانیه)
            AverageWorkdayHours = avgTimeSpan.ToString(@"hh\:mm\:ss"),

            // مقدار کسری به ساعت (مجموع زمان کسری فرد به صورت ساعت:دقیقه:ثانیه)
            TotalFractionTime = $@"{(int)fractionTime.TotalHours:D2}:{fractionTime.Minutes:D2}:{fractionTime.Seconds:D2}",

            // مقدار تعدیل یا اضافه ساعت کاری خالص (مجموع ساعات اضافه کاری که باید تعدیل شود یا اضافه شود به صورت دقیقه)
            TotalAdjustmentOrOvertime = pureTime.TotalMinutes.ToString("0") + "m"
        };

        return groupedData.ToList();
    }

    public Dictionary<string, string> GetDataWithTitle()
    {
        return new Dictionary<string, string>
            {
                { Report.GetDisplayName(x => x!.TotalWorkDays), Report!.TotalWorkDays },
                { Report.GetDisplayName(x => x.TotalFullWorkDays), Report.TotalFullWorkDays },
                { Report.GetDisplayName(x => x.TotalWorkingHours), Report.TotalWorkingHours },
                { Report.GetDisplayName(x => x.TotalMinutesWorked), Report.TotalMinutesWorked },
                { Report.GetDisplayName(x => x.TotalLateDays), Report.TotalLateDays },
                { Report.GetDisplayName(x => x.TotalLateTime), Report.TotalLateTime },
                { Report.GetDisplayName(x => x.TotalIncompleteDays), Report.TotalIncompleteDays },
                { Report.GetDisplayName(x => x.TotalAbsenceDays), Report.TotalAbsenceDays },
                { Report.GetDisplayName(x => x.TotalOvertimeDays), Report.TotalOvertimeDays },
                { Report.GetDisplayName(x => x.TotalOvertimeAfterWork), Report.TotalOvertimeAfterWork },
                { Report.GetDisplayName(x => x.EarliestEntryTime), Report.EarliestEntryTime },
                { Report.GetDisplayName(x => x.LatestExitTime), Report.LatestExitTime },
                { Report.GetDisplayName(x => x.AverageEntryTime), Report.AverageEntryTime },
                { Report.GetDisplayName(x => x.AverageExitTime), Report.AverageExitTime },
                { Report.GetDisplayName(x => x.AverageWorkdayHours), Report.AverageWorkdayHours },
                { Report.GetDisplayName(x => x.TotalFractionTime), Report.TotalFractionTime },
                { Report.GetDisplayName(x => x.TotalAdjustmentOrOvertime), Report.TotalAdjustmentOrOvertime }
            };
    }

}
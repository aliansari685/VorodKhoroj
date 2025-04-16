namespace VorodKhoroj.Services;

public class AttendanceCalculationService
{
    public AttendanceReport Report { get; set; }

    public class WorkRecord
    {
        // روز هفته
        public string DayOfWeek { get; set; }

        // تاریخ روز
        public string Date { get; set; }

        // زمان ورود
        public string EntryTime { get; set; }

        // زمان خروج
        public string ExitTime { get; set; }

        // زمان ورود دوم (قابل null بودن)
        public string? EntryTime2 { get; set; }

        // زمان خروج دوم (قابل null بودن)
        public string? ExitTime2 { get; set; }

        // مدت زمان کارکرد به دقیقه
        public double DurationMin { get; set; }

        // مدت زمان کارکرد به فرمت ساعت:دقیقه
        public string DurationHour { get; set; }

        // آیا فرد دیر آمده است؟
        public bool IsLate { get; set; }

        // مقدار دقیقه تاخیر
        public TimeSpan LateMinutes { get; set; }

        // زمان اضافه کاری
        public string Overtime { get; set; }

        // آیا فرد ساعت کامل کار کرده است؟
        public bool IsFullWork { get; set; }

        // مقدار کسری ساعت
        public double Kasri { get; set; }

        // آیا کار فرد ناقص بوده است؟
        public bool IsNaghes { get; set; }
    }

    public class AttendanceReport
    {
        public required string TotalWorkDays { get; set; }
        public required string TotalFullWorkDays { get; set; }
        public required string TotalWorkingHours { get; set; }
        public required string TotalMinutesWorked { get; set; }
        public required string TotalLateDays { get; set; }
        public required string TotalLateTime { get; set; }
        public required string TotalIncompleteDays { get; set; }
        public required string TotalAbsenceDays { get; set; }
        public required string TotalOvertimeDays { get; set; }
        public required string TotalOvertimeAfterWork { get; set; }
        public required string EarliestEntryTime { get; set; }
        public required string LatestExitTime { get; set; }
        public required string AverageEntryTime { get; set; }
        public required string AverageExitTime { get; set; }
        public required string AverageWorkdayHours { get; set; }
        public required string TotalKasriTime { get; set; }
        public required string TotalAdjustmentOrOvertime { get; set; }
    }

    private readonly AppServices _recordService;

    private TimeSpan _lateTm = TimeSpan.Parse("08:30:00");

    private TimeSpan _fullWorkTm = TimeSpan.Parse("08:30:00");
    private TimeSpan _fullWorkThursdayTm = TimeSpan.Parse("05:30:00");
    private TimeSpan _fullWorkFarvardinTm = TimeSpan.Parse("07:45:00");
    private TimeSpan _fullWorkRamadanTm = TimeSpan.Parse("06:45:00");

    private TimeSpan _naqesWorkTm = TimeSpan.Parse("16:45:00");
    private TimeSpan _naqesWorkThursdayTm = TimeSpan.Parse("13:45:00");
    private TimeSpan _naqesWorkFarvardinTm = TimeSpan.Parse("15:45:00");
    private TimeSpan _naqesWorkRamadanTm = TimeSpan.Parse("14:45:00");

    public List<DateTime> QeybathaDaysList { get; private set; }
    public List<DateTime> HolidaysDaysList { get; private set; }
    public List<TemplateDays> RamadanDaysList { get; private set; }
    public List<DateTime> OvertimeinHoliday { get; private set; }

    public List<string> PersianColumnHeader =
    [
        "روز در هفته",
        "تاریخ",
        "ساعت ورود",
        "ساعت خروج",
        "ساعت ورود 2",
        "ساعت خروج 2",
        "حضور به دقیقه",
        "حضور به ساعت",
        "ورود با تاخیر",
        "اختلاف تاخیر به دقیقه",
        "اختلاف اضافه کاری به ساعت",
        "روز کاری کامل",
        "مقدار کسری",
        "ردیف ناقص"
    ];

    public AttendanceCalculationService(AppServices recordService)
    {
        _recordService = recordService;
    }

    public AttendanceCalculationService WithLateTime(TimeSpan lateTime)
    {
        _lateTm = lateTime;
        return this;
    }

    public AttendanceCalculationService WithFullWorkTime(TimeSpan fullWorkTime)
    {
        _fullWorkTm = fullWorkTime;
        return this;
    }

    public AttendanceCalculationService WithFullWorkThursdayTime(TimeSpan thursdayTime)
    {
        _fullWorkThursdayTm = thursdayTime;
        return this;
    }

    public AttendanceCalculationService WithFullWorkFarvardinTime(TimeSpan farvardinTime)
    {
        _fullWorkFarvardinTm = farvardinTime;
        return this;
    }

    public AttendanceCalculationService WithFullWorkRamadanTime(TimeSpan ramadanTime)
    {
        _fullWorkRamadanTm = ramadanTime;
        return this;
    }

    public AttendanceCalculationService WithNaqesWorkTime(TimeSpan fullWorkTime)
    {
        _naqesWorkTm = fullWorkTime;
        return this;
    }

    public AttendanceCalculationService WithNaqesWorkThursdayTime(TimeSpan thursdayTime)
    {
        _naqesWorkThursdayTm = thursdayTime;
        return this;
    }

    public AttendanceCalculationService WithNaqesWorkFarvardinTime(TimeSpan farvardinTime)
    {
        _naqesWorkFarvardinTm = farvardinTime;
        return this;
    }

    public AttendanceCalculationService WithNaqesWorkRamadanTime(TimeSpan ramadanTime)
    {
        _naqesWorkRamadanTm = ramadanTime;
        return this;
    }

    public List<WorkRecord> Calculate(string userId, string fromDateTime, string toDateTime, bool autoEditNaqesRows = true)
    {
        var filtered = DataFilterService.ApplyFilter(_recordService.Records, fromDateTime, toDateTime, int.Parse(userId)).ToArray();

        if (filtered?.Any() == false || filtered is null)
            throw new ArgumentNullException($"داده ای وجود ندارد"); // اگر داده‌ای وجود نداشت، استثنا ایجاد می‌شود

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
        OvertimeinHoliday = pr.Where(holidays.Contains).Select(g => g.Date.Date).ToList();

        //رمضان
        var ramadanDaysList = pr.Where(ramadanDays.Contains).Select(g => g.Date.Date).ToList();

        var groupedData = dataFilteredGrouped.Select(g =>
        {
            var overtime = TimeSpan.Zero; // مقدار پیش‌فرض اضافه کاری

            var kasri = TimeSpan.Zero; // مقدار پیش‌فرض کسری ساعت

            var orderedTimes = g.Select(x => x.DateTime).ToArray(); // آرایه‌ای از زمان‌های ورودی و خروجی

            var minDateTime = orderedTimes.First(); // زمان ورودی اولین کارمند
            var maxDateTime = orderedTimes.ElementAtOrDefault(1); // زمان خروج اولین کارمند

            if (orderedTimes.Length == 1 && minDateTime.Hour < 14)
            {
                minDateTime = minDateTime.Date + new TimeSpan(08, 15, 00);
                maxDateTime = orderedTimes.First();
            }

            // بررسی اینکه آیا فرد در تعطیلات کار کرده است
            var IsWorkinginHoliday = OvertimeinHoliday.Contains(minDateTime.Date.Date);

            // بررسی اینکه آیا روز جاری پنجشنبه است
            var isThursday = minDateTime.DayOfWeek == DayOfWeek.Thursday;

            //ایا رمضان است روز جاری؟
            var isRamadan = ramadanDaysList.Contains((minDateTime.Date));

            // بررسی اینکه آیا روز جاری در ماه فروردین است
            var isFarvardin = farvardinDays.Contains(minDateTime.Date);

            //ناقص
            var naqes = _naqesWorkTm;
            if (isThursday)
                naqes = _naqesWorkThursdayTm;
            if (isRamadan)
                naqes = _naqesWorkRamadanTm;
            if (isFarvardin)
                naqes = _naqesWorkFarvardinTm;

            if (maxDateTime == DateTime.MinValue)
            {
                maxDateTime = autoEditNaqesRows
                    ? minDateTime.Date + naqes
                    : minDateTime;
            }

            // اگر زمان ورودی و خروجی دوم وجود داشته باشد
            DateTime? minDateTime2 = orderedTimes.Count() > 2 ? orderedTimes.ElementAt(2) : null;
            DateTime? maxDateTime2 = orderedTimes.Count() > 2 ? orderedTimes.Last() : null;

            // محاسبه مدت زمان حضور (ورود - خروج)
            var duration = maxDateTime - minDateTime;
            var duration2 = minDateTime2.HasValue && maxDateTime2.HasValue
                ? maxDateTime2.Value - minDateTime2.Value
                : TimeSpan.Zero;

            // جمع مدت زمان حضور
            var totalDuration = duration + duration2;

            // بررسی اینکه آیا مدت زمان کاری کمتر از یک ساعت است و فرد در تعطیلات نبوده است
            var isNaghes = totalDuration.TotalMinutes < 60 && !IsWorkinginHoliday;

            // محاسبه زمان تاخیر
            var lateMinutes = minDateTime.TimeOfDay > _lateTm && totalDuration.TotalMinutes > 60 && !IsWorkinginHoliday
                ? minDateTime.TimeOfDay - _lateTm
                : TimeSpan.Zero;

            // تعیین ساعات کاری استاندارد بر اساس روز هفته
            var standardWorkTime = isThursday ? _fullWorkThursdayTm
                : isFarvardin ? _fullWorkFarvardinTm
                : isRamadan ? _fullWorkRamadanTm
                : _fullWorkTm;

            // بررسی اینکه آیا فرد ساعت کامل کار کرده است یا نه
            var fullWork = false;
            if (totalDuration >= standardWorkTime)
            {
                overtime = totalDuration - standardWorkTime; // اضافه کاری محاسبه می‌شود
                fullWork = true;
            }
            else if (totalDuration < standardWorkTime && !IsWorkinginHoliday && !isNaghes)
            {
                kasri = standardWorkTime - totalDuration; // کسری ساعت محاسبه می‌شود
            }

            return new WorkRecord
            {
                DayOfWeek = g.Key.Date.ToString("dddd"),
                Date = g.Key.Date.ToString("yyyy/MM/dd"),
                EntryTime = minDateTime.ToString("HH:mm:ss"),
                ExitTime = maxDateTime.ToString("HH:mm:ss"),
                EntryTime2 = minDateTime2?.ToString("HH:mm:ss"),
                ExitTime2 = maxDateTime2?.ToString("HH:mm:ss"),
                DurationMin = totalDuration.TotalMinutes,
                DurationHour = $"{(int)totalDuration.TotalHours:D2}h {totalDuration.Minutes:D2}m",
                IsLate = lateMinutes != TimeSpan.Zero && !IsWorkinginHoliday,
                LateMinutes = lateMinutes,
                Overtime = overtime.ToString(@"hh\:mm\:ss"),
                IsFullWork = fullWork,
                Kasri = kasri.TotalMinutes,
                IsNaghes = isNaghes
            };
        }).ToArray();

        #region GroupingAttendanceCalculation

        // محاسبه جمع دقیقه‌های تاخیر
        var totalLateMinutes = TimeSpan.FromMinutes(groupedData.Sum(x => x.LateMinutes.TotalMinutes));

        // محاسبه جمع دقیقه‌های اضافه کاری
        var totalOvertimeMinutes = TimeSpan.FromMinutes(groupedData.Sum(x => TimeSpan.Parse(x.Overtime).TotalMinutes));

        // تعداد روزهای ناقص که مدت زمان آن‌ها کمتر از یک ساعت بوده است
        var totalling = groupedData.Count(x => x.DurationMin < 60);

        // جمع کل دقایق کاری
        var totalMinutes = groupedData.Sum(x => x.DurationMin);

        // محاسبه میانگین زمان ورود
        var entryTimes = groupedData.Select(x => TimeSpan.Parse(x.EntryTime)).ToList();
        var avgEntryTime = TimeSpan.FromTicks((long)entryTimes.Average(t => t.Ticks));

        // محاسبه میانگین زمان خروج
        var exitTimes = groupedData.Select(x => TimeSpan.Parse(x.ExitTime)).ToList();
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
        var absence = workDays.Where(day => !pr.Contains(day) && !holidays.Contains(day));
        var absenceCount = absence.Count();

        // تعیین روزهای غیبت و تعطیلات
        QeybathaDaysList = absence.ToList();
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
        var kasriTime = TimeSpan.FromMinutes(groupedData.Sum(x => x.Kasri));

        // محاسبه تعدیل یا اضافه کاری خالص
        var tadil = totalOvertimeMinutes - kasriTime;

        #endregion

        Report = new AttendanceReport
        {
            // مجموع روزهای کاری (تعداد کل روزهای کاری که فرد در سیستم ثبت کرده است)
            TotalWorkDays = $"{groupedData?.Count()} از {groupedData.Count() + absenceCount}",

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
            TotalKasriTime = $@"{(int)kasriTime.TotalHours:D2}:{kasriTime.Minutes:D2}:{kasriTime.Seconds:D2}",

            // مقدار تعدیل یا اضافه ساعت کاری خالص (مجموع ساعات اضافه کاری که باید تعدیل شود یا اضافه شود به صورت دقیقه)
            TotalAdjustmentOrOvertime = tadil.TotalMinutes.ToString("0") + "m"
        };

        return groupedData.ToList();
    }

    public Dictionary<string, string> GetDataWithTitle()
    {
        return new Dictionary<string, string>
        {
            { "مجموع روز های کاری", Report.TotalWorkDays },
            { "مجموع روز کاری کامل طبق قانون کار", Report.TotalFullWorkDays },
            { "مجموع ساعات کاری", Report.TotalWorkingHours },
            { "مجموع دقایق کاری", Report.TotalMinutesWorked },
            { "مجموع روز های ورود باتاخیر", Report.TotalLateDays },
            { "مجموع تاخیر ها به ساعت", Report.TotalLateTime },
            { "مجموع روز های ناقص", Report.TotalIncompleteDays },
            { "مجموع غیبت (غیر تعطیلات)", Report.TotalAbsenceDays },
            { "مجموع اضافه کاری", Report.TotalOvertimeDays },
            { "مجموع اضافه کاری بعد ساعت کاری", Report.TotalOvertimeAfterWork },
            { "زودترین زمان ورود", Report.EarliestEntryTime },
            { "دیرترین زمان خروج", Report.LatestExitTime },
            { "میانگین ساعت های ورود", Report.AverageEntryTime },
            { "میانگین ساعت های خروج", Report.AverageExitTime },
            { "میانگین ساعت کاری روزانه", Report.AverageWorkdayHours },
            { "مقدار کسری به ساعت", Report.TotalKasriTime },
            { "مقدار تعدیل یا اضافه ساعت کاری خالص", Report.TotalAdjustmentOrOvertime }
        };
    }
}
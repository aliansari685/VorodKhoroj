//namespace VorodKhoroj.Services;

//public class AttendanceCalculationService
//{
//    private readonly IDataRepository _dataRepository;

//    public AttendanceCalculationService(IDataRepository dataRepository)
//    {
//        _dataRepository = dataRepository;
//    }

//    public async Task<AttendanceResult> CalculateAttendanceAsync(DateRange dateRange, string userId, TimeSettings timeSettings)
//    {
//        var records = await _dataRepository.GetRecordsAsync(dateRange.From, dateRange.To, int.Parse(userId));
//        if (records?.Any() != true) throw new ArgumentNullException("داده‌ای وجود ندارد");

//        var attendanceRecords = CalculateDailyRecords(records, timeSettings);
//        var summaryLabels = GenerateSummaryLabels(attendanceRecords);
//        return new AttendanceResult(attendanceRecords, summaryLabels);
//    }

//    private IEnumerable<AttendanceRecord> CalculateDailyRecords(IEnumerable<Record> records, TimeSettings timeSettings)
//    {
//        var farvardinDays = PersianDateHelper.GetWorkDays_Farvardin().Select(d => d.Date).ToHashSet();

//        return records
//            .GroupBy(x => (x.UserId, x.DateTime.Date))
//            .Select(g => CalculateSingleDay(g, timeSettings, farvardinDays))
//            .ToArray();
//    }

//    private AttendanceRecord CalculateSingleDay(IGrouping<(int UserId, DateTime Date), Record> dayRecords,
//                                               TimeSettings timeSettings, HashSet<DateTime> farvardinDays)
//    {
//        var times = dayRecords.Select(x => x.DateTime).OrderBy(t => t).ToArray();
//        var entryTime = times.First();
//        var exitTime = times.ElementAtOrDefault(1) == DateTime.MinValue ? entryTime : times.ElementAt(1);
//        var entryTime2 = times.Length > 2 ? times[2] : (DateTime?)null;
//        var exitTime2 = times.Length > 2 ? times.Last() : null;

//        var totalDuration = (exitTime - entryTime) +
//                           (entryTime2.HasValue && exitTime2.HasValue ? exitTime2.Value - entryTime2.Value : TimeSpan.Zero);

//        var isThursday = entryTime.DayOfWeek == DayOfWeek.Thursday;
//        var isFarvardin = farvardinDays.Contains(entryTime.Date);
//        var standardWorkTime = isThursday ? timeSettings.FullWorkThursday
//            : isFarvardin ? timeSettings.FullWorkFarvardin
//            : timeSettings.FullWorkDay;

//        var lateMinutes = entryTime.TimeOfDay > timeSettings.LateThreshold && totalDuration.TotalMinutes > 60
//            ? entryTime.TimeOfDay - timeSettings.LateThreshold
//            : TimeSpan.Zero;

//        var overtime = totalDuration > standardWorkTime ? totalDuration - standardWorkTime : TimeSpan.Zero;
//        var kasri = totalDuration < standardWorkTime ? standardWorkTime - totalDuration : TimeSpan.Zero;

//        return new AttendanceRecord
//        {
//            DayOfWeek = entryTime.ToString("dddd"),
//            Date = entryTime.ToString("yyyy/MM/dd"),
//            EntryTime = entryTime.ToString("HH:mm:ss"),
//            ExitTime = exitTime.ToString("HH:mm:ss"),
//            EntryTime2 = entryTime2?.ToString("HH:mm:ss"),
//            ExitTime2 = exitTime2?.ToString("HH:mm:ss"),
//            DurationMinutes = totalDuration.TotalMinutes,
//            DurationHours = $"{(int)totalDuration.TotalHours:D2}h {totalDuration.Minutes:D2}m",
//            IsLate = lateMinutes != TimeSpan.Zero,
//            LateMinutes = lateMinutes,
//            Overtime = overtime.ToString(@"hh\:mm\:ss"),
//            FullWork = totalDuration >= standardWorkTime,
//            KasriMinutes = kasri.TotalMinutes,
//            Is incomplete = totalDuration.TotalMinutes < 60
//        };
//    }

//    private Dictionary<string, string> GenerateSummaryLabels(IEnumerable<AttendanceRecord> records)
//    {
//        // منطق محاسبه لیبل‌های خلاصه (مثل مجموع تاخیر، اضافه‌کاری و ...) اینجا می‌ره
//        // برای خلاصه بودن فقط یه نمونه می‌ذارم
//        var totalLate = TimeSpan.FromMinutes(records.Sum(r => r.LateMinutes.TotalMinutes));
//        return new Dictionary<string, string>
//        {
//            { "مجموع تاخیرها به ساعت", $"{(int)totalLate.TotalHours:D2}:{totalLate.Minutes:D2}:{totalLate.Seconds:D2}" }
//            // بقیه لیبل‌ها مشابه کد اصلی اضافه بشن
//        };
//    }
//}

//// مدل‌های داده
//public class AttendanceRecord
//{
//    public string DayOfWeek { get; set; }
//    public string Date { get; set; }
//    public string EntryTime { get; set; }
//    public string ExitTime { get; set; }
//    public string EntryTime2 { get; set; }
//    public string ExitTime2 { get; set; }
//    public double DurationMinutes { get; set; }
//    public string DurationHours { get; set; }
//    public bool IsLate { get; set; }
//    public TimeSpan LateMinutes { get; set; }
//    public string Overtime { get; set; }
//    public bool FullWork { get; set; }
//    public double KasriMinutes { get; set; }
//    public bool IsIncomplete { get; set; }
//}

//public class AttendanceResult
//{
//    public IEnumerable<AttendanceRecord> Records { get; }
//    public Dictionary<string, string> SummaryLabels { get; }
//    public AttendanceResult(IEnumerable<AttendanceRecord> records, Dictionary<string, string> summaryLabels)
//    {
//        Records = records;
//        SummaryLabels = summaryLabels;
//    }
//}

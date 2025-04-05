namespace VorodKhoroj.Services;

public class AttendanceCalculationService
{
    private readonly AppServices _recordService;

    private TimeSpan _lateTm = TimeSpan.Parse("08:30:00");
    private TimeSpan _fullworkTm = TimeSpan.Parse("08:30:00");
    private TimeSpan _fullwork_ThursdayTm = TimeSpan.Parse("05:30:00");
    private TimeSpan _fullwork_FarvardinTm = TimeSpan.Parse("07:45:00");

    public List<DateTime> QeybathaDaysList { get; private set; }
    public List<DateTime> HolidaysDaysList { get; private set; }
    public Dictionary<string, string> Labels { get; private set; }

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
        _fullworkTm = fullWorkTime;
        return this;
    }

    public AttendanceCalculationService WithFullWorkThursdayTime(TimeSpan thursdayTime)
    {
        _fullwork_ThursdayTm = thursdayTime;
        return this;
    }

    public AttendanceCalculationService WithFullWorkFarvardinTime(TimeSpan farvardinTime)
    {
        _fullwork_FarvardinTm = farvardinTime;
        return this;
    }

    public Array Calculate(string userId, string fromDateTime, string toDateTime)
    {
        var filtered = DataFilterService.ApplyFilter(
            _recordService.Records, fromDateTime, toDateTime, int.Parse(userId));

        if (filtered?.Any() == false)
            throw new ArgumentNullException("داده ای وجود ندارد");

        var farvardinDays = PersianDateHelper.GetWorkDays_Farvardin().Select(d => d.Date).ToHashSet();

        var dataFiltered = filtered.Select(x => new { x.UserId, x.DateTime })
            .OrderBy(x => x.DateTime);

        var dataFilteredGrouped = dataFiltered.GroupBy(x => (x.UserId, x.DateTime.Date)).ToList();

        // تاریخ‌هایی که کارمند حضور داشته است
        var pr = dataFilteredGrouped.Select(g => g.Key.Date).ToList();

        var holidays = PersianDateHelper.GetHolidays().Select(h => h.Date.Date).ToList(); // تاریخ تعطیلات

        var overtimeinHoliday = pr.Where(day => holidays.Contains(day)).Select(g => g.Date.Date).ToList();

        var groupedData = dataFilteredGrouped.Select(g =>
        {
            var overtime = TimeSpan.Zero;
            var kasri = TimeSpan.Zero;

            var orderedTimes = g.Select(x => x.DateTime).ToArray();

            var minDateTime = orderedTimes.First();
            var maxDateTime = orderedTimes.ElementAtOrDefault(1);
            if (maxDateTime == DateTime.MinValue) maxDateTime = minDateTime;

            DateTime? minDateTime2 = orderedTimes.Count() > 2 ? orderedTimes.ElementAt(2) : null;
            DateTime? maxDateTime2 = orderedTimes.Count() > 2 ? orderedTimes.Last() : null;

            var IsWorkinginHoliday = overtimeinHoliday.Contains(minDateTime.Date.Date);
            var isThursday = minDateTime.DayOfWeek == DayOfWeek.Thursday;
            var isFarvardin = farvardinDays.Contains(minDateTime.Date);

            var duration = maxDateTime - minDateTime;
            var duration2 = minDateTime2.HasValue && maxDateTime2.HasValue
                ? maxDateTime2.Value - minDateTime2.Value
                : TimeSpan.Zero;

            var totalDuration = duration + duration2;
            var isNaghes = totalDuration.TotalMinutes < 60 && !IsWorkinginHoliday;

            var lateMinutes = minDateTime.TimeOfDay > _lateTm && totalDuration.TotalMinutes > 60 && !IsWorkinginHoliday
                ? minDateTime.TimeOfDay - _lateTm
                : TimeSpan.Zero;

            var standardWorkTime = isThursday ? _fullwork_ThursdayTm
                : isFarvardin ? _fullwork_FarvardinTm
                : _fullworkTm;

            var fullWork = false;
            if (totalDuration >= standardWorkTime)
            {
                overtime = totalDuration - standardWorkTime;
                fullWork = true;
            }
            else if (totalDuration < standardWorkTime && !IsWorkinginHoliday && !isNaghes)
            {
                kasri = standardWorkTime - totalDuration;
            }

            return new
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
                FullWork = fullWork,
                IsKasri = kasri.TotalMinutes,
                IsNaghes = isNaghes
            };
        }).ToArray();

        // محاسبه اطلاعات
        var totalLateMinutes = TimeSpan.FromMinutes(groupedData.Sum(x => x.LateMinutes.TotalMinutes));
        var totalOvertimeMinutes = TimeSpan.FromMinutes(groupedData.Sum(x => TimeSpan.Parse(x.Overtime).TotalMinutes));
        var totalling = groupedData.Count(x => x.DurationMin < 60);
        var totalMinutes = groupedData.Sum(x => x.DurationMin);
        var entryTimes = groupedData.Select(x => TimeSpan.Parse(x.EntryTime)).ToList();
        var avgEntryTime = TimeSpan.FromTicks((long)entryTimes.Average(t => t.Ticks));
        var exitTimes = groupedData.Select(x => TimeSpan.Parse(x.ExitTime)).ToList();
        var avgExitTime = TimeSpan.FromTicks((long)exitTimes.Average(t => t.Ticks));
        var totalHours = TimeSpan.FromMinutes(totalMinutes);
        var total = groupedData.Count(x => x.FullWork);
        var lateDays = groupedData.Count(x => x.IsLate);

        var workDays = Enumerable.Range(0, (DateTime.Parse(toDateTime) - DateTime.Parse(fromDateTime)).Days + 1)
            .Select(i => DateTime.Parse(fromDateTime).AddDays(i))
            .ToList();

        var absence = workDays.Where(day => !pr.Contains(day) && !holidays.Contains(day));
        var absenceCount = absence.Count();

        QeybathaDaysList = absence.ToList();
        HolidaysDaysList = workDays.Where(day => holidays.Contains(day)).ToList();

        var overtimeCount = pr.Count(day => holidays.Contains(day));
        var minEntryTime = TimeSpan.FromTicks(entryTimes.Min(t => t.Ticks));
        var maxExitTime = TimeSpan.FromTicks(exitTimes.Max(t => t.Ticks));
        var avgMinutes = totalMinutes / groupedData.Count();
        var avgTimeSpan = TimeSpan.FromMinutes(avgMinutes);
        var kasriTime = TimeSpan.FromMinutes(groupedData.Sum(x => x.IsKasri));
        var tadil = totalOvertimeMinutes - kasriTime;

        Labels = new Dictionary<string, string>
        {
            { "مجموع روز های کاری", $"{groupedData?.Count()} از {groupedData.Count() + absenceCount}" },
            { "مجموع روز کاری کامل طبق 8 ساعت 30 دقیقه کار", total.ToString() },
            { "مجموع ساعات کاری", $@"{(int)totalHours.TotalHours:D2}:{totalHours.Minutes:D2}" },
            { "مجموع دقایق کاری", totalMinutes.ToString("0") + "m" },
            { "مجموع روز های ورود باتاخیر", lateDays.ToString() },
            {
                "مجموع تاخیر ها به ساعت",
                $@"{(int)totalLateMinutes.TotalHours:D2}:{totalLateMinutes.Minutes:D2}:{totalLateMinutes.Seconds:D2}"
            },
            { "مجموع روز های ناقص", totalling.ToString() },
            { "مجموع غیبت (غیر تعطیلات)", absenceCount.ToString() },
            { "مجموع اضافه کاری", overtimeCount.ToString() },
            {
                " مجموع اضافه کاری بعد ساعت کاری",
                $@"{(int)totalOvertimeMinutes.TotalHours:D2}:{totalOvertimeMinutes.Minutes:D2}:{totalOvertimeMinutes.Seconds:D2}"
            },
            { "زودترین زمان ورود", minEntryTime.ToString(@"hh\:mm\:ss") },
            { "دیرترین زمان خروج", maxExitTime.ToString(@"hh\:mm\:ss") },
            { "میانگین ساعت های ورود", avgEntryTime.ToString(@"hh\:mm\:ss") },
            { "میانگین ساعت های خروج", avgExitTime.ToString(@"hh\:mm\:ss") },
            { "میانگین ساعت کاری روزانه", avgTimeSpan.ToString(@"hh\:mm\:ss") },
            { "مقدار کسری به ساعت", $@"{(int)kasriTime.TotalHours:D2}:{kasriTime.Minutes:D2}:{kasriTime.Seconds:D2}" },
            { "مقدار تعدیل یا اضافه ساعت کاری خالص", tadil.TotalMinutes.ToString() }
        };

        return groupedData.ToArray();
    }
}
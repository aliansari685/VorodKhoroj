namespace VorodKhoroj.Models
{
    public class WorkRecord
    {
        [DisplayName("روز در هفته")]
        public string? DayOfWeek { get; set; }

        [DisplayName("تاریخ")]
        public string? Date { get; set; }

        [DisplayName("ساعت ورود")]
        public string? EntryTime { get; set; }

        [DisplayName("ساعت خروج")]
        public string? ExitTime { get; set; }

        [DisplayName("ساعت ورود 2")]
        public string? EntryTime2 { get; set; }

        [DisplayName("ساعت خروج 2")]
        public string? ExitTime2 { get; set; }

        [DisplayName("حضور به دقیقه")]
        public double DurationMin { get; set; }

        [DisplayName("حضور به ساعت")]
        public string? DurationHour { get; set; }

        [DisplayName("ورود با تاخیر")]
        public bool IsLate { get; set; }

        [DisplayName("اختلاف تاخیر به دقیقه")]
        public TimeSpan LateMinutes { get; set; }

        [DisplayName("اختلاف اضافه کاری به ساعت")]
        public string? Overtime { get; set; }

        [DisplayName("روز کاری کامل")]
        public bool IsFullWork { get; set; }

        [DisplayName("مقدار کسری")]
        public double Kasri { get; set; }

        [DisplayName("ردیف ناقص")]
        public bool IsNaghes { get; set; }
    }

}

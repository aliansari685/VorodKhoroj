namespace VorodKhoroj.Models
{
    public class AttendanceReport
    {
        [DisplayName("مجموع روز های کاری")]
        public required string TotalWorkDays { get; set; }

        [DisplayName("مجموع روز کاری کامل طبق قانون کار")]
        public string TotalFullWorkDays { get; set; }

        [DisplayName("مجموع ساعات کاری")]
        public string TotalWorkingHours { get; set; }

        [DisplayName("مجموع دقایق کاری")]
        public string TotalMinutesWorked { get; set; }

        [DisplayName("مجموع روز های ورود باتاخیر")]
        public string TotalLateDays { get; set; }

        [DisplayName("مجموع تاخیر ها به ساعت")]
        public string TotalLateTime { get; set; }

        [DisplayName("مجموع روز های ناقص")]
        public string TotalIncompleteDays { get; set; }

        [DisplayName("مجموع غیبت (غیر تعطیلات)")]
        public string TotalAbsenceDays { get; set; }

        [DisplayName("مجموع اضافه کاری")]
        public string TotalOvertimeDays { get; set; }

        [DisplayName("مجموع اضافه کاری بعد ساعت کاری")]
        public string TotalOvertimeAfterWork { get; set; }

        [DisplayName("زودترین زمان ورود")]
        public string EarliestEntryTime { get; set; }

        [DisplayName("دیرترین زمان خروج")]
        public string LatestExitTime { get; set; }

        [DisplayName("میانگین ساعت های ورود")]
        public string AverageEntryTime { get; set; }

        [DisplayName("میانگین ساعت های خروج")]
        public string AverageExitTime { get; set; }

        [DisplayName("میانگین ساعت کاری روزانه")]
        public string AverageWorkdayHours { get; set; }

        [DisplayName("مقدار کسری به ساعت")]
        public string TotalKasriTime { get; set; }

        [DisplayName("مقدار تعدیل یا اضافه ساعت کاری خالص")]
        public string TotalAdjustmentOrOvertime { get; set; }

    }
}

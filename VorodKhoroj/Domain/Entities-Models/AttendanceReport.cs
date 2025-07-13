namespace VorodKhoroj.Models
{
    public class AttendanceReport
    {
        [DisplayName("مجموع روز های کاری")]
        public required string TotalWorkDays { get; set; }

        [DisplayName("مجموع روز کاری کامل طبق قانون کار")]
        public required string TotalFullWorkDays { get; set; }

        [DisplayName("مجموع ساعات کاری")]
        public required string TotalWorkingHours { get; set; }

        [DisplayName("مجموع دقایق کاری")]
        public required string TotalMinutesWorked { get; set; }

        [DisplayName("مجموع روز های ورود باتاخیر")]
        public required string TotalLateDays { get; set; }

        [DisplayName("مجموع تاخیر ها به ساعت")]
        public required string TotalLateTime { get; set; }

        [DisplayName("مجموع روز های ناقص")]
        public required string TotalIncompleteDays { get; set; }

        [DisplayName("مجموع غیبت (غیر تعطیلات)")]
        public required string TotalAbsenceDays { get; set; }

        [DisplayName("مجموع اضافه کاری")]
        public required string TotalOvertimeDays { get; set; }

        [DisplayName("مجموع اضافه کاری بعد ساعت کاری")]
        public required string TotalOvertimeAfterWork { get; set; }

        [DisplayName("زودترین زمان ورود")]
        public required string EarliestEntryTime { get; set; }

        [DisplayName("دیرترین زمان خروج")]
        public required string LatestExitTime { get; set; }

        [DisplayName("میانگین ساعت های ورود")]
        public required string AverageEntryTime { get; set; }

        [DisplayName("میانگین ساعت های خروج")]
        public required string AverageExitTime { get; set; }

        [DisplayName("میانگین ساعت کاری روزانه")]
        public required string AverageWorkdayHours { get; set; }

        [DisplayName("مقدار کسری به ساعت")]
        public required string TotalFractionTime { get; set; }

        [DisplayName("مقدار تعدیل یا اضافه ساعت کاری خالص")]
        public required string TotalAdjustmentOrOvertime { get; set; }

    }
}
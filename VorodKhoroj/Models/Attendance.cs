namespace VorodKhoroj.Model
{
    public class Attendance
    {
        [DisplayName("کاربر")]
        public int UserId { get; set; }

        [DisplayName("تاریخ")]
        public DateTime DateTime { get; set; }

        [StringLength(10)]
        [DisplayName("نوع ورود")]
        public string? LoginType { get; set; }
    }
}

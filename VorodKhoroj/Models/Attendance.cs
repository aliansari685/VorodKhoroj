namespace VorodKhoroj.Model
{
    public class Attendance
    {
        [Browsable(false), DisplayName("")]
        public User User { get; set; } // Navigation Property

        [Required, DisplayName("شناسه کاربر")] public int UserId { get; set; }
        [Required, DisplayName("تاریخ")] public DateTime DateTime { get; set; }

        [StringLength(10), DisplayName("نوع ورود")] public string? LoginType { get; set; }
    }
}

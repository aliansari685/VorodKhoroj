namespace VorodKhoroj.Model
{
    public class Attendance
    {
        [Browsable(false), Key] public int Id { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        [Browsable(false)] public User User { get; set; } // Navigation Property
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [Required, DisplayName("شناسه کاربر")] public int UserId { get; set; }
        [Required, DisplayName("تاریخ")] public DateTime DateTime { get; set; }

        [StringLength(10), DisplayName("نوع ورود")] public string? LoginType { get; set; }
    }
}

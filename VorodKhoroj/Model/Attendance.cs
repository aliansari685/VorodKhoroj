namespace VorodKhoroj.Model
{
    public class Attendance
    {
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }
        [StringLength(10)]
        public string LoginType { get; set; }
    }
}

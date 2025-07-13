namespace VorodKhoroj.Models
{
    public class User
    {
        [DisplayName("شناسه کاربر"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        //Identity Off(Auto Increment)
        public int UserId { get; set; }

        [DisplayName("نام کاربر"), StringLength(100)] public string Name { get; set; } = "";

        // Navigation Property
        public List<Attendance> Attendances { get; set; } = [];
    }
}

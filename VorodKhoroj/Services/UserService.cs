namespace VorodKhoroj.Services
{
    // مدیریت داده‌های  User
    public class UserService(DataRepository repository)
    {
        public void AddUser(User rec, AppDbContext ctx) => repository.AddAttendanceUser([rec], ctx);

        public void UpdateUser(User rec, AppDbContext ctx) => repository.UpdateAttendanceUser([rec], ctx);

    }
}
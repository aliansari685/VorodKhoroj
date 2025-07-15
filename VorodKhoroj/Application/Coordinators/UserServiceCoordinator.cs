using VorodKhoroj.Infrastructure.Persistence;

namespace VorodKhoroj.Application.Coordinators
{
    /// <summary>
    /// مدیریت عملیات مربوط به جدول User
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="dbInitializer"></param>
    public class UserServiceCoordinator(UserRepository repository, DbContextInitializer dbInitializer)
    {
        public void AddUser(List<User> rec)
        {
            if (dbInitializer.DbContext != null) repository.AddAttendanceUser(rec, dbInitializer.DbContext);
        }

        public void UpdateUser(User rec)
        {
            if (dbInitializer.DbContext != null) repository.UpdateAttendanceUser([rec], dbInitializer.DbContext);
        }
    }
}
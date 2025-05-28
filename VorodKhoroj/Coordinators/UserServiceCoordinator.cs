namespace VorodKhoroj.Coordinators
{
    // مدیریت داده‌های  User
    public class UserServiceCoordinator(DataRepository repository, IAppDbContextProvider dbProvider)
    {
        public void AddUser(List<User> rec)
        {
            if (dbProvider.DbContext != null) repository.AddAttendanceUser(rec, dbProvider.DbContext);
        }

        public void UpdateUser(User rec)
        {
            if (dbProvider.DbContext != null) repository.UpdateAttendanceUser([rec], dbProvider.DbContext);
        }
    }
}
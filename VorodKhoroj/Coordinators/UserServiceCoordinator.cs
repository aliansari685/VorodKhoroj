namespace VorodKhoroj.Coordinators
{
    /// <summary>
    /// مدیریت عملیات مربوط به جدول User
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="dbProvider"></param>
    public class UserServiceCoordinator(DataRepository repository, AppDbContextProvider dbProvider)
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
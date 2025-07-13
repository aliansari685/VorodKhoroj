using VorodKhoroj.Application.Services;

namespace VorodKhoroj.Application.Coordinators
{
    /// <summary>
    /// مدیریت عملیات مربوط به جدول User
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="dbConfiguration"></param>
    public class UserServiceCoordinator(DataRepository repository, AppDbContextConfiguration dbConfiguration)
    {
        public void AddUser(List<User> rec)
        {
            if (dbConfiguration.DbContext != null) repository.AddAttendanceUser(rec, dbConfiguration.DbContext);
        }

        public void UpdateUser(User rec)
        {
            if (dbConfiguration.DbContext != null) repository.UpdateAttendanceUser([rec], dbConfiguration.DbContext);
        }
    }
}
namespace VorodKhoroj.Application.Coordinators
{
    /// <summary>
    /// مدیریت عملیات مربوط به جدول User
    /// </summary>
    /// <param name="dbInitializer"></param>
    public class UserServiceCoordinator(IRepository<User> userRepository, IDbContextConfiguration dbInitializer, IDataLoader dataLoader)
    {
        /// <summary>
        /// اضافه کردن کاربر
        /// </summary>
        /// <param name="rec"></param>
        public void AddUser(List<User> rec)
        {
            if (dbInitializer.DbContext == null)
                throw new Exception("خطای دیتابیس");

            userRepository.Add(rec);
            dataLoader.LoadFromDb(dbInitializer.DbContext);
        }

        /// <summary>
        /// اپدیت کردن کاربر
        /// </summary>
        /// <param name="rec"></param>
        public void UpdateUser(User rec)
        {
            if (dbInitializer.DbContext == null)
                throw new Exception("خطای دیتابیس");

            userRepository.Update([rec]);
            dataLoader.LoadFromDb(dbInitializer.DbContext);
        }
    }
}
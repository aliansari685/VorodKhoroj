namespace VorodKhoroj.Application.Coordinators
{
    /// <summary>
    /// مدیریت عملیات مربوط به جدول User
    /// </summary>
    public class UserDataService(IRepository<User> userRepository, IDataLoader dataLoader, IDbContextConfiguration dbContextConfiguration) : IUserDataService
    {
        /// <summary>
        /// اضافه کردن کاربر
        /// </summary>
        /// <param name="rec"></param>
        public void AddUser(List<User> rec)
        {
            if (dbContextConfiguration.DbContext == null)
                throw new NullReferenceException("خطای دیتابیس");
            userRepository.Add(rec, dbContextConfiguration.DbContext);
            dataLoader.LoadFromDb();
        }

        /// <summary>
        /// اپدیت کردن کاربر
        /// </summary>
        /// <param name="rec"></param>
        public void UpdateUser(User rec)
        {
            if (dbContextConfiguration.DbContext == null)
                throw new NullReferenceException("خطای دیتابیس");
            userRepository.Update([rec], dbContextConfiguration.DbContext);
            dataLoader.LoadFromDb();
        }
    }
}
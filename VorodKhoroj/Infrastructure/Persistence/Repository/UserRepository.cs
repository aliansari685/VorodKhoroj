namespace VorodKhoroj.Infrastructure.Persistence.Repository
{
    public class UserRepository(AppDbContext context) : IRepository<User>
    {

        /// <summary>
        /// افزودن لیست کاربران به دیتابیس
        /// </summary>
        /// <param name="records">لیست کاربران</param>
        public void Add(List<User> records)
        {
            CommonHelper.ExecuteSafeQuery(() =>
            {
                context.Users.AddRange(records);
                _ = context.SaveChanges();
            });
        }

        /// <summary>
        /// بروزرسانی لیست کاربران در دیتابیس
        /// </summary>
        /// <param name="records">لیست کاربران</param>
        public void Update(List<User> records)
        {
            CommonHelper.ExecuteSafeQuery(() =>
            {
                context.Users.UpdateRange(records);
                _ = context.SaveChanges();
            });
        }

        public void Remove(List<User> entity)
        {
            throw new NotImplementedException("عملیات تعریف نشده");
        }
    }
}
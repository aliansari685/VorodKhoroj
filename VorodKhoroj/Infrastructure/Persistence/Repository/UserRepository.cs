namespace VorodKhoroj.Infrastructure.Persistence.Repository
{
    public class UserRepository : IRepository<User>
    {
        /// <summary>
        /// افزودن لیست کاربران به دیتابیس
        /// </summary>
        /// <param name="records">لیست کاربران</param>
        /// <param name="dbContext"></param>
        public void Add(List<User> records, AppDbContext dbContext)
        {
            CommonHelper.ExecuteSafeQuery(() =>
            {
                dbContext.Users.AddRange(records);
                _ = dbContext.SaveChanges();
            });
        }

        /// <summary>
        /// بروزرسانی لیست کاربران در دیتابیس
        /// </summary>
        /// <param name="records">لیست کاربران</param>
        /// <param name="dbContext"></param>
        public void Update(List<User> records, AppDbContext dbContext)
        {
            CommonHelper.ExecuteSafeQuery(() =>
            {
                dbContext.Users.UpdateRange(records);
                _ = dbContext.SaveChanges();
            });
        }

        public void Remove(List<User> entity, AppDbContext dbContext)
        {
            throw new NotImplementedException("عملیات تعریف نشده");
        }
    }
}
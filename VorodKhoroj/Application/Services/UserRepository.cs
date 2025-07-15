namespace VorodKhoroj.Application.Services
{
    public class UserRepository
    {
       
        /// <summary>
        /// افزودن لیست کاربران به دیتابیس
        /// </summary>
        /// <param name="records">لیست کاربران</param>
        /// <param name="context">کانتکست دیتابیس</param>
        public void AddAttendanceUser(List<User> records, AppDbContext context)
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
        /// <param name="context">کانتکست دیتابیس</param>
        public void UpdateAttendanceUser(List<User> records, AppDbContext context)
        {
            CommonHelper.ExecuteSafeQuery(() =>
            {
                context.Users.UpdateRange(records);
                _ = context.SaveChanges();
            });
        }
    }
}
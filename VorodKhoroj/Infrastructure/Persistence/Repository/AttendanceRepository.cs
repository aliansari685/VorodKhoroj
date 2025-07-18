namespace VorodKhoroj.Infrastructure.Persistence.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        /// <summary>
        /// استخراج آرایه‌ی شناسه‌ی یکتای کاربران از لیست حضور و غیاب
        /// </summary>
        /// <param name="list">لیست حضور و غیاب</param>
        /// <returns>آرایه شناسه کاربران</returns>
        public int[] GetUsersAttendances(List<Attendance> list)
        {
            return list.Select(x => x.UserId).Distinct().ToArray();
        }

        /// <summary>
        /// افزودن کاربران و حضور و غیاب آنها به دیتابیس با اجرای ایمن
        /// </summary>
        /// <param name="records">لیست رکوردهای حضور و غیاب</param>
        /// <param name="dbContext"></param>
        public void AddAttendancesWithUsers(List<Attendance> records, AppDbContext dbContext)
        {
            CommonHelper.ExecuteSafeQuery(() =>
            {
                var users = GetUsersAttendances(records)
                    .Select(id => new User { UserId = id })
                    .ToList();

                dbContext.Users.AddRange(users);
                _ = dbContext.SaveChanges();

                dbContext.Attendances.AddRange(records);
                _ = dbContext.SaveChanges();

                dbContext.Database.GetDbConnection().Close();
            });
        }

        /// <summary>
        /// افزودن لیست حضور و غیاب به دیتابیس
        /// </summary>
        /// <param name="records">لیست حضور و غیاب</param>
        /// <param name="dbContext"></param>
        public void Add(List<Attendance> records, AppDbContext dbContext)
        {
            CommonHelper.ExecuteSafeQuery(() =>
            {
                dbContext.Attendances.AddRange(records);
                dbContext.SaveChanges();
            });
        }

        /// <summary>
        /// حذف لیست حضور و غیاب از دیتابیس
        /// </summary>
        /// <param name="records">لیست حضور و غیاب</param>
        /// <param name="dbContext"></param>
        public void Remove(List<Attendance> records, AppDbContext dbContext)
        {
            CommonHelper.ExecuteSafeQuery(() =>
            {
                dbContext.Attendances.RemoveRange(records);
                _ = dbContext.SaveChanges();
            });
        }

        /// <summary>
        /// بروزرسانی لیست حضور و غیاب در دیتابیس
        /// </summary>
        /// <param name="records">لیست حضور و غیاب</param>
        /// <param name="dbContext"></param>
        public void Update(List<Attendance> records, AppDbContext dbContext)
        {
            CommonHelper.ExecuteSafeQuery(() =>
            {
                dbContext.Attendances.UpdateRange(records);
                _ = dbContext.SaveChanges();
            });
        }

    }
}

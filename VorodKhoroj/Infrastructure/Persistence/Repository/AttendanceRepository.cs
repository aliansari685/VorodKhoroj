namespace VorodKhoroj.Infrastructure.Persistence.Repository
{
    public class AttendanceRepository(AppDbContext context) //: IRepository<Attendance>
    {
        private readonly AppDbContext _context = context;

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
        public void AddAttendancesWithUsers(List<Attendance> records )
        {
            CommonHelper.ExecuteSafeQuery(() =>
            {
                var users = GetUsersAttendances(records)
                    .Select(id => new User { UserId = id })
                    .ToList();

                context.Users.AddRange(users);
                _ = context.SaveChanges();

                context.Attendances.AddRange(records);
                _ = context.SaveChanges();

                context.Database.GetDbConnection().Close();
            });
        }

        /// <summary>
        /// افزودن لیست حضور و غیاب به دیتابیس
        /// </summary>
        /// <param name="records">لیست حضور و غیاب</param>
        public void Add(List<Attendance> records)
        {
            CommonHelper.ExecuteSafeQuery(() =>
            {
                context.Attendances.AddRange(records);
                context.SaveChanges();
            });
        }

        /// <summary>
        /// حذف لیست حضور و غیاب از دیتابیس
        /// </summary>
        /// <param name="records">لیست حضور و غیاب</param>
        public void Delete(List<Attendance> records)
        {
            CommonHelper.ExecuteSafeQuery(() =>
            {
                context.Attendances.RemoveRange(records);
                _ = context.SaveChanges();
            });
        }

        /// <summary>
        /// بروزرسانی لیست حضور و غیاب در دیتابیس
        /// </summary>
        /// <param name="records">لیست حضور و غیاب</param>
        public void Update(List<Attendance> records)
        {
            CommonHelper.ExecuteSafeQuery(() =>
            {
                context.Attendances.UpdateRange(records);
                _ = context.SaveChanges();
            });
        }

    }
}

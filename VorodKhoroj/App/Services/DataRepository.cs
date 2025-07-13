namespace VorodKhoroj.Application.Services
{
    public class DataRepository
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
        /// <param name="context">کانتکست دیتابیس</param>
        public void AddAttendancesAndUsers(List<Attendance> records, AppDbContext context)
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
        /// <param name="context">کانتکست دیتابیس</param>
        public void AddAttendance(List<Attendance> records, AppDbContext context)
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
        /// <param name="context">کانتکست دیتابیس</param>
        public void DeleteAttendance(List<Attendance> records, AppDbContext context)
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
        /// <param name="context">کانتکست دیتابیس</param>
        public void UpdateAttendance(List<Attendance> records, AppDbContext context)
        {
            CommonHelper.ExecuteSafeQuery(() =>
            {
                context.Attendances.UpdateRange(records);
                _ = context.SaveChanges();
            });
        }

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
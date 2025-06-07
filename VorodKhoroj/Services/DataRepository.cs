namespace VorodKhoroj.Services
{
    public class DataRepository
    {
        /// <summary>
        /// اجرای ایمن یک اکشن با مدیریت خطاهای دیتابیس و عمومی
        /// </summary>
        /// <param name="action">اکشنی که باید اجرا شود</param>
        private void ExecuteSafeQuery(Action action)
        {
            try
            {
                action();
            }
            catch (DbUpdateException ex)
            {
                CommonHelper.ShowMessage(ex);
            }
            catch (DbException ex)
            {
                CommonHelper.ShowMessage(ex);
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }

        /// <summary>
        /// خواندن رکوردهای حضور و غیاب از فایل متنی با فرمت تب جدا شده
        /// </summary>
        /// <param name="fileAddress">آدرس فایل</param>
        /// <returns>لیستی از رکوردهای Attendance</returns>
        public List<Attendance> GetRecordsFromFile(string fileAddress)
        {
            List<Attendance> records = new List<Attendance>();
            foreach (var line in File.ReadAllLines(fileAddress))
            {
                var values = line.Split('\t');
                if (values.Length == 6)
                {
                    records.Add(new Attendance
                    {
                        UserId = int.Parse(values[0]),
                        DateTime = PersianDateHelper.ConvertToShamsi(values[1]),
                        LoginType = GetLoginType(values[4])
                    });
                }
            }
            return records;
        }

        /// <summary>
        /// تبدیل کد عددی ورود به نوع ورود به صورت رشته‌ای
        /// </summary>
        /// <param name="number">کد عددی ورود</param>
        /// <returns>نوع ورود به صورت رشته</returns>
        public string GetLoginType(string number)
        {
            var num = int.Parse(number);
            return num switch
            {
                15 => "Face",
                1 => "Finger",
                _ => "",
            };
        }

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
            ExecuteSafeQuery(() =>
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
            ExecuteSafeQuery(() =>
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
            ExecuteSafeQuery(() =>
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
            ExecuteSafeQuery(() =>
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
            ExecuteSafeQuery(() =>
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
            ExecuteSafeQuery(() =>
            {
                context.Users.UpdateRange(records);
                _ = context.SaveChanges();
            });
        }
    }
}
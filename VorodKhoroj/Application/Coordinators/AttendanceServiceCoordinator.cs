using VorodKhoroj.Infrastructure.Persistence;

namespace VorodKhoroj.Application.Coordinators
{
    // مدیریت عملیات مربوط به داده‌های Attendance با استفاده از Repository و DbContext
    public class AttendanceServiceCoordinator(UserRepository repository, DbContextInitializer dbInitializer)
    {
        // کپی کردن لیستی از رکوردهای Attendance به دیتابیس
        public void CopyRecords(List<Attendance> recs)
        {
            if (dbInitializer.DbContext != null)
                repository.AddAttendancesAndUsers(recs, dbInitializer.DbContext);
            else
                throw new Exception("خطای دیتابیس");
        }

        // افزودن لیستی از رکوردهای Attendance به دیتابیس
        public void AddAttendance(List<Attendance> rec)
        {
            if (dbInitializer.DbContext != null)
                repository.AddAttendance(rec, dbInitializer.DbContext);
            else
                throw new Exception("خطای دیتابیس");
        }

        // به‌روزرسانی یک رکورد Attendance
        public void UpdateAttendance(Attendance rec)
        {
            if (dbInitializer.DbContext != null)
                repository.UpdateAttendance([rec], dbInitializer.DbContext);
            else
                throw new Exception("خطای دیتابیس");
        }

        // حذف یک رکورد Attendance
        public void DeleteAttendance(Attendance rec)
        {
            if (dbInitializer.DbContext != null)
                repository.DeleteAttendance([rec], dbInitializer.DbContext);
            else
                throw new Exception("خطای دیتابیس");
        }
    }
}
using VorodKhoroj.Application.Services;

namespace VorodKhoroj.Application.Coordinators
{
    // مدیریت عملیات مربوط به داده‌های Attendance با استفاده از Repository و DbContext
    public class AttendanceServiceCoordinator(DataRepository repository, AppDbContextConfiguration dbConfiguration)
    {
        // کپی کردن لیستی از رکوردهای Attendance به دیتابیس
        public void CopyRecords(List<Attendance> recs)
        {
            if (dbConfiguration.DbContext != null)
                repository.AddAttendancesAndUsers(recs, dbConfiguration.DbContext);
            else
                throw new Exception("خطای دیتابیس");
        }

        // افزودن لیستی از رکوردهای Attendance به دیتابیس
        public void AddAttendance(List<Attendance> rec)
        {
            if (dbConfiguration.DbContext != null)
                repository.AddAttendance(rec, dbConfiguration.DbContext);
            else
                throw new Exception("خطای دیتابیس");
        }

        // به‌روزرسانی یک رکورد Attendance
        public void UpdateAttendance(Attendance rec)
        {
            if (dbConfiguration.DbContext != null)
                repository.UpdateAttendance([rec], dbConfiguration.DbContext);
            else
                throw new Exception("خطای دیتابیس");
        }

        // حذف یک رکورد Attendance
        public void DeleteAttendance(Attendance rec)
        {
            if (dbConfiguration.DbContext != null)
                repository.DeleteAttendance([rec], dbConfiguration.DbContext);
            else
                throw new Exception("خطای دیتابیس");
        }
    }
}
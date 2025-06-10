namespace VorodKhoroj.Coordinators
{
    // مدیریت عملیات مربوط به داده‌های Attendance با استفاده از Repository و DbContext
    public class AttendanceServiceCoordinator(DataRepository repository, AppDbContextProvider dbProvider)
    {
        // کپی کردن لیستی از رکوردهای Attendance به دیتابیس
        public void CopyRecords(List<Attendance> recs)
        {
            if (dbProvider.DbContext != null)
                repository.AddAttendancesAndUsers(recs, dbProvider.DbContext);
            else
                throw new Exception("خطای دیتابیس");
        }

        // افزودن لیستی از رکوردهای Attendance به دیتابیس
        public void AddAttendance(List<Attendance> rec)
        {
            if (dbProvider.DbContext != null)
                repository.AddAttendance(rec, dbProvider.DbContext);
            else
                throw new Exception("خطای دیتابیس");
        }

        // به‌روزرسانی یک رکورد Attendance
        public void UpdateAttendance(Attendance rec)
        {
            if (dbProvider.DbContext != null)
                repository.UpdateAttendance([rec], dbProvider.DbContext);
            else
                throw new Exception("خطای دیتابیس");
        }

        // حذف یک رکورد Attendance
        public void DeleteAttendance(Attendance rec)
        {
            if (dbProvider.DbContext != null)
                repository.DeleteAttendance([rec], dbProvider.DbContext);
            else
                throw new Exception("خطای دیتابیس");
        }
    }
}
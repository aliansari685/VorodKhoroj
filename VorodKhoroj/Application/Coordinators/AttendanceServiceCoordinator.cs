namespace VorodKhoroj.Application.Coordinators
{
    // مدیریت عملیات مربوط به داده‌های Attendance با استفاده از Repository و DbContext
    public class AttendanceServiceCoordinator(IAttendanceRepository attendanceRepository, IDbContextConfiguration dbInitializer, IDataLoader dataLoader)
    {
        // کپی کردن لیستی از رکوردهای Attendance به دیتابیس
        public void CopyRecords(List<Attendance> recs)
        {
            if (dbInitializer.DbContext == null)
                throw new Exception("خطای دیتابیس");

            attendanceRepository.AddAttendancesWithUsers(recs);
        }

        // افزودن لیستی از رکوردهای Attendance به دیتابیس
        public void AddAttendance(List<Attendance> rec)
        {
            if (dbInitializer.DbContext == null)
                throw new Exception("خطای دیتابیس");

            attendanceRepository.Add(rec);
            dataLoader.LoadFromDb(dbInitializer.DbContext);
        }

        // به‌روزرسانی یک رکورد Attendance
        public void UpdateAttendance(Attendance rec)
        {
            if (dbInitializer.DbContext == null)
                throw new Exception("خطای دیتابیس");

            attendanceRepository.Update([rec]);
            dataLoader.LoadFromDb(dbInitializer.DbContext);
        }

        // حذف یک رکورد Attendance
        public void DeleteAttendance(Attendance rec)
        {
            if (dbInitializer.DbContext == null)
                throw new Exception("خطای دیتابیس");

            attendanceRepository.Remove([rec]);
            dataLoader.LoadFromDb(dbInitializer.DbContext);
        }
    }
}
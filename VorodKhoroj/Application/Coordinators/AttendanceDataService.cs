namespace VorodKhoroj.Application.Coordinators
{
    // مدیریت عملیات مربوط به داده‌های Attendance با استفاده از Repository و DbContext
    public class AttendanceDataService(IAttendanceRepository attendanceRepository, IDataLoader dataLoader, IDbContextConfiguration dbContextConfiguration) : IAttendanceDataService
    {
        // کپی کردن لیستی از رکوردهای Attendance به دیتابیس
        public void CopyRecords(List<Attendance> recs)
        {
            if (dbContextConfiguration.DbContext == null)
                throw new NullReferenceException("خطای دیتابیس");
            attendanceRepository.AddAttendancesWithUsers(recs, dbContextConfiguration.DbContext);
        }

        // افزودن لیستی از رکوردهای Attendance به دیتابیس
        public void AddAttendance(List<Attendance> rec)
        {
            if (dbContextConfiguration.DbContext == null)
                throw new NullReferenceException("خطای دیتابیس");
            attendanceRepository.Add(rec, dbContextConfiguration.DbContext);
            dataLoader.LoadFromDb();
        }

        // به‌روزرسانی یک رکورد Attendance
        public void UpdateAttendance(Attendance rec)
        {
            if (dbContextConfiguration.DbContext == null)
                throw new NullReferenceException("خطای دیتابیس");
            attendanceRepository.Update([rec], dbContextConfiguration.DbContext);
            dataLoader.LoadFromDb();
        }

        // حذف یک رکورد Attendance
        public void DeleteAttendance(Attendance rec)
        {
            if (dbContextConfiguration.DbContext == null)
                throw new NullReferenceException("خطای دیتابیس");
            attendanceRepository.Remove([rec], dbContextConfiguration.DbContext);
            dataLoader.LoadFromDb();
        }
    }
}
namespace VorodKhoroj.Coordinators
{
    // مدیریت داده‌های Attendance 
    public class AttendanceServiceCoordinator(DataRepository repository, AppDbContextProvider dbProvider)
    {
        public void CopyRecords(List<Attendance> recs)
        {
            if (dbProvider.DbContext != null) repository.AddAttendancesAndUsers(recs, dbProvider.DbContext);
        }

        public void AddAttendance(List<Attendance> rec)
        {
            if (dbProvider.DbContext != null) repository.AddAttendance(rec, dbProvider.DbContext);
        }

        public void UpdateAttendance(Attendance rec)
        {
            if (dbProvider.DbContext != null) repository.UpdateAttendance([rec], dbProvider.DbContext);
        }

        public void DeleteAttendance(Attendance rec)
        {
            if (dbProvider.DbContext != null) repository.DeleteAttendance([rec], dbProvider.DbContext);
        }
    }

}

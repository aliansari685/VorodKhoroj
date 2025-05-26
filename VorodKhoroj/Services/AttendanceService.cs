namespace VorodKhoroj.Services
{
    // مدیریت داده‌های Attendance 
    public class AttendanceService(DataRepository repository)
    {
        public void CopyRecords(List<Attendance> recs, AppDbContext ctx) => repository.AddAttendancesAndUsers(recs, ctx);
        public void AddAttendance(List<Attendance> rec, AppDbContext ctx) => repository.AddAttendance(rec, ctx);
        public void UpdateAttendance(Attendance rec, AppDbContext ctx) => repository.UpdateAttendance([rec], ctx);

    }

}

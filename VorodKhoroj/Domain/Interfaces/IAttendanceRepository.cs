namespace VorodKhoroj.Domain.Interfaces;

public interface IAttendanceRepository : IRepository<Attendance>
{
    public void AddAttendancesWithUsers(List<Attendance> records);
}
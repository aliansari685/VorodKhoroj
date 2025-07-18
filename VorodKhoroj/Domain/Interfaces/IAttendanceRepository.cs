namespace VorodKhoroj.Domain.Interfaces;

public interface IAttendanceRepository : IRepository<Attendance>
{
    /// <summary>
    /// اضافه کردن دسته جمعی کاربران و حضور و غیاب
    /// </summary>
    /// <param name="records"></param>
    /// <param name="dbContext"></param>
    public void AddAttendancesWithUsers(List<Attendance> records, AppDbContext dbContext);

    /// <summary>
    /// دریافت ارایه کابران
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public int[] GetUsersAttendances(List<Attendance> list);
}
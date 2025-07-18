namespace VorodKhoroj.Infrastructure.UserProvider;

/// <summary>
/// لیست کاربران از فایل دریافت شود
/// </summary>
/// <param name="repository"></param>
/// <param name="records"></param>
//FileProvider:
public class FileProvider(IAttendanceRepository repository, List<Attendance> records) : IUserDataProvider
{
    public IList GetUserDataProvider()
    {
        return repository.GetUsersAttendances(records);
    }
}

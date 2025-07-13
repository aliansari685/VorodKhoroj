using VorodKhoroj.Application.Services;

namespace VorodKhoroj.Domain.Interfaces
{
    /// <summary>
    /// عملیات دریافت کربران از پروایدر های مشخص شده
    /// </summary>
    //Factory Pattern: 
    public interface IUserDataProvider
    {
        IList GetUserDataProvider();
    }
    /// <summary>
    /// لیست کاربران از دیتابیس دریافت شود
    /// </summary>
    /// <param name="context"></param>
    public class DbProvider(AppDbContext? context) : IUserDataProvider
    {
        public IList GetUserDataProvider()
        {
            return context?.Users.Select(x => new User
            {
                Name = string.IsNullOrWhiteSpace(x.Name) ? x.UserId.ToString() : x.Name,
                UserId = x.UserId
            }).ToList() ?? [];
        }
    }
    /// <summary>
    /// لیست کاربران از فایل دریافت شود
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="records"></param>
    //FileProvider:
    public class FileProvider(DataRepository repository, List<Attendance> records) : IUserDataProvider
    {
        public IList GetUserDataProvider()
        {
            return repository.GetUsersAttendances(records);
        }
    }
}

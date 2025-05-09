namespace VorodKhoroj.Services
{
    //Factory Pattern: 
    public interface IUserDataProvider
    {
        IList GetUserDataProvider();
    }

    //DataBaseProvider:
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

    //FileProvider:
    public class FileProvider(DataRepository repository, List<Attendance> records) : IUserDataProvider
    {
        public IList GetUserDataProvider()
        {
            return repository.GetUsersAttendances(records);
        }
    }
}

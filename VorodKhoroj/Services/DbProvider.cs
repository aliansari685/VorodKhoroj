namespace VorodKhoroj.Services
{
    public class DbProvider(AppDbContext? context) : IDataProvider
    {
        public IList GetDataProvider()
        {
            return context?.Users.Select(x => new User
            {
                Name = string.IsNullOrWhiteSpace(x.Name) ? x.UserId.ToString() : x.Name,
                UserId = x.UserId
            }).ToList() ?? [];
        }
    }
}

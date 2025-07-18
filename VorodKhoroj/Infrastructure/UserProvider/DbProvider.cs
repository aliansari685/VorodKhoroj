namespace VorodKhoroj.Infrastructure.UserProvider
{
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
}

namespace VorodKhoroj.Infrastructure;

// بارگذاری داده‌ها از فایل یا دیتابیس
public class DataLoader(DataRepository repository)
{
    public AppDbContext? DbContext { get; private set; }
    public AppDbContext? DbContextMaster { get; private set; }
    public List<Attendance> Records { get; private set; } = [];
    public IUserDataProvider? ListProvider { get; set; }
    public IList? UsersList => ListProvider?.GetUserDataProvider();

    public void LoadFromFile(string fileName)
    {
        Records = repository.GetRecordsFromFile(fileName);
        ListProvider = new FileProvider(repository, Records);
    }

    public void LoadFromDb()
    {
        Records = DbContext?.Attendances.ToList() ?? [];
        ListProvider = new DbProvider(DbContext);
    }

    public void InitializeDbContext(string server, string path, string name, AppDbContext.DataBaseLocation location)
    {
        DbContext?.Dispose();
        DbContext = new AppDbContext(server, path, name, location);
    }

    public void InitializeDbContextMaster(string server, string path)
    {
        DbContextMaster?.Dispose();
        DbContextMaster = new AppDbContext(server, path, "master", AppDbContext.DataBaseLocation.InternalDataBase);
    }
}

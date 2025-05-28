namespace VorodKhoroj.Coordinators;

// بارگذاری داده‌ها از فایل یا دیتابیس
public class DataLoaderCoordinator(DataRepository repository)
{
    public AppDbContext? DbContext { get; private set; }
    public AppDbContext? DbContextMaster { get; private set; }

    public List<Attendance> Records { get; set; } = [];
    public IUserDataProvider? ListProvider { get; set; }

    public void LoadFromFile(string fileName, bool isListProvider = true)
    {
        Records = repository.GetRecordsFromFile(fileName);
        if (isListProvider)
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

    public void InitializeDbContextMaster(string server)
    {
        DbContextMaster?.Dispose();
        DbContextMaster = new AppDbContext(server, "", "master", AppDbContext.DataBaseLocation.InternalDataBase);
    }
    public bool TestServerName(string server)
    {
        try
        {
            InitializeDbContextMaster(server);
            DbContextMaster?.Database.ExecuteSqlRaw("SELECT 1");
            return true;
        }
        catch { return false; }
    }


}

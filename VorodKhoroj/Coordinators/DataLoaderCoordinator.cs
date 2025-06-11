namespace VorodKhoroj.Coordinators;

// بارگذاری داده‌ها از فایل یا دیتابیس
public class DataLoaderCoordinator(DataRepository repository)
{
    /// <summary>
    /// کانتکست مرکزی برای فراخوانی
    /// </summary>
    public AppDbContext? DbContext { get; private set; }

    /// <summary>
    /// کانتکست مستر مرکزی برای فراخوانی
    /// </summary>
    public AppDbContext? DbContextMaster { get; private set; }

    public List<Attendance> Records { get; set; } = [];
    public IUserDataProvider? ListProvider { get; set; }

    /// <summary>
    /// بارگذاری داده‌ها از فایل تکست یا مشابه
    /// </summary>
    /// <param name="fileName">نام فایل ورودی</param>
    /// <param name="isListProvider">آیا ListProvider تنظیم شود</param>
    public void LoadFromFile(string fileName, bool isListProvider = true)
    {
        Records = repository.GetRecordsFromFile(fileName);
        ListProvider = isListProvider ? new FileProvider(repository, Records) : null;
    }

    /// <summary>
    /// بارگذاری داده‌ها از دیتابیس
    /// </summary>
    public void LoadFromDb()
    {
        Records = DbContext?.Attendances.ToList() ?? [];
        ListProvider = new DbProvider(DbContext);
    }

    /// <summary>
    /// مقداردهی اولیه DbContext با مشخصات دیتابیس
    /// </summary>
    public void InitializeDbContext(string server, string path, string name, AppDbContext.DataBaseLocation location)
    {
        DbContext?.Dispose();
        DbContext = new AppDbContext(server, path, name, location);
    }

    /// <summary>
    /// مقداردهی اولیه DbContextMaster برای تست اتصال به سرور
    /// </summary>
    public void InitializeDbContextMaster(string server)
    {
        DbContextMaster?.Dispose();
        DbContextMaster = new AppDbContext(server, string.Empty, "master", AppDbContext.DataBaseLocation.InternalDataBase);
        if (DbContextMaster == null)
            throw new NullReferenceException("خطای دیتابیس");
    }

    /// <summary>
    /// تست ارتباط با سرور SQL
    /// </summary>
    public bool TestServerName(string server)
    {
        try
        {
            _ = DbContextMaster?.Database.ExecuteSql($"SELECT 1");
            return DbContextMaster!.Database.CanConnect();
        }
        catch
        {
            return false;
        }
    }
}

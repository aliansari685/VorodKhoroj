namespace VorodKhoroj.Application.Coordinators;

public class DataBaseInitializerCoordinator(IDataBaseEngine dataBaseInitializer, IDbContextConfiguration dbInitializer) : IDataBaseInitializer
{
    /// <summary>
    /// نام پایگاه داده
    /// </summary>
    public string DbName { get; set; } = "";

    /// <summary>
    /// تنظیم نام دیتابیس (بدون پسوند) از مسیر فایل داده شده
    /// </summary>
    public void SetDbName(string dbPath) => DbName = Path.GetFileNameWithoutExtension(dbPath);

    /// <summary>
    /// مسیر دیتابیس
    /// </summary>
    public string DbPathName { get; set; } = "";

    /// <summary>
    /// تنظیم مسیر فایل دیتابیس
    /// </summary>
    public void SetDbPath(string dbPathname) => DbPathName = dbPathname;

    /// <summary>
    /// ایجاد دیتابیس جدید با مسیر و نام مشخص
    /// </summary>
    public void CreateDatabase()
    {
        if (dbInitializer.DbContextMaster == null)
            throw new Exception("خطای دیتابیس");

        dataBaseInitializer.CreateDatabase(DbPathName, DbName);
    }

    /// <summary>
    /// جدا کردن دیتابیس از سرور (Detach)
    /// </summary>
    public void DetachDatabase()
    {
        if (dbInitializer.DbContextMaster == null)
            throw new Exception("خطای دیتابیس");

        dataBaseInitializer.DetachDatabase(DbPathName, DbName);
    }

    /// <summary>
    /// ایجاد جداول در دیتابیس فعلی
    /// </summary>
    public void CreateTables()
    {
        if (dbInitializer.DbContext == null)
            throw new Exception("خطای دیتابیس");

        dataBaseInitializer.CreateTables();
    }

    /// <summary>
    /// تست ارتباط با سرور SQL
    /// </summary>
    public bool TestServerName(string server)
    {
        return dbInitializer.DbContextMaster == null
            ? throw new Exception("خطای دیتابیس")
            : dataBaseInitializer.TestServerConnection(server);
    }

}
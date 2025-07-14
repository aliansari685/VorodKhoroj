namespace VorodKhoroj.Application.Coordinators;

public class DatabaseServiceCoordinator(DatabaseService databaseService, AppDbContextConfiguration dbConfiguration)
{
    /// <summary>
    /// ایجاد دیتابیس جدید با مسیر و نام مشخص
    /// </summary>
    public void CreateDatabase(string dbPath, string dbName)
    {
        if (dbConfiguration.DbContextMaster != null)
            databaseService.CreateDatabase(dbPath, dbName, dbConfiguration.DbContextMaster);
        else
            throw new Exception("خطای دیتابیس");
    }

    /// <summary>
    /// جدا کردن دیتابیس از سرور (Detach)
    /// </summary>
    public void DetachDatabase(string dbPath, string dbName)
    {
        if (dbConfiguration.DbContextMaster != null)
            databaseService.DetachDatabase(dbPath, dbName, dbConfiguration.DbContextMaster);
        else
            throw new Exception("خطای دیتابیس");
    }

    /// <summary>
    /// ایجاد جداول در دیتابیس فعلی
    /// </summary>
    public void CreateTables()
    {
        if (dbConfiguration.DbContext != null)
            databaseService.CreateTables(dbConfiguration.DbContext);
        else
            throw new Exception("خطای دیتابیس");
    }

    /// <summary>
    /// تست ارتباط با سرور SQL
    /// </summary>
    public bool TestServerName(string server)
    {
        if (dbConfiguration.DbContextMaster != null)
            return databaseService.TestServerName(server, dbConfiguration.DbContextMaster);

        throw new Exception("خطای دیتابیس");
    }

}
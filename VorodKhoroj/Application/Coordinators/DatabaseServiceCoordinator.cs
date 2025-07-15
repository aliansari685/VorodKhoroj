using VorodKhoroj.Infrastructure.Persistence;

namespace VorodKhoroj.Application.Coordinators;

public class DatabaseServiceCoordinator(DatabaseInitializerService databaseInitializerService, DbContextInitializer dbInitializer)
{
    /// <summary>
    /// ایجاد دیتابیس جدید با مسیر و نام مشخص
    /// </summary>
    public void CreateDatabase(string dbPath, string dbName)
    {
        if (dbInitializer.DbContextMaster != null)
            databaseInitializerService.CreateDatabase(dbPath, dbName, dbInitializer.DbContextMaster);
        else
            throw new Exception("خطای دیتابیس");
    }

    /// <summary>
    /// جدا کردن دیتابیس از سرور (Detach)
    /// </summary>
    public void DetachDatabase(string dbPath, string dbName)
    {
        if (dbInitializer.DbContextMaster != null)
            databaseInitializerService.DetachDatabase(dbPath, dbName, dbInitializer.DbContextMaster);
        else
            throw new Exception("خطای دیتابیس");
    }

    /// <summary>
    /// ایجاد جداول در دیتابیس فعلی
    /// </summary>
    public void CreateTables()
    {
        if (dbInitializer.DbContext != null)
            databaseInitializerService.CreateTables(dbInitializer.DbContext);
        else
            throw new Exception("خطای دیتابیس");
    }

    /// <summary>
    /// تست ارتباط با سرور SQL
    /// </summary>
    public bool TestServerName(string server)
    {
        if (dbInitializer.DbContextMaster != null)
            return databaseInitializerService.TestServerName(server, dbInitializer.DbContextMaster);

        throw new Exception("خطای دیتابیس");
    }

}
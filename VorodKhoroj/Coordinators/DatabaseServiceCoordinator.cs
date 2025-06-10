namespace VorodKhoroj.Coordinators;

public class DatabaseServiceCoordinator(DatabaseService databaseService, AppDbContextProvider dbProvider)
{
    /// <summary>
    /// ایجاد دیتابیس جدید با مسیر و نام مشخص
    /// </summary>
    public void CreateDatabase(string dbPath, string dbName)
    {
        if (dbProvider.DbContextMaster != null)
            databaseService.CreateDatabase(dbPath, dbName, dbProvider.DbContextMaster);
        else
            throw new Exception("خطای دیتابیس");
    }

    /// <summary>
    /// جدا کردن دیتابیس از سرور (Detach)
    /// </summary>
    public void DetachDatabase(string dbPath, string dbName)
    {
        if (dbProvider.DbContextMaster != null)
            databaseService.DetachDatabase(dbPath, dbName, dbProvider.DbContextMaster);
        else
            throw new Exception("خطای دیتابیس");
    }

    /// <summary>
    /// ایجاد جداول در دیتابیس فعلی
    /// </summary>
    public void CreateTables()
    {
        if (dbProvider.DbContext != null)
            databaseService.CreateTables(dbProvider.DbContext);
        else
            throw new Exception("خطای دیتابیس");
    }
}
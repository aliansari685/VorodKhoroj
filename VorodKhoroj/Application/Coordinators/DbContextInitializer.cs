namespace VorodKhoroj.Application.Coordinators;

public class DbContextInitializer : IDbContextConfiguration
{
    /// <summary>
    /// کانتکست  مرکزی برای فراخوانی
    /// </summary>
    public AppDbContext? DbContext { get; private set; } 

    /// <summary>
    /// کانتکست مستر مرکزی برای فراخوانی
    /// </summary>
    public AppDbContext? DbContextMaster { get; private set; }

    /// <summary>
    /// مقداردهی اولیه DbContext با مشخصات دیتابیس
    /// </summary>
    public void InitializeDbContext(string server, string path, string name, Enums.DataBaseLocation location)
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
        DbContextMaster = new AppDbContext(server, string.Empty, "master", Enums.DataBaseLocation.InternalDataBase);
        if (DbContextMaster == null)
            throw new NullReferenceException("خطای دیتابیس");
    }
}
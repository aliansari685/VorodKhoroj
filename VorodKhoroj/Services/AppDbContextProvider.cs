namespace VorodKhoroj.Services;

public class AppDbContextProvider(DataLoaderCoordinator dataLoaderCoordinator)
{
    /// <summary>
    /// استفاده از facade جهت نظم کانتکس
    /// </summary>
    public AppDbContext? DbContext => dataLoaderCoordinator.DbContext;

    public AppDbContext? DbContextMaster => dataLoaderCoordinator.DbContextMaster;
}
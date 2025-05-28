namespace VorodKhoroj.Coordinators;

public class DatabaseServiceCoordinator(DatabaseService databaseService, IAppDbContextProvider dbProvider)
{
    public void CreateDatabase(string dbPath, string dbName)
    {
        if (dbProvider.DbContextMaster != null)
            databaseService.CreateDatabase(dbPath, dbName, dbProvider.DbContextMaster);
    }
    public void DetachDatabase(string dbPath, string dbName)
    {
        if (dbProvider.DbContextMaster != null)
            databaseService.DetachDatabase(dbPath, dbName, dbProvider.DbContextMaster);
    }

    public void CreateTables()
    {
        if (dbProvider.DbContext != null)
            databaseService.CreateTables(dbProvider.DbContext);
    }
}
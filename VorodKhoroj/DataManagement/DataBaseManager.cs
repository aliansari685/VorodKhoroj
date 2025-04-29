namespace VorodKhoroj.Data
{
    public class DataBaseManager
    {

        public void CreateDatabase(string filePath, string dbname, AppDbContext dbContext)
        {
            string createDbQuery = $@"
                              CREATE DATABASE {dbname}
                              ON PRIMARY (
                                  NAME = '{dbname}_Data',
                                  FILENAME = '{filePath}',
                                  SIZE = 5MB );";

            dbContext.Database.ExecuteSqlRaw(createDbQuery);
        }

        public void CreateTables(AppDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
        }

        public void DetachDatabase(string dbPathName, string dbName, AppDbContext dbContext)
        {
            try
            {
                var qur = $@" DECLARE @kill VARCHAR(MAX) = '';
                          SELECT @kill = @kill + 'KILL ' + CAST(session_id AS VARCHAR(5)) + ';'
                          FROM sys.dm_exec_sessions
                          WHERE database_id = DB_ID('{dbPathName}');
                          EXEC(@kill);";
                dbContext.Database.ExecuteSqlRaw(qur);

                qur = $@" DECLARE @kill VARCHAR(MAX) = '';
                          SELECT @kill = @kill + 'KILL ' + CAST(session_id AS VARCHAR(5)) + ';'
                          FROM sys.dm_exec_sessions
                          WHERE database_id = DB_ID('{dbName}');
                          EXEC(@kill);";
                dbContext.Database.ExecuteSqlRaw(qur);

                var detachDbQuery = $"EXEC sp_detach_db '{dbName}', 'true';"; //'D:\data\fd.mdf'
                dbContext.Database.ExecuteSqlRaw(detachDbQuery);

                detachDbQuery = $"EXEC sp_detach_db '{dbPathName}', 'true';";
                dbContext.Database.ExecuteSqlRaw(detachDbQuery);
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }
    }

}

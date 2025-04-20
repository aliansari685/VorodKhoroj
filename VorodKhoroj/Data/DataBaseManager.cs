namespace VorodKhoroj.Data
{
    public class DataBaseManager
    {

        public void CreateDatabase(string filePath, AppDbContext dbContext)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string createDbQuery = $@"
            CREATE DATABASE {fileName}
            ON PRIMARY (
                NAME = '{fileName}_Data',
                FILENAME = '{filePath}',
                SIZE = 5MB );";

            dbContext.Database.ExecuteSqlRaw(createDbQuery);
        }

        public void CreateTables(AppDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
        }

        public void DetachDatabase(string fileName, AppDbContext dbContext)
        {
            var dbname = Path.GetFileNameWithoutExtension(fileName);

            var qur = $@" DECLARE @kill VARCHAR(MAX) = '';
                              SELECT @kill = @kill + 'KILL ' + CAST(session_id AS VARCHAR(5)) + ';'
                              FROM sys.dm_exec_sessions
                              WHERE database_id = DB_ID('{dbname}');
                              EXEC(@kill);";
            dbContext.Database.ExecuteSqlRaw(qur);

            var detachDbQuery = $"EXEC sp_detach_db '{dbname}', 'true';";

            dbContext.Database.ExecuteSqlRaw(detachDbQuery);
        }
    }

}

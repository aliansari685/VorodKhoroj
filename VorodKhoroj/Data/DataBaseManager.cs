namespace VorodKhoroj.Data
{
    public class DataBaseManager
    {
        public void CreateDatabase(string filePath, AppDbContext _dbContext)
        {
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string logFile = Path.ChangeExtension(filePath, "ldf");

                string createDbQuery = $@"
            CREATE DATABASE {fileName}
            ON PRIMARY (
                NAME = '{fileName}_Data',
                FILENAME = '{filePath}',
                SIZE = 5MB
            )
            LOG ON (
                NAME = '{fileName}_Log',
                FILENAME = '{logFile}',
                SIZE = 5MB
            );";

                _dbContext.Database.ExecuteSqlRaw(createDbQuery);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void CreateTables(AppDbContext _dbContext)
        {
            _dbContext.Database.EnsureCreated();
        }

        public void DetachDatabase(string fileName, AppDbContext _dbContext)
        {
            try
            {
                var dbname = Path.GetFileNameWithoutExtension(fileName);

                var qur = $@" DECLARE @kill VARCHAR(MAX) = '';
                              SELECT @kill = @kill + 'KILL ' + CAST(session_id AS VARCHAR(5)) + ';'
                              FROM sys.dm_exec_sessions
                              WHERE database_id = DB_ID('{dbname}');
                              EXEC(@kill);";
                _dbContext.Database.ExecuteSqlRaw(qur);

                var detachDbQuery = $"EXEC sp_detach_db '{dbname}', 'true';";

                _dbContext.Database.ExecuteSqlRaw(detachDbQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

}

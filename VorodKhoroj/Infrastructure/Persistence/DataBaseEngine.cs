namespace VorodKhoroj.Infrastructure.Persistence
{
    /// <summary>
    /// تنظمیات پایه و اولیه دیتابیس مثل ایجاد کردن
    /// </summary>
    public class DataBaseEngine(IDbContextConfiguration contextConfiguration) : IDataBaseEngine
    {
        /// <summary>
        /// ایجاد دیتابیس جدید با نام و مسیر مشخص
        /// </summary>
        /// <param name="filePath">مسیر فایل دیتابیس (mdf)</param>
        /// <param name="dbname">نام دیتابیس</param>
        public void CreateDatabase(string filePath, string dbname)
        {
            string createDbQuery = $@"
                              CREATE DATABASE {dbname}
                              ON PRIMARY (
                                  NAME = '{dbname}_Data',
                                  FILENAME = '{filePath}',
                                  SIZE = 5MB );";

            contextConfiguration.DbContextMaster?.Database.ExecuteSqlRaw(createDbQuery);
        }

        /// <summary>
        /// ایجاد جداول دیتابیس در صورت عدم وجود
        /// </summary>
        public void CreateTables() => contextConfiguration.DbContext?.Database.EnsureCreated();


        /// <summary>
        /// قطع اتصال‌ها به دیتابیس و جداکردن دیتابیس (Detach)
        /// </summary>
        /// <param name="dbPathName">نام یا مسیر دیتابیس برای شناسایی session ها</param>
        /// <param name="dbName">نام دیتابیس</param>
        public void DetachDatabase(string dbPathName, string dbName)
        {
            try
            {
                var killQuery = $@"
            DECLARE @kill VARCHAR(MAX) = '';
            SELECT @kill = @kill + 'KILL ' + CAST(session_id AS VARCHAR) + ';'
            FROM sys.dm_exec_sessions
            WHERE database_id = DB_ID('{dbName}');
            EXEC(@kill);";

                contextConfiguration.DbContextMaster?.Database.ExecuteSqlRaw(killQuery);

                var qur = $@" DECLARE @kill VARCHAR(MAX) = '';
                          SELECT @kill = @kill + 'KILL ' + CAST(session_id AS VARCHAR(5)) + ';'
                          FROM sys.dm_exec_sessions
                          WHERE database_id = DB_ID('{dbPathName}');
                          EXEC(@kill);";
                contextConfiguration.DbContextMaster?.Database.ExecuteSqlRaw(qur);

                var detachDbQuery = $"EXEC sp_detach_db '{dbName}', 'true';";
                contextConfiguration.DbContextMaster?.Database.ExecuteSqlRaw(detachDbQuery);
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }
        /// <summary>
        /// تست ارتباط با سرور SQL
        /// <param name="server">نام سرور اس کیو ال</param>
        /// </summary>
        public bool TestServerConnection(string server)
        {
            try
            {
                _ = contextConfiguration.DbContextMaster?.Database.ExecuteSql($"SELECT 1");
                return contextConfiguration.DbContextMaster!.Database.CanConnect();
            }
            catch
            {
                return false;
            }
        }
    }
}
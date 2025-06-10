namespace VorodKhoroj.Services
{
    public class DatabaseService
    {
        /// <summary>
        /// ایجاد دیتابیس جدید با نام و مسیر مشخص
        /// </summary>
        /// <param name="filePath">مسیر فایل دیتابیس (mdf)</param>
        /// <param name="dbname">نام دیتابیس</param>
        /// <param name="dbContext">کانتکست دیتابیس</param>
        public void CreateDatabase(string filePath, string dbname, AppDbContext dbContext)
        {
            string createDbQuery = $@"
                              CREATE DATABASE {dbname}
                              ON PRIMARY (
                                  NAME = '{dbname}_Data',
                                  FILENAME = '{filePath}',
                                  SIZE = 5MB );";

            dbContext.Database.ExecuteSqlRaw(createDbQuery);
            MessageBox.Show("ok");
        }

        /// <summary>
        /// ایجاد جداول دیتابیس در صورت عدم وجود
        /// </summary>
        /// <param name="dbContext">کانتکست دیتابیس</param>
        public void CreateTables(AppDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            MessageBox.Show("ok");
        }

        /// <summary>
        /// قطع اتصال‌ها به دیتابیس و جداکردن دیتابیس (Detach)
        /// </summary>
        /// <param name="dbPathName">نام یا مسیر دیتابیس برای شناسایی session ها</param>
        /// <param name="dbName">نام دیتابیس</param>
        /// <param name="dbContext">کانتکست دیتابیس</param>
        public void DetachDatabase(string dbPathName, string dbName, AppDbContext dbContext)
        {
            try
            {
                var killQuery = $@"
            DECLARE @kill VARCHAR(MAX) = '';
            SELECT @kill = @kill + 'KILL ' + CAST(session_id AS VARCHAR) + ';'
            FROM sys.dm_exec_sessions
            WHERE database_id = DB_ID('{dbName}');
            EXEC(@kill);";

                dbContext.Database.ExecuteSqlRaw(killQuery);

                var qur = $@" DECLARE @kill VARCHAR(MAX) = '';
                          SELECT @kill = @kill + 'KILL ' + CAST(session_id AS VARCHAR(5)) + ';'
                          FROM sys.dm_exec_sessions
                          WHERE database_id = DB_ID('{dbPathName}');
                          EXEC(@kill);";
                dbContext.Database.ExecuteSqlRaw(qur);

                var detachDbQuery = $"EXEC sp_detach_db '{dbName}', 'true';";
                dbContext.Database.ExecuteSqlRaw(detachDbQuery);
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }
    }
}
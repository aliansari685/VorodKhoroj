namespace VorodKhoroj.Coordinators
{
    // هماهنگ ‌کننده‌ی عملیات بین سرویس‌های مختلف برای مدیریت و گردش کار ورود و خروج
    public class AppCoordinator(ManualMigrationService migrationService, DataLoader dataLoader, DatabaseService databaseService, AttendanceService attendanceService, UserService userService) : IDisposable
    {
        public string DbName { get; set; } = "";
        public string DbPathName { get; set; } = "";

        public AppDbContext? DbContext => dataLoader.DbContext;
        public AppDbContext? DbContextMaster => dataLoader.DbContextMaster;

        public IList? UsersList => dataLoader.UsersList;
        public IUserDataProvider? UserListProvider => dataLoader.ListProvider;

        public List<Attendance> Records => dataLoader.Records;

        public void LoadRecordsFromFile(string fileName, bool isListProvider = true) => dataLoader.LoadFromFile(fileName, isListProvider);
        public void LoadRecordsFromDb() => dataLoader.LoadFromDb();

        public void InitializeDbContext(string server, AppDbContext.DataBaseLocation location) =>
            dataLoader.InitializeDbContext(server, DbPathName, DbName, location);

        public void InitializeDbContext_Master(string server) =>
            dataLoader.InitializeDbContextMaster(server, DbPathName);

        public void HandleCreateDatabase()
        {
            if (DbContextMaster != null) databaseService.CreateDatabase(DbPathName, DbName, DbContextMaster);
        }

        public void HandleCreateTables()
        {
            if (DbContext != null) databaseService.CreateTables(DbContext);
        }

        public void HandleDetachDatabase()
        {
            if (DbContextMaster != null) databaseService.DetachDatabase(DbPathName, DbName, DbContextMaster);
        }

        public void CopyAttendancesRecord(List<Attendance> records)
        {
            if (DbContext != null) attendanceService.CopyRecords(records, DbContext);
        }

        public void AddAttendanceRecord(List<Attendance> rec)
        {
            if (DbContext != null) attendanceService.AddAttendance(rec, DbContext);
        }

        public void UpdateAttendanceRecord(Attendance rec)
        {
            if (DbContext != null) attendanceService.UpdateAttendance(rec, DbContext);
        }

        public void AddUserRecord(List<User> rec)
        {
            if (DbContext != null) userService.AddUser(rec, DbContext);
        }

        public void UpdateUserRecord(User rec)
        {
            if (DbContext != null) userService.UpdateUser(rec, DbContext);
        }

        public void MigrationsEnsureDatabaseUpToDate()
        {
            if (DbContext != null) migrationService.EnsureIdColumnExists(DbContext);
        }

        public bool TestServerName(string server)
        {
            try
            {
                InitializeDbContext_Master(server);
                DbContextMaster?.Database.ExecuteSqlRaw("SELECT 1");
                return true;
            }
            catch { return false; }
        }
        public void Dispose()
        {
            DbContext?.Dispose();
            DbContextMaster?.Dispose();
            GC.SuppressFinalize(this);
        }
    }


}
namespace VorodKhoroj.Coordinators
{
    // هماهنگ ‌کننده‌ی عملیات بین سرویس‌های مختلف برای مدیریت و گردش کار ورود و خروج
    public class MainCoordinator(AppDbContextProvider dbContextProvider, ManualMigrationServiceCoordinator migrationServiceCoordinator, DataLoaderCoordinator dataLoaderCoordinator, DatabaseServiceCoordinator databaseServiceCoordinator, AttendanceServiceCoordinator attendanceServiceCoordinator, UserServiceCoordinator userServiceCoordinator) : IDisposable
    {
        private string DbName { get; set; } = "";
        public void SetDbName(string dbPath) => DbName = Path.GetFileNameWithoutExtension(dbPath);

        private string DbPathName { get; set; } = "";
        public void SetDbPath(string dbPathname) => DbPathName = (dbPathname);


        public AppDbContext? DbContext => dbContextProvider.DbContext = dataLoaderCoordinator.DbContext;
        public AppDbContext? DbContextMaster => dbContextProvider.DbContextMaster = dataLoaderCoordinator.DbContextMaster;

        public List<Attendance> AttendancesList => dataLoaderCoordinator.Records;
        public IList? UsersList => dataLoaderCoordinator.ListProvider?.GetUserDataProvider();
        public IUserDataProvider? UsersListProvider => dataLoaderCoordinator.ListProvider;

        public void UpdateUserRecord(User user) => userServiceCoordinator.UpdateUser(user);
        public void AddUserRecord(List<User> newUsers) => userServiceCoordinator.AddUser(newUsers);

        public bool TestServerName(string server) => dataLoaderCoordinator.TestServerName(server);
        public void InitializeDbContext(string serverName, AppDbContext.DataBaseLocation location) => dataLoaderCoordinator.InitializeDbContext(serverName, DbPathName, DbName, location);
        public void LoadRecordsFromDb() => dataLoaderCoordinator.LoadFromDb();
        public void LoadRecordsFromFile(string fileName, bool isListProvider = true) => dataLoaderCoordinator.LoadFromFile(fileName, isListProvider);

        public void HandleCreateDatabase() => databaseServiceCoordinator.CreateDatabase(DbPathName, DbName);
        public void HandleDetachDatabase() => databaseServiceCoordinator.DetachDatabase(DbPathName, DbName);
        public void HandleCreateTables() => databaseServiceCoordinator.CreateTables();

        public void UpdateAttendanceRecord(Attendance attendance) => attendanceServiceCoordinator.UpdateAttendance(attendance);
        public void CopyAttendancesRecord(List<Attendance> records) => attendanceServiceCoordinator.CopyRecords(records);
        public void AddAttendanceRecord(List<Attendance> attendances) => attendanceServiceCoordinator.AddAttendance(attendances);

        public void MigrationsEnsureDatabaseUpToDate() => migrationServiceCoordinator.EnsureIdColumnExists();

        public void Dispose()
        {
            DbContext?.Dispose();
            DbContextMaster?.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}
namespace VorodKhoroj.Coordinators
{
    //public class AppCoordinator(DataRepository repository, DatabaseService dataBaseService) : IDisposable
    //{
    //    public IUserDataProvider? UserListProvider { get; private set; }
    //    public IList? UsersList => UserListProvider?.GetUserDataProvider();


    //    public string DbName { get; set; } = "";
    //    public string DbPathName { get; set; } = "";


    //    public AppDbContext? DbContext { get; set; }
    //    public AppDbContext? DbContextMaster { get; set; }

    //    //Data:
    //    public required List<Attendance> Records { get; set; } = [];


    //    public void LoadRecordsFromFile(string fileName)
    //    {
    //        Records = repository.GetRecordsFromFile(fileName);
    //        UserListProvider = new FileProvider(repository, Records);

    //    }

    //    public void LoadRecordsFromDb()
    //    {
    //        SetAttendancesRecord();
    //        UserListProvider = new DbProvider(DbContext);
    //    }

    //    private void SetAttendancesRecord()
    //    {
    //        Records = [];
    //        if (DbContext is not null) Records = DbContext.Attendances.ToList();
    //    }


    //    public void InitializeDbContext(string serverName, AppDbContext.DataBaseLocation databaseLocation)
    //    {
    //        DbContext?.Dispose();
    //        DbContext = new AppDbContext(serverName, DbPathName, DbName, databaseLocation);
    //    }

    //    public void InitializeDbContext_Master(string serverName)
    //    {
    //        DbContextMaster?.Dispose();
    //        DbContextMaster = new AppDbContext(serverName, DbPathName, "master", AppDbContext.DataBaseLocation.InternalDataBase);
    //    }

    //    public void HandleCreateDatabase()
    //    {
    //        if (DbContextMaster != null) dataBaseService.CreateDatabase(DbPathName, DbName, DbContextMaster);
    //    }
    //    public void HandleCreateTables()
    //    {
    //        if (DbContext != null) dataBaseService.CreateTables(DbContext);
    //    }
    //    public void HandleDetachDatabase()
    //    {
    //        if (DbContext != null) dataBaseService.DetachDatabase(DbPathName, DbName, DbContext);
    //    }
    //    public void CopyAttendancesRecord(List<Attendance> rec)// تنظیمات اولیه انتقال ورود خروج و کاربر به دیتابیس 
    //    {
    //        if (DbContext != null) repository.AddAttendancesAndUsers(rec, DbContext);
    //    }

    //    public void AddAttendanceRecord(Attendance rec)
    //    {
    //        if (DbContext != null) repository.AddAttendance([rec], DbContext);
    //        SetAttendancesRecord();
    //    }
    //    public void UpdateAttendanceRecord(Attendance rec)
    //    {
    //        if (DbContext != null) repository.UpdateAttendance([rec], DbContext);
    //        SetAttendancesRecord();
    //    }

    //    public void AddUserRecord(User rec)
    //    {
    //        if (DbContext != null) repository.AddAttendanceUser([rec], DbContext);
    //        UserListProvider = new DbProvider(DbContext);
    //    }
    //    public void UpdateUserRecord(User rec)
    //    {
    //        if (DbContext != null) repository.UpdateAttendanceUser([rec], DbContext);
    //        UserListProvider = new DbProvider(DbContext);
    //    }

    //    public bool TestServerName(string serverName)
    //    {
    //        try
    //        {
    //            InitializeDbContext_Master(serverName);
    //            DbContextMaster?.Database.ExecuteSqlRaw("SELECT 1");
    //            return true;
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //    }



    //    public void Dispose()
    //    {
    //        DbContextMaster?.Dispose();
    //        DbContext?.Dispose();
    //        GC.SuppressFinalize(this);
    //    }

    //}

    ////////:

    // هماهنگ‌کننده‌ی عملیات بین سرویس‌های مختلف برای مدیریت گردش کار ورود و خروج

    public class AppCoordinator(DataLoader dataLoader, DatabaseService databaseService, AttendanceService attendanceService, UserService userService) : IDisposable
    {
        public string DbName { get; set; } = "";
        public string DbPathName { get; set; } = "";

        public AppDbContext? DbContext => dataLoader.DbContext;
        public AppDbContext? DbContextMaster => dataLoader.DbContextMaster;

        public List<Attendance> Records => dataLoader.Records;
        public IList? UsersList => dataLoader.UsersList;
        public IUserDataProvider? UserListProvider => dataLoader.ListProvider;

        public void LoadRecordsFromFile(string fileName) => dataLoader.LoadFromFile(fileName);
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
            //if (DbContext != null) databaseService.DetachDatabase(DbPathName, DbName, DbContext);
            if (DbContextMaster != null) databaseService.DetachDatabase(DbPathName, DbName, DbContextMaster);
        }

        public void CopyAttendancesRecord(List<Attendance> records)
        {
            if (DbContext != null) attendanceService.CopyRecords(records, DbContext);
        }

        public void AddAttendanceRecord(Attendance rec)
        {
            if (DbContext != null) attendanceService.AddAttendance(rec, DbContext);
        }

        public void UpdateAttendanceRecord(Attendance rec)
        {
            if (DbContext != null) attendanceService.UpdateAttendance(rec, DbContext);
        }

        public void AddUserRecord(User rec)
        {
            if (DbContext != null) userService.AddUser(rec, DbContext);
        }

        public void UpdateUserRecord(User rec)
        {
            if (DbContext != null) userService.UpdateUser(rec, DbContext);
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
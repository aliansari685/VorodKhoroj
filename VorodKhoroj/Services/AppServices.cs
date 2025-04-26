namespace VorodKhoroj.Services
{
    public class AppServices(DataRepository repository, DataBaseManager dataBaseManager) : IDisposable
    {
        public string DbName { get; set; } = "";
        public string DbPathName { get; set; } = "";

        public DataTypes DataType { get; set; }
        public AppDbContext? DbContext { get; set; }
        public required AppDbContext? DbContextMaster { get; set; }
        public required List<Attendance> Records { get; set; } = [];
        public required DataTable TempDataTable { get; set; }

        public enum DataTypes
        {
            Text,
            DataBase
        }

        public void LoadRecordsFromFile(string fileName)
        {
            Records = repository.GetRecordsFromFile(fileName);
            SetTempDataTable();
        }

        public int[] GetUsers()
        {
            return repository.GetUsersAttendances(Records);
        }
        public void LoadRecordsFromDb()
        {
            if (DbContext is not null) Records = repository.GetRecordsFromDb(DbContext);
            SetTempDataTable();
        }

        void SetTempDataTable()
        {
            TempDataTable = Records.ToDataTable();
        }

        public void InitializeDbContext(string serverName, AppDbContext.DataBaseLocation databaseLocation)
        {
            DbContext?.Dispose();
            DbContext = new AppDbContext(serverName, DbPathName, DbName, databaseLocation);
        }

        public void InitializeDbContext_Master(string serverName)
        {
            DbContextMaster?.Dispose();
            DbContextMaster = new AppDbContext(serverName, DbPathName, "master", AppDbContext.DataBaseLocation.InternalDataBase);
        }

        public void HandleCreateDatabase()
        {
            if (DbContextMaster != null) dataBaseManager.CreateDatabase(DbPathName, DbName, DbContextMaster);
        }
        public void HandleCreateTables()
        {
            if (DbContext != null) dataBaseManager.CreateTables(DbContext);
        }
        public void HandleDetachDatabase()
        {
            if (DbContext != null) dataBaseManager.DetachDatabase(DbPathName, DbName, DbContext);
        }
        public void AddAttendancesRecord(List<Attendance> rec)//One Config
        {
            if (DbContext != null) repository.AddAttendances(rec, DbContext);
        }

        public void AddAttendanceRecord(Attendance rec)
        {
            if (DbContext != null) repository.AddAttendance([rec], DbContext);
        }
        public void UpdateAttendanceRecord(Attendance rec)
        {
            if (DbContext != null) repository.UpdateAttendance([rec], DbContext);
        }

        public void AddAttendanceUserRecord(User rec)
        {
            if (DbContext != null) repository.AddAttendanceUser([rec], DbContext);
        }
        public void UpdateAttendanceUserRecord(User rec)
        {
            if (DbContext != null) repository.UpdateAttendanceUser([rec], DbContext);
        }


        public bool TestServerName(string servername)
        {
            InitializeDbContext_Master(servername);
            DbContextMaster?.Database.ExecuteSqlRaw("SELECT 1");
            return true;
        }



        public void Dispose()
        {
            DbContextMaster?.Dispose();
            DbContext?.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}
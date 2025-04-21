namespace VorodKhoroj.Services
{
    public class AppServices(DataRepository repository, DataBaseManager dataBaseManager) : IDisposable
    {
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
            if (DbContext is not null) Records = repository.GetRecordsFromDB(DbContext);
            SetTempDataTable();
        }

        void SetTempDataTable()
        {
            TempDataTable = Records.ToDataTable();
        }

        public void InitializeDbContext(string serverName, string dbname, AppDbContext.DataBaseLocation databaseLocation)
        {
            DbContext?.Dispose();
            DbContext = new AppDbContext(serverName, dbname, databaseLocation);
        }

        public void InitializeDbContext_Master(string serverName)
        {
            DbContextMaster?.Dispose();
            DbContextMaster = new(serverName, "master", AppDbContext.DataBaseLocation.InternalDataBase);
        }

        public void HandleCreateDatabase(string filepath)
        {
            if (DbContextMaster != null) dataBaseManager.CreateDatabase(filepath, DbContextMaster);
        }
        public void HandleCreateTables()
        {
            if (DbContext != null) dataBaseManager.CreateTables(DbContext);
        }
        public void HandleDetachDatabase(string filepath)
        {
            if (DbContextMaster != null) dataBaseManager.DetachDatabase(filepath, DbContextMaster);
        }
        public void AddAttendancesRecord(List<Attendance> rec)
        {
            if (DbContext != null) repository.AddAttendances(rec, DbContext);
        }
        public void AddAttendancesRecord(Attendance rec)
        {
            if (DbContext != null) repository.AddAttendances(new List<Attendance> { rec }, DbContext);
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
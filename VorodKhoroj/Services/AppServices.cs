namespace VorodKhoroj.Services
{
    public class AppServices : IDisposable
    {

        public enum DataTypes
        {
            Text,
            DataBase
        }

        public DataTypes DataType { get; set; }
        public AppDbContext DbContext { get; set; }
        public AppDbContext DbContextMaster { get; set; }
        public List<Attendance> Records { get; set; }
        public DataTable TempDataTable { get; set; }

        private readonly DataRepository _repository;
        private readonly DataBaseManager _dataBaseManager;

        public AppServices()
        {
            _repository = new();
            _dataBaseManager = new();
        }
        public void LoadRecordsFromFile(string fileName)
        {
            Records = _repository.GetRecordsFromFile(fileName);
            SetTempDataTable();
        }

        public int[] GetUsers()
        {
            return _repository.GetUsersAttendances(Records);
        }


        public void LoadRecordsFromDb()
        {
            Records = _repository.GetRecordsFromDB(DbContext);
            SetTempDataTable();
        }

        void SetTempDataTable()
        {
            TempDataTable = Records.ToDataTable();
        }

        public void InitializeDbContext(string _servername, string dbname, AppDbContext.DataBaseLocation databaseLocation)
        {
            DbContext?.Dispose();
            DbContext = new(_servername, dbname, databaseLocation);
        }

        public void InitializeDbContext_Master(string _servername)
        {
            DbContextMaster?.Dispose();
            DbContextMaster = new(_servername, "master", AppDbContext.DataBaseLocation.InternalDataBase);
        }

        public void HandleCreateDatabase(string filepath)
        {
            _dataBaseManager.CreateDatabase(filepath, DbContextMaster);
        }
        public void HandleCreateTables()
        {
            _dataBaseManager.CreateTables(DbContext);
        }
        public void HandleDetachDatabase(string filepath)
        {
            _dataBaseManager.DetachDatabase(filepath, DbContextMaster);
        }
        public void AddAttendancesRecord(List<Attendance> rec)
        {
            _repository.AddAttendances(rec, DbContext);
        }
        public void AddAttendancesRecord(Attendance rec)
        {
            _repository.AddAttendances(new List<Attendance> { rec }, DbContext);
        }



        public bool TestServerName(string servername)
        {
            InitializeDbContext_Master(servername);
            DbContextMaster.Database.ExecuteSqlRaw("SELECT 1");
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
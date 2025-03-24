namespace VorodKhoroj
{
    public class AppServices : IDisposable
    {
        public AppDbContext dbContext { get; set; }
        public AppDbContext dbContext_master { get; set; }
        public List<Attendance> Records { get; set; }

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
        }

        public void SetDBContext(string _servername, string dbname, AppDbContext.DataBaseLocation databaseLocation)
        {
            dbContext?.Dispose();
            dbContext = new(_servername, dbname, databaseLocation);
        }

        public void SetDBContext_Master(string _servername)
        {
            dbContext_master?.Dispose();
            dbContext_master = new(_servername, "master", AppDbContext.DataBaseLocation.InternalDataBase);
        }

        public void HandleCreateDatabase(string filepath)
        {
            _dataBaseManager.CreateDatabase(filepath, dbContext_master);
        }
        public void HandleCreateTables()
        {
            _dataBaseManager.CreateTables(dbContext);
        }
        public void HandleDetachDatabase(string filepath)
        {
            _dataBaseManager.DetachDatabase(filepath, dbContext_master);
        }
        public void AddAttendancesRecord(List<Attendance> rec)
        {
            _repository.AddAttendances(rec, dbContext);
        }
        public void AddAttendancesRecord(Attendance rec)
        {
            _repository.AddAttendances(new List<Attendance> { rec }, dbContext);
        }

        public void Dispose()
        {
            dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
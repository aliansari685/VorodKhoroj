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
        public IList? UsersList { get; set; }
        public required DataTable TempDataTable { get; set; }

        public enum DataTypes
        {
            Text,
            DataBase
        }

        public void LoadRecordsFromFile(string fileName)
        {
            Records = repository.GetRecordsFromFile(fileName);
            DataType = DataTypes.Text;
            SetTempDataTable();
        }

        public void LoadRecordsFromDb()
        {
            if (DbContext is not null) Records = DbContext.Attendances.ToList();
            DataType = DataTypes.DataBase;
            SetTempDataTable();
        }

        void GetUsersList()
        {
            UsersList = DataType switch
            {
                DataTypes.Text => GetUsersFromFile(),

                DataTypes.DataBase => GetUsersWithProperty(),

                _ => null
            };

        }

        public int[] GetUsersFromFile()
        {
            return repository.GetUsersAttendances(Records);
        }

        public List<User> GetUsersFromDb()
        {
            return DbContext?.Users.ToList()!;
        }

        public IList? GetUsersWithProperty()
        {
            return GetUsersFromDb().Select(x => new
            {
                Display = string.IsNullOrWhiteSpace(x.Name) ? x.UserId.ToString() : x.Name,
                x.UserId
            }).ToList();
        }

        void SetTempDataTable()
        {
            TempDataTable = Records.ToDataTable();
            GetUsersList();
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
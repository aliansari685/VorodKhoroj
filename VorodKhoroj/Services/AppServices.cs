namespace VorodKhoroj.Services
{
    public class AppServices(DataRepository repository, DataBaseManager dataBaseManager) : IDisposable
    {
        private IDataProvider? _listProvider;

        public IList? UsersList1 => _listProvider?.GetDataProvider();

        public string DbName { get; set; } = "";
        public string DbPathName { get; set; } = "";

        public DataTypes DataType { get; set; }
        public AppDbContext? DbContext { get; set; }
        public AppDbContext? DbContextMaster { get; set; }

        //Data:
        public required List<Attendance> Records { get; set; } = [];
        public IList? UsersList { get; set; }

        public enum DataTypes
        {
            Text,
            DataBase
        }

        public void LoadRecordsFromFile(string fileName)
        {
            Records = repository.GetRecordsFromFile(fileName);
            DataType = DataTypes.Text;
            SetUsersList();
        }

        public void LoadRecordsFromDb()
        {
            SetAttendancesRecord();
            DataType = DataTypes.DataBase;
            SetUsersList();
        }

        private void SetAttendancesRecord()
        {
            Records = [];
            if (DbContext is not null) Records = DbContext.Attendances.ToList();
        }

        private void SetUsersList()
        {
            UsersList = DataType switch
            {
                DataTypes.Text => GetUsersFromFile(),

                DataTypes.DataBase => GetUsersWithProperty(),

                _ => null
            };

        }

        private int[] GetUsersFromFile()
        {
            return repository.GetUsersAttendances(Records);
        }

        private List<User>? GetUsersWithProperty()
        {
            return DbContext?.Users.Select(x => new User
            {
                Name = string.IsNullOrWhiteSpace(x.Name) ? x.UserId.ToString() : x.Name,
                UserId = x.UserId
            }).ToList();
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
        public void CopyAttendancesRecord(List<Attendance> rec)// تنظیمات اولیه انتقال ورود خروج و کاربر به دیتابیس 
        {
            if (DbContext != null) repository.AddAttendancesAndUsers(rec, DbContext);
        }

        public void AddAttendanceRecord(Attendance rec)
        {
            if (DbContext != null) repository.AddAttendance([rec], DbContext);
            SetAttendancesRecord();
        }
        public void UpdateAttendanceRecord(Attendance rec)
        {
            if (DbContext != null) repository.UpdateAttendance([rec], DbContext);
            SetAttendancesRecord();
        }

        public void AddUserRecord(User rec)
        {
            if (DbContext != null) repository.AddAttendanceUser([rec], DbContext);
            SetUsersList();
        }
        public void UpdateUserRecord(User rec)
        {
            if (DbContext != null) repository.UpdateAttendanceUser([rec], DbContext);
            SetUsersList();
        }


        public bool TestServerName(string serverName)
        {
            try
            {
                InitializeDbContext_Master(serverName);
                DbContextMaster?.Database.ExecuteSqlRaw("SELECT 1");
                return true;
            }
            catch
            {
                return false;
            }
        }



        public void Dispose()
        {
            DbContextMaster?.Dispose();
            DbContext?.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
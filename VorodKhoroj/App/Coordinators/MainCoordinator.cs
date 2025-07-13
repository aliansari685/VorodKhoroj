using VorodKhoroj.Application.Services;
using VorodKhoroj.Domain.Interfaces;

namespace VorodKhoroj.Application.Coordinators
{
    /// <summary>
    /// هماهنگ‌کننده اصلی برای مدیریت عملیات و گردش کار بین سرویس‌ها و دیتابیس
    /// این کلاس نقطه اتصال تمام سرویس‌ها است و وظایف مربوط به داده‌های کاربران و حضور و غیاب را مدیریت می‌کند.
    /// </summary>
    public class MainCoordinator(
        AppDbContextConfiguration dbContextConfiguration,
        ManualMigrationServiceCoordinator migrationServiceCoordinator,
        DataLoaderCoordinator dataLoaderCoordinator,
        DatabaseServiceCoordinator databaseServiceCoordinator,
        AttendanceServiceCoordinator attendanceServiceCoordinator,
        UserServiceCoordinator userServiceCoordinator) : IDisposable
    {
        /// <summary>
        /// کانتکس که فسید شده از کانتکس اصلی جهت استفاده عمومی در متد ها یا فرم ها
        /// </summary>
        public AppDbContext? DbContext => dbContextConfiguration.DbContext;

        private string DbName { get; set; } = "";

        /// <summary>
        /// تنظیم نام دیتابیس (بدون پسوند) از مسیر فایل داده شده
        /// </summary>
        public void SetDbName(string dbPath) => DbName = Path.GetFileNameWithoutExtension(dbPath);

        private string DbPathName { get; set; } = "";

        /// <summary>
        /// تنظیم مسیر فایل دیتابیس
        /// </summary>
        public void SetDbPath(string dbPathname) => DbPathName = dbPathname;

        /// <summary>
        /// لیست رکوردهای حضور و غیاب بارگذاری شده
        /// </summary>
        public List<Attendance> AttendancesList => dataLoaderCoordinator.Records;

        /// <summary>
        /// لیست کاربران بارگذاری شده، به صورت آبجکت های عمومی
        /// </summary>
        public IList? UsersList => dataLoaderCoordinator.ListProvider?.GetUserDataProvider();

        /// <summary>
        /// ارائه‌دهنده داده‌های کاربران
        /// </summary>
        public IUserDataProvider? UsersListProvider => dataLoaderCoordinator.ListProvider;

        /// <summary>
        /// بروزرسانی رکورد یک کاربر 
        /// </summary>
        public void UpdateUserRecord(User user)
        {
            userServiceCoordinator.UpdateUser(user);
            LoadRecordsFromDb();
        }

        /// <summary>
        /// افزودن لیستی از کاربران جدید
        /// </summary>
        public void AddUserRecord(List<User> newUsers)
        {
            userServiceCoordinator.AddUser(newUsers);
            LoadRecordsFromDb();
        }

        /// <summary>
        /// مقداردهی اولیه کانتکست مستر دیتابیس با توجه به نام سرور
        /// </summary>
        public void InitializeDbContextMaster(string serverName) => dbContextConfiguration.InitializeDbContextMaster(serverName);

        /// <summary>
        /// مقداردهی اولیه کانتکست دیتابیس با توجه به نام سرور، مسیر و نوع دیتابیس
        /// </summary>
        public void InitializeDbContext(string serverName, AppDbContext.DataBaseLocation location) => dbContextConfiguration.InitializeDbContext(serverName, DbPathName, DbName, location);

        /// <summary>
        /// بارگذاری تمامی داده‌های حضور و غیاب از دیتابیس
        /// </summary>
        public void LoadRecordsFromDb() => dataLoaderCoordinator.LoadFromDb(DbContext);

        /// <summary>
        /// بارگذاری داده‌ها از فایل (به طور پیش‌فرض ارائه‌دهنده لیست را فعال می‌کند)
        /// </summary>
        public void LoadRecordsFromFile(string fileName, bool isListProvider = true) => dataLoaderCoordinator.LoadFromFile(fileName, isListProvider);

        /// <summary>
        /// ایجاد دیتابیس جدید
        /// </summary>
        public void HandleCreateDatabase() => databaseServiceCoordinator.CreateDatabase(DbPathName, DbName);

        /// <summary>
        /// جدا کردن دیتابیس (Detach)
        /// </summary>
        public void HandleDetachDatabase() => databaseServiceCoordinator.DetachDatabase(DbPathName, DbName);

        /// <summary>
        /// ایجاد جداول مورد نیاز در دیتابیس
        /// </summary>
        public void HandleCreateTables() => databaseServiceCoordinator.CreateTables();

        /// <summary>
        /// تست اتصال به سرور دیتابیس
        /// </summary>
        public bool TestServerName(string server) => databaseServiceCoordinator.TestServerName(server);


        /// <summary>
        /// بروزرسانی رکورد حضور و غیاب خاص
        /// </summary>
        public void UpdateAttendanceRecord(Attendance attendance)
        {
            attendanceServiceCoordinator.UpdateAttendance(attendance);
            LoadRecordsFromDb();
        }

        /// <summary>
        /// کپی کردن لیست رکوردهای حضور و غیاب
        /// </summary>
        public void CopyAttendancesRecord(List<Attendance> records) => attendanceServiceCoordinator.CopyRecords(records);

        /// <summary>
        /// افزودن رکوردهای جدید حضور و غیاب
        /// </summary>
        public void AddAttendanceRecord(List<Attendance> attendances)
        {
            attendanceServiceCoordinator.AddAttendance(attendances);
            LoadRecordsFromDb();
        }

        /// <summary>
        /// حذف یک رکورد حضور و غیاب
        /// </summary>
        public void DeleteAttendanceRecord(Attendance attendances)
        {
            attendanceServiceCoordinator.DeleteAttendance(attendances);
            LoadRecordsFromDb();
        }

        /// <summary>
        /// اطمینان از بروزرسانی ساختار دیتابیس و وجود ستون Id
        /// </summary>
        public void MigrationsEnsureDatabaseUpToDate() => migrationServiceCoordinator.EnsureIdColumnExists();

        public void Dispose()
        {
            dbContextConfiguration.DbContext?.Dispose();
            dbContextConfiguration.DbContextMaster?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

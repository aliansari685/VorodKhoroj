namespace VorodKhoroj.Coordinators
{
    /// <summary>
    /// هماهنگ‌کننده اصلی برای مدیریت عملیات و گردش کار بین سرویس‌ها و دیتابیس
    /// این کلاس نقطه اتصال تمام سرویس‌ها است و وظایف مربوط به داده‌های کاربران و حضور و غیاب را مدیریت می‌کند.
    /// </summary>
    public class MainCoordinator(
        AppDbContextProvider dbContextProvider,
        ManualMigrationServiceCoordinator migrationServiceCoordinator,
        DataLoaderCoordinator dataLoaderCoordinator,
        DatabaseServiceCoordinator databaseServiceCoordinator,
        AttendanceServiceCoordinator attendanceServiceCoordinator,
        UserServiceCoordinator userServiceCoordinator) : IDisposable
    {
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
        /// دسترسی به کانتکست اصلی دیتابیس (از DataLoader گرفته می‌شود)
        /// </summary>
        public AppDbContext? DbContext => dbContextProvider.DbContext = dataLoaderCoordinator.DbContext;

        /// <summary>
        /// دسترسی به کانتکست دیتابیس اصلی مستر (برای عملیات مدیریتی دیتابیس)
        /// </summary>
        public AppDbContext? DbContextMaster => dbContextProvider.DbContextMaster = dataLoaderCoordinator.DbContextMaster;

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
        /// بروزرسانی رکورد یک کاربر خاص
        /// </summary>
        public void UpdateUserRecord(User user) => userServiceCoordinator.UpdateUser(user);

        /// <summary>
        /// افزودن لیستی از کاربران جدید
        /// </summary>
        public void AddUserRecord(List<User> newUsers) => userServiceCoordinator.AddUser(newUsers);

        /// <summary>
        /// تست اتصال به سرور دیتابیس
        /// </summary>
        public bool TestServerName(string server) => dataLoaderCoordinator.TestServerName(server);

        /// <summary>
        /// مقداردهی اولیه کانتکست دیتابیس با توجه به نام سرور، مسیر و نوع دیتابیس
        /// </summary>
        public void InitializeDbContext(string serverName, AppDbContext.DataBaseLocation location) =>
            dataLoaderCoordinator.InitializeDbContext(serverName, DbPathName, DbName, location);

        /// <summary>
        /// بارگذاری داده‌های حضور و غیاب از دیتابیس
        /// </summary>
        public void LoadRecordsFromDb() => dataLoaderCoordinator.LoadFromDb();

        /// <summary>
        /// بارگذاری داده‌ها از فایل (به طور پیش‌فرض ارائه‌دهنده لیست را فعال می‌کند)
        /// </summary>
        public void LoadRecordsFromFile(string fileName, bool isListProvider = true) =>
            dataLoaderCoordinator.LoadFromFile(fileName, isListProvider);

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
        /// بروزرسانی رکورد حضور و غیاب خاص
        /// </summary>
        public void UpdateAttendanceRecord(Attendance attendance) => attendanceServiceCoordinator.UpdateAttendance(attendance);

        /// <summary>
        /// کپی کردن لیست رکوردهای حضور و غیاب
        /// </summary>
        public void CopyAttendancesRecord(List<Attendance> records) => attendanceServiceCoordinator.CopyRecords(records);

        /// <summary>
        /// افزودن رکوردهای جدید حضور و غیاب
        /// </summary>
        public void AddAttendanceRecord(List<Attendance> attendances) => attendanceServiceCoordinator.AddAttendance(attendances);

        /// <summary>
        /// حذف یک رکورد حضور و غیاب
        /// </summary>
        public void DeleteAttendanceRecord(Attendance attendances) => attendanceServiceCoordinator.DeleteAttendance(attendances);

        /// <summary>
        /// اطمینان از بروزرسانی ساختار دیتابیس و وجود ستون Id
        /// </summary>
        public void MigrationsEnsureDatabaseUpToDate() => migrationServiceCoordinator.EnsureIdColumnExists();

        public void Dispose()
        {
            DbContext?.Dispose();
            DbContextMaster?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

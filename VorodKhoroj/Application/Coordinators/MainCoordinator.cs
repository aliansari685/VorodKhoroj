namespace VorodKhoroj.Application.Coordinators
{
    /// <summary>
    /// هماهنگ‌کننده اصلی برای مدیریت عملیات و گردش کار بین سرویس‌ها و دیتابیس
    /// این کلاس نقطه اتصال تمام سرویس‌ها است و وظایف مربوط به داده‌های کاربران و حضور و غیاب را مدیریت می‌کند.
    /// </summary>
    public class MainCoordinator : IDisposable
    {
        public readonly IDbContextConfiguration DbContextConfiguration;
        public readonly ManualMigrationServiceCoordinator MigrationServiceCoordinator;
        public readonly DataLoaderCoordinator DataLoaderCoordinator;
        public readonly DatabaseServiceCoordinator DatabaseServiceCoordinator;
        public readonly AttendanceServiceCoordinator AttendanceServiceCoordinator;
        public readonly UserServiceCoordinator UserServiceCoordinator;

        /// <summary>
        /// هماهنگ‌کننده اصلی برای مدیریت عملیات و گردش کار بین سرویس‌ها و دیتابیس
        /// این کلاس نقطه اتصال تمام سرویس‌ها است و وظایف مربوط به داده‌های کاربران و حضور و غیاب را مدیریت می‌کند.
        /// </summary>
        public MainCoordinator(IDbContextConfiguration dbContextConfiguration,
            ManualMigrationServiceCoordinator migrationServiceCoordinator,
            DataLoaderCoordinator dataLoaderCoordinator,
            DatabaseServiceCoordinator databaseServiceCoordinator,
            AttendanceServiceCoordinator attendanceServiceCoordinator,
            UserServiceCoordinator userServiceCoordinator)
        {
            DbContextConfiguration = dbContextConfiguration;
            MigrationServiceCoordinator = migrationServiceCoordinator;
            DataLoaderCoordinator = dataLoaderCoordinator;
            DatabaseServiceCoordinator = databaseServiceCoordinator;
            AttendanceServiceCoordinator = attendanceServiceCoordinator;
            UserServiceCoordinator = userServiceCoordinator;
        }


        public string DbName { get; private set; } = "";

        /// <summary>
        /// تنظیم نام دیتابیس (بدون پسوند) از مسیر فایل داده شده
        /// </summary>
        public void SetDbName(string dbPath) => DbName = Path.GetFileNameWithoutExtension(dbPath);

        public string DbPathName { get; private set; } = "";

        /// <summary>
        /// تنظیم مسیر فایل دیتابیس
        /// </summary>
        public void SetDbPath(string dbPathname) => DbPathName = dbPathname;

        /// <summary>
        /// لیست رکوردهای حضور و غیاب بارگذاری شده
        /// </summary>
        public List<Attendance> AttendancesList => DataLoaderCoordinator.Records;

        /// <summary>
        /// لیست کاربران بارگذاری شده، به صورت آبجکت های عمومی
        /// </summary>
        public IList? UsersList => DataLoaderCoordinator.ListProvider?.GetUserDataProvider();

        /// <summary>
        /// ارائه‌دهنده داده‌های کاربران
        /// </summary>
        public IUserDataProvider? UsersListProvider => DataLoaderCoordinator.ListProvider;



        /// <summary>
        /// بارگذاری تمامی داده‌های حضور و غیاب از دیتابیس
        /// </summary>
        public void LoadRecordsFromDb() => DataLoaderCoordinator.LoadFromDb(DbContextConfiguration.DbContext);

        /// <summary>
        /// بارگذاری داده‌ها از فایل (به طور پیش‌فرض ارائه‌دهنده لیست را فعال می‌کند)
        /// </summary>
        public void LoadRecordsFromFile(string fileName, bool isListProvider = true) => DataLoaderCoordinator.LoadFromFile(fileName, isListProvider);

        /// <summary>
        /// ایجاد دیتابیس جدید
        /// </summary>
        public void HandleCreateDatabase() => DatabaseServiceCoordinator.CreateDatabase(DbPathName, DbName);

        /// <summary>
        /// جدا کردن دیتابیس (Detach)
        /// </summary>
        public void HandleDetachDatabase() => DatabaseServiceCoordinator.DetachDatabase(DbPathName, DbName);

        /// <summary>
        /// ایجاد جداول مورد نیاز در دیتابیس
        /// </summary>
        public void HandleCreateTables() => DatabaseServiceCoordinator.CreateTables();

        /// <summary>
        /// تست اتصال به سرور دیتابیس
        /// </summary>
        public bool TestServerName(string server) => DatabaseServiceCoordinator.TestServerName(server);



        /// <summary>
        /// اطمینان از بروزرسانی ساختار دیتابیس و وجود ستون Id
        /// </summary>
        public void MigrationsEnsureDatabaseUpToDate() => MigrationServiceCoordinator.EnsureIdColumnExists();

        public void Dispose()
        {
            DbContextConfiguration.DbContext?.Dispose();
            DbContextConfiguration.DbContextMaster?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

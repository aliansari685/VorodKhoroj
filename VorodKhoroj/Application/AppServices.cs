namespace VorodKhoroj.Application;

/// <summary>
///     هماهنگ‌کننده اصلی برای مدیریت عملیات و گردش کار بین سرویس‌ها و دیتابیس
///     این کلاس نقطه اتصال تمام سرویس‌ها است و وظایف مربوط به داده‌های کاربران و حضور و غیاب را مدیریت می‌کند.
/// </summary>
public class AppServices(
    IDbContextConfiguration dbContextConfiguration,
    IDbStructureFixer migrationServiceCoordinator,
    IDataLoader dataLoaderCoordinator,
    IDataBaseInitializer dataBaseInitializerCoordinator,
    IAttendanceDataService attendanceDataService,
    IUserDataService userDataService)

{
    public readonly IDbContextConfiguration DbContextConfiguration = dbContextConfiguration;
    public readonly IDbStructureFixer MigrationServiceCoordinator = migrationServiceCoordinator;
    public readonly IDataLoader DataLoaderCoordinator = dataLoaderCoordinator;
    public readonly IDataBaseInitializer DataBaseInitializerCoordinator = dataBaseInitializerCoordinator;
    public readonly IAttendanceDataService AttendanceDataService = attendanceDataService;
    public readonly IUserDataService UserDataService = userDataService;

}
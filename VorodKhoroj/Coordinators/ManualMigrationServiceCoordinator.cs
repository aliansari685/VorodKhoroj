namespace VorodKhoroj.Coordinators;

/// <summary>
///     کلاس مایگریشن و اپدیت دستی دیتابیس بصورت نسخه ای
/// </summary>
/// <param name="migrationService"></param>
/// <param name="dbProvider"></param>
public class ManualMigrationServiceCoordinator(ManualMigrationService migrationService, AppDbContextProvider dbProvider)
{
    /// <summary>
    ///     مایگریشن وجود ستون ایدی و در صورت نداشتن اضافه شود
    /// </summary>
    public void EnsureIdColumnExists()
    {
        if (dbProvider.DbContext != null) migrationService.EnsureIdColumnExists(dbProvider.DbContext);
    }
}
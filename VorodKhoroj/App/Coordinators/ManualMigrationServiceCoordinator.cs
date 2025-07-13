using VorodKhoroj.Application.Services;

namespace VorodKhoroj.Application.Coordinators;

/// <summary>
///     کلاس مایگریشن و اپدیت دستی دیتابیس بصورت نسخه ای
/// </summary>
/// <param name="migrationService"></param>
/// <param name="dbConfiguration"></param>
public class ManualMigrationServiceCoordinator(ManualMigrationService migrationService, AppDbContextConfiguration dbConfiguration)
{
    /// <summary>
    ///     مایگریشن وجود ستون ایدی و در صورت نداشتن اضافه شود
    /// </summary>
    public void EnsureIdColumnExists()
    {
        if (dbConfiguration.DbContext != null) migrationService.EnsureIdColumnExists(dbConfiguration.DbContext);
    }
}
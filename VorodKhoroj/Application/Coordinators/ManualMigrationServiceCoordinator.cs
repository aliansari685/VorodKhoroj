using VorodKhoroj.Infrastructure.Persistence;
using VorodKhoroj.Infrastructure.Persistence.Migrations;

namespace VorodKhoroj.Application.Coordinators;

/// <summary>
///     کلاس مایگریشن و اپدیت دستی دیتابیس بصورت نسخه ای
/// </summary>
/// <param name="migrationService"></param>
/// <param name="dbInitializer"></param>
public class ManualMigrationServiceCoordinator(DbStructureFixer migrationService, DbContextInitializer dbInitializer)
{
    /// <summary>
    ///     مایگریشن وجود ستون ایدی و در صورت نداشتن اضافه شود
    /// </summary>
    public void EnsureIdColumnExists()
    {
        if (dbInitializer.DbContext != null) migrationService.EnsureIdColumnExists(dbInitializer.DbContext);
    }
}
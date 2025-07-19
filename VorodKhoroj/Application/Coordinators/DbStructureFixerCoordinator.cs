namespace VorodKhoroj.Application.Coordinators;

/// <summary>
///     کلاس مایگریشن و اپدیت دستی دیتابیس بصورت نسخه ای
/// </summary>
/// <param name="migrationService"></param>
/// <param name="dbInitializer"></param>
public class DbStructureFixerCoordinator(DbStructureFixerEngine migrationService, IDbContextConfiguration dbInitializer) : IDbStructureFixer
{
    /// <summary>
    ///     مایگریشن وجود ستون ایدی و در صورت نداشتن اضافه شود
    /// </summary>
    public void EnsureIdColumnExists()
    {
        if (dbInitializer.DbContext == null)
            throw new NullReferenceException("خطای دیتابیس");
        migrationService.EnsureIdColumnExists(dbInitializer.DbContext);
    }
}
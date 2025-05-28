namespace VorodKhoroj.Coordinators
{
    public class ManualMigrationServiceCoordinator(ManualMigrationService migrationService, IAppDbContextProvider dbProvider)
    {
        public void EnsureIdColumnExists()
        {
            if (dbProvider.DbContext != null) migrationService.EnsureIdColumnExists(dbProvider.DbContext);
        }
    }
}

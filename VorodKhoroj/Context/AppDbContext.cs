namespace VorodKhoroj.Context
{
    public class AppDbContext(string serverName, string dbpath, string dbname, AppDbContext.DataBaseLocation typeDataBaseLocation) : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        /// <summary>
        /// داخلی یعنی از قبل اتچ شده 
        /// </summary>
        public enum DataBaseLocation
        {
            InternalDataBase, AttachDbFilename
        }

        private readonly string? _connectionString = typeDataBaseLocation switch
        {
            DataBaseLocation.AttachDbFilename =>
                $"Data Source={serverName};Integrated Security=True;AttachDbFilename={dbpath};TrustServerCertificate=True;Encrypt=False;Connection Timeout=5;User Instance=True;",

            DataBaseLocation.InternalDataBase =>
                $"Data Source={serverName};Database={dbname};Integrated Security=True;TrustServerCertificate=True;Connection Timeout=5;",

            _ => throw new ArgumentException("نوع کانفیگ دیتابیس نامعتبر است.")
        };
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Attendance>().HasKey(x => x.Id);

            modelBuilder.Entity<Attendance>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
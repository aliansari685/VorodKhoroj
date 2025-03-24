namespace VorodKhoroj.Data
{
    public class AppDbContext(string servername, string dbname, AppDbContext.DataBaseLocation typeDataBaseLocation) : DbContext
    {
        public DbSet<Attendance> Attendances { get; set; }

        public enum DataBaseLocation
        {
            InternalDataBase, AttachDbFilename
        }

        private readonly string? _connectionString = typeDataBaseLocation switch
        {
            DataBaseLocation.AttachDbFilename =>
                $@"Data Source={servername};Integrated Security=True;AttachDbFilename={dbname};TrustServerCertificate=True;Encrypt=False;Connection Timeout=5;User Instance=True;",

            DataBaseLocation.InternalDataBase =>
                $@"Data Source={servername};Database={dbname};Integrated Security=True;TrustServerCertificate=True;Connection Timeout=5;",

            _ => throw new ArgumentException("نوع کانفیگ دیتابیس نامعتبر است.")
        };
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasKey(a => new { a.UserId, a.DateTime }); // کلید ترکیبی
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
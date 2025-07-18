﻿namespace VorodKhoroj.Context
{
    public class AppDbContext(string serverName, string dbpath, string dbname, Enums.DataBaseLocation typeDataBaseLocation) : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        /// <summary>
        /// نوع دیتابیس: داخلی (از قبل attach شده) یا فایل attach شده
        /// </summary>


        //پشتیبانی کامل از 2 حالت کانکشن استرینگ برای دیتابیس محلی و داخلی
        private readonly string? _connectionString = typeDataBaseLocation switch
        {
            Enums.DataBaseLocation.AttachDbFilename =>
                $"Data Source={serverName};Integrated Security=True;AttachDbFilename={dbpath};TrustServerCertificate=True;Encrypt=False;Connection Timeout=30;",

            Enums.DataBaseLocation.InternalDataBase =>
                $"Data Source={serverName};Database={dbname};Integrated Security=True;TrustServerCertificate=True;Connection Timeout=5;",

            _ => throw new ArgumentException("نوع کانفیگ دیتابیس نامعتبر است.")
        };

        //ایجاد کلید اصلی جدول ها
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Attendance>().HasKey(x => x.Id);
                modelBuilder.Entity<Attendance>()
                    .Property(x => x.Id)
                    .ValueGeneratedOnAdd();
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }
    }
}
global using Serilog;
global using VorodKhoroj.Classes;
global using VorodKhoroj.Model;
global using VorodKhoroj.View;
global using System.Data;
global using System.Globalization;
global using OfficeOpenXml;
global using System.ComponentModel.DataAnnotations;
global using Microsoft.EntityFrameworkCore;
global using System.Runtime.CompilerServices;
global using VorodKhoroj.Application.Services;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using VorodKhoroj.Helpers;
global using System.ComponentModel;
global using VorodKhoroj.Models;
global using System.Linq.Expressions;
global using System.Reflection;
global using VorodKhoroj.Context;
global using System.ComponentModel.DataAnnotations.Schema;
global using System.Collections;
global using VorodKhoroj.Application.Coordinators;
global using VorodKhoroj.Domain.Interfaces;
global using System.Data.Common;
global using VorodKhoroj.Domain;
global using VorodKhoroj.Infrastructure;
global using VorodKhoroj.Infrastructure.Persistence;
global using VorodKhoroj.Infrastructure.Persistence.Repository;
global using VorodKhoroj.Infrastructure.Persistence.Migrations;
global using VorodKhoroj.Application;
global using VorodKhoroj.Infrastructure.UserProvider;



namespace VorodKhoroj
{
    internal static class Program
    {
        /// <summary>
        /// نقطه‌ی ورود اصلی برنامه ویندوزی.
        /// لاگ‌برداری، ساخت هاست، و اجرای فرم اصلی برنامه را انجام می‌دهد.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {

                // تنظیم مسیر فایل لاگ و پیکربندی Serilog
                var path = System.Windows.Forms.Application.StartupPath + @"tmpFile\log.txt";
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .Enrich.FromLogContext()
                    .WriteTo.File(path, rollingInterval: RollingInterval.Infinite,
                        outputTemplate: "{Timestamp: HH:mm } [{Level:u3}]: {Message:lj}{NewLine}{Exception}{NewLine}")
                    .CreateLogger();

                // تنظیمات اولیه فرم‌های ویندوز
                ApplicationConfiguration.Initialize();

                // ساخت میزبان (Host) با استفاده از DI
                var host = CreateHostBuilder().Build();

                // دریافت فرم اصلی از سرویس‌های تزریق‌شده
                var form = host.Services.GetRequiredService<FrmMain>();

                // تنظیم لایسنس EPPlus برای خروجی اکسل
                ExcelPackage.License.SetNonCommercialPersonal(@"Ali Ansari");

                System.Windows.Forms.Application.Run(form);
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }

        /// <summary>
        /// ساخت میزبان (Host) و تزریق وابستگی‌های برنامه شامل سرویس‌ها، فرم‌ها و Coordinatorها
        /// </summary>
        static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                {
                    // Coordinator And Service:
                    services.AddSingleton<IDbStructureFixer, DbStructureFixerCoordinator>();
                    services.AddSingleton<IDataBaseInitializer, DataBaseInitializerCoordinator>();
                    services.AddSingleton<IAttendanceDataService, AttendanceDataService>();
                    services.AddSingleton<IDataLoader, DataLoaderCoordinator>();
                    services.AddSingleton<IUserDataService, UserDataService>();

                    services.AddSingleton<AppServices>();

                    services.AddScoped<IDbContextConfiguration, DbContextInitializer>();

                    services.AddSingleton<DbStructureFixerEngine>();
                    services.AddSingleton<IRepository<User>, UserRepository>();
                    services.AddSingleton<IRepository<Attendance>, AttendanceRepository>();
                    services.AddSingleton<IAttendanceRepository, AttendanceRepository>();
                    services.AddSingleton<IDataBaseEngine, DataBaseEngine>();
                    services.AddSingleton<IAttendanceFileReader, AttendanceTextFileReader>();
                    services.AddTransient<AttendanceAnalyzer>();


                    // Forms:
                    services.AddScoped<FrmMain>();
                });
    }
}
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
global using VorodKhoroj.Services;
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
global using VorodKhoroj.Infrastructure;
global using VorodKhoroj.Coordinators;


namespace VorodKhoroj
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                var path = Application.StartupPath + @"tmpFile\log.txt";
                Log.Logger = new LoggerConfiguration().MinimumLevel.Information().Enrich.FromLogContext().WriteTo.File(path, rollingInterval: RollingInterval.Infinite, outputTemplate: "{Timestamp: HH:mm } [{Level:u3}]: {Message:lj}{NewLine}{Exception}{NewLine}").CreateLogger();

                ApplicationConfiguration.Initialize();

                var host = CreateHostBuilder().Build();

                var form = host.Services.GetRequiredService<FrmMain>();

                ExcelPackage.License.SetNonCommercialPersonal($@"AliAnsari");

                Application.Run(form);

            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }


        static IHostBuilder CreateHostBuilder() =>
             Host.CreateDefaultBuilder()
                 .ConfigureServices((_, services) =>
                 {
                     services.AddSingleton<AttendanceService>();
                     services.AddSingleton<UserService>();
                     services.AddSingleton<DataLoader>();
                     services.AddSingleton<DataRepository>();
                     services.AddSingleton<DatabaseService>();
                     services.AddSingleton<AppCoordinator>();
                     services.AddTransient<AttendanceFullCalculationService>();
                     services.AddScoped<FrmMain>();
                 });

    }
}
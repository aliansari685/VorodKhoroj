global using Serilog;
global using VorodKhoroj.Classes;
global using VorodKhoroj.Model;
global using VorodKhoroj.View;
global using System.Data;
global using System.Globalization;
global using OfficeOpenXml;
global using System.ComponentModel.DataAnnotations;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Migrations;
global using VorodKhoroj.Data;
global using Serilog.Core;
global using Serilog.Events;
global using System.Runtime.CompilerServices;
global using System.Diagnostics;
global using VorodKhoroj.Services;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.EntityFrameworkCore;


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
            var host = CreateHostBuilder().Build();

            ApplicationConfiguration.Initialize();

            var form = host.Services.GetRequiredService<Frm_Main>();

            ApplicationConfiguration.Initialize();

            Log.Logger = new LoggerConfiguration().MinimumLevel.Information().Enrich.FromLogContext().WriteTo.File(@"D:\\ApplicationError\log.txt", rollingInterval: RollingInterval.Infinite, outputTemplate: "{Timestamp: HH:mm } [{Level:u3}] {Method} {NewLine}{Message:lj}{NewLine}{Exception}").CreateLogger();

            Application.Run(form);

        }


        public static IHostBuilder CreateHostBuilder() =>
              Host.CreateDefaultBuilder()
                  .ConfigureServices((_, services) =>
                  {

                      services.AddSingleton<AppServices>();
                      services.AddTransient<AttendanceCalculationService>();
                      services.AddScoped<Frm_Main>();
                  });
    }
}
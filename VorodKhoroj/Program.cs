using Serilog;

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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Log.Logger = new LoggerConfiguration().MinimumLevel.Information().Enrich.FromLogContext().WriteTo.File(@"D:\\ApplicationError\log.txt", rollingInterval: RollingInterval.Infinite, outputTemplate: "{Timestamp: HH:mm } [{Level:u3}] ({propertyValue}){NewLine}{Message:lj}{NewLine}{Exception}").CreateLogger();
            Application.Run(new Frm_Main());
        }
    }
}
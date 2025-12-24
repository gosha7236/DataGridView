using Microsoft.Extensions.Logging;
using Serilog;
using Services;
using Log = Serilog.Log;

namespace DataGridView
{
    /// <summary>
    /// программный класс
    /// </summary>
    public class Program
    {
        [STAThread]
        static void Main()
        {
            // 🔹 1. Инициализация Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(
                    path: "logs/performance.log",
                    rollingInterval: RollingInterval.Day)
                .CreateLogger();

            // 🔹 2. Подключение Serilog к Microsoft ILogger
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });

            var logger = loggerFactory.CreateLogger<StorageManager>();

            // 🔹 3. Обычный запуск WinForms
            ApplicationConfiguration.Initialize();

            var storage = new Storage();
            var storageManager = new StorageManager(storage, logger);

            Application.Run(new MainForm(storageManager));
        }
    }
}
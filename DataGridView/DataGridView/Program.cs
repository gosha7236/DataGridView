using Microsoft.Extensions.Logging;
using Serilog;
using Services;
using Log = Serilog.Log;

namespace DataGridView
{
    /// <summary>
    /// Точка входа приложения
    /// </summary>
    public class Program
    {
        [STAThread]
        static void Main()
        {
            // 1️⃣ Настройка Serilog (логирование в файл)
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(
                    path: "logs/performance.log",
                    rollingInterval: RollingInterval.Day)
                .CreateLogger();

            // 2️⃣ Подключение Serilog к Microsoft.Extensions.Logging
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });

            var logger = loggerFactory.CreateLogger<StorageManager>();

            // 3️⃣ Запуск приложения
            ApplicationConfiguration.Initialize();

            var storage = new Storage();
            var storageManager = new StorageManager(storage, logger);

            Application.Run(new MainForm(new EFStorageManager()));
        }
    }
}
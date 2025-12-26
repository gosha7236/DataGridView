using DataBase;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Services;
using Services.Contacts;
using Services.Contracts;
using System;
using System.Windows.Forms;

namespace DataGridView
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
          
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .WriteTo.File(
                        path: "logs/performance.log",
                        rollingInterval: RollingInterval.Day)
                    .CreateLogger();
                var services = new ServiceCollection();

                services.AddLogging(builder =>
                {
                    builder.ClearProviders();
                    builder.AddSerilog();
                });
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(
                        @"Server=(localdb)\MSSQLLocalDB;Database=ItemsDb;Trusted_Connection=True;"));
                services.AddScoped<IStorage<Item>, DbStorage>();
                services.AddScoped<IStorageManager, StorageManager>();
                services.AddScoped<MainForm>();
                var provider = services.BuildServiceProvider();
                ApplicationConfiguration.Initialize();
                var mainForm = provider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }
    }
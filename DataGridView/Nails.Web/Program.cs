using DataBase;
using Entities;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Contacts;
using Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// DI
builder.Services.AddScoped<IStorage<Item>, DbStorage>();
builder.Services.AddScoped<IStorageManager, StorageManager>();

var app = builder.Build();

// Middleware
app.UseStaticFiles();
app.UseRouting();

// Routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Items}/{action=Index}/{id?}");

app.Run();
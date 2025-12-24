
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataBase
{
    public class AppDbContext : DbContext
    {
        public DbSet<Item> Items => Set<Item>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=ItemsDb;Trusted_Connection=True;");
        }
    }
}


using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataBase
{
    public class AppDbContext : DbContext
    {
        public DbSet<Item> Items => Set<Item>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}

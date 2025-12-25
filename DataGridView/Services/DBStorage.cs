using DataBase;
using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Contacts;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Хранилище данных на базе EF Core
    /// </summary>
    public class DbStorage : IStorage<Item>
    {
        private readonly AppDbContext dbContext;

        public DbStorage(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Item>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await dbContext.Items
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Item item, CancellationToken cancellationToken)
        {
            await dbContext.Items.AddAsync(item, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Item newItem, CancellationToken cancellationToken)
        {
            dbContext.Items.Update(newItem);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await dbContext.Items
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (item == null)
                return;

            dbContext.Items.Remove(item);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
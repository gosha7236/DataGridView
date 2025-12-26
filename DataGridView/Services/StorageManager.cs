using Entities;
using Microsoft.Extensions.Logging;
using Services.Contacts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public class StorageManager : IStorageManager
    {
        private readonly IStorage<Item> storage;
        private readonly ILogger<StorageManager> logger;

        public StorageManager(IStorage<Item> storage, ILogger<StorageManager> logger)
        {
            this.storage = storage;
            this.logger = logger;
        }

        public async Task AddItemAsync(Item item, CancellationToken cancellationToken = default)
        {
            using var _ = logger.BeginScope("Adding item with ID: {ItemId}", item.Id);
            var sw = System.Diagnostics.Stopwatch.StartNew();

            await storage.AddAsync(item, cancellationToken).ConfigureAwait(false);

            sw.Stop();
            logger.LogInformation(
                "Method {Method} executed in {Time} ms",
                nameof(AddItemAsync),
                sw.ElapsedMilliseconds);
        }

        public async Task<IReadOnlyList<Item>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();

            var result = await storage.GetAllAsync(cancellationToken).ConfigureAwait(false);

            sw.Stop();
            logger.LogInformation(
                "Method {Method} executed in {Time} ms",
                nameof(GetAllAsync),
                sw.ElapsedMilliseconds);

            return result;
        }

        public async Task RemoveItemAsync(Guid id, CancellationToken cancellationToken = default)
        {
            using var _ = logger.BeginScope("Removing item with ID: {ItemId}", id);
            var sw = System.Diagnostics.Stopwatch.StartNew();

            await storage.DeleteAsync(id, cancellationToken).ConfigureAwait(false);

            sw.Stop();
            logger.LogInformation(
                "Method {Method} executed in {Time} ms",
                nameof(RemoveItemAsync),
                sw.ElapsedMilliseconds);
        }

        public async Task UpdateItemAsync(Item item, CancellationToken cancellationToken = default)
        {
            using var _ = logger.BeginScope("Updating item with ID: {ItemId}", item.Id);
            var sw = System.Diagnostics.Stopwatch.StartNew();

            await storage.UpdateAsync(item, cancellationToken).ConfigureAwait(false);

            sw.Stop();
            logger.LogInformation(
                "Method {Method} executed in {Time} ms",
                nameof(UpdateItemAsync),
                sw.ElapsedMilliseconds);
        }
    }
}
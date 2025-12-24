using Entities;
using Microsoft.Extensions.Logging;
using Services.Contacts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Services
{
    /// <summary>
    /// Класс управления действиями бизнес-логики.
    /// Выполняет логирование производительности методов.
    /// </summary>
    public class StorageManager : IStorageManager
    {
        private readonly IStorage<Item> storage;
        private readonly ILogger<StorageManager> logger;

        public StorageManager(IStorage<Item> storage, ILogger<StorageManager> logger)
        {
            this.storage = storage;
            this.logger = logger;
        }

        /// <summary>
        /// Добавление элемента в хранилище.
        /// В лог записывается имя метода и время выполнения в миллисекундах.
        /// </summary>
        public void AddItem(Item item)
        {
            var stopwatch = Stopwatch.StartNew();

            storage.AddAsync(item, CancellationToken.None)
                   .GetAwaiter()
                   .GetResult();

            stopwatch.Stop();

            logger.LogInformation(
                "Method {MethodName} executed in {ElapsedMilliseconds} ms",
                nameof(AddItem),
                stopwatch.ElapsedMilliseconds);
        }

        /// <summary>
        /// Получение всех элементов.
        /// </summary>
        public IReadOnlyCollection<Item> GetAll()
        {
            var stopwatch = Stopwatch.StartNew();

            var result = storage.GetAllAsync(CancellationToken.None)
                                .GetAwaiter()
                                .GetResult();

            stopwatch.Stop();

            logger.LogInformation(
                "Method {MethodName} executed in {ElapsedMilliseconds} ms",
                nameof(GetAll),
                stopwatch.ElapsedMilliseconds);

            return result;
        }

        /// <summary>
        /// Удаление элемента.
        /// </summary>
        public void RemoveItem(Guid id)
        {
            var stopwatch = Stopwatch.StartNew();

            storage.DeleteAsync(id, CancellationToken.None)
                   .GetAwaiter()
                   .GetResult();

            stopwatch.Stop();

            logger.LogInformation(
                "Method {MethodName} executed in {ElapsedMilliseconds} ms",
                nameof(RemoveItem),
                stopwatch.ElapsedMilliseconds);
        }

        /// <summary>
        /// Обновление элемента.
        /// </summary>
        public void UpdateItem(Item newItem)
        {
            var stopwatch = Stopwatch.StartNew();

            storage.UpdateAsync(newItem, CancellationToken.None)
                   .GetAwaiter()
                   .GetResult();

            stopwatch.Stop();

            logger.LogInformation(
                "Method {MethodName} executed in {ElapsedMilliseconds} ms",
                nameof(UpdateItem),
                stopwatch.ElapsedMilliseconds);
        }
    }
}
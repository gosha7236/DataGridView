using Entities;
using Services.Contacts;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// хранилище
    /// </summary>
    public static class StorageManager
    {
        private static IStorage<Item>? _storage;
        private static List<Item> _items = new();

        /// <summary>
        /// чтение значений
        /// </summary>
        public static IReadOnlyList<Item> Items => _items;
        /// <summary>
        /// инизиализация
        /// </summary>
        /// <param name="storage"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Initialize(IStorage<Item> storage)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }
        /// <summary>
        /// загрузка
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task LoadAsync(CancellationToken cancellationToken = default)
        {
            EnsureInitialized();
            _items = new List<Item>(await _storage!.GetAllAsync(cancellationToken));
        }
        /// <summary>
        /// добавление значения
        /// </summary>
        /// <param name="item"></param>
        public static void AddItem(Item item)
        {
            EnsureInitialized();
            _items.Add(item);
            _storage!.AddAsync(item, CancellationToken.None).GetAwaiter().GetResult();
        }
        /// <summary>
        /// удаление значения
        /// </summary>
        /// <param name="index"></param>
        public static void RemoveItem(int index)
        {
            EnsureInitialized();
            if (index < 0 || index >= _items.Count)
                return;

            var item = _items[index];
            _items.RemoveAt(index);
            _storage!.DeleteAsync(item, CancellationToken.None).GetAwaiter().GetResult();
        }
        /// <summary>
        /// обновление значения
        /// </summary>
        /// <param name="index"></param>
        /// <param name="newItem"></param>
       public static void UpdateItem(int index, Item newItem)
        {
            EnsureInitialized();
            if (index < 0 || index >= _items.Count)
                return;

            var oldItem = _items[index];
            _items[index] = newItem;
            _storage!.UpdateAsync(oldItem, newItem, CancellationToken.None).GetAwaiter().GetResult();
        }

        private static void EnsureInitialized()
        {
            if (_storage is null)
                throw new InvalidOperationException(
                    "StorageManager is not initialized. Call Initialize() first.");
        }
    }
}
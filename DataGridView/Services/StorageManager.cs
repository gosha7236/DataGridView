using Entities;
using Services.Contacts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// хранилище
    /// </summary>
    public class StorageManager : IStorageManager
    {
        private IStorage<Item>? storage;
        public StorageManager(IStorage<Item> storage) 
        {
            this.storage = storage;
        }
        /// <summary>
        /// добавление значения
        /// </summary>
        /// <param name="item"></param>
        public  void AddItem(Item item)
        {
            storage!.AddAsync(item, CancellationToken.None).GetAwaiter().GetResult();
        }

        public IReadOnlyCollection<Item> GetAll()
        {
            return storage.GetAllAsync(CancellationToken.None).GetAwaiter().GetResult();
        }

        /// <summary>
        /// удаление значения
        /// </summary>
        /// <param name="index"></param>
        public void RemoveItem(Guid id)
        {
            storage!.DeleteAsync(id, CancellationToken.None).GetAwaiter().GetResult();
        }
        /// <summary>
        /// обновление значения
        /// </summary>
        /// <param name="index"></param>
        /// <param name="newItem"></param>
        public void UpdateItem( Item newItem)
        { 
            storage!.UpdateAsync( newItem, CancellationToken.None).GetAwaiter().GetResult();
        }
    }
}
using Entities;
using Services.Contacts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// класс Storage
    /// </summary>
    public class Storage : IStorage<Item>
    {
        private readonly List<Item> _items = new();
       /// <summary>
       /// чтение списка
       /// </summary>
       /// <param name="cancellationToken"></param>
       /// <returns></returns>
        public Task<IReadOnlyList<Item>> GetAllAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult((IReadOnlyList<Item>)_items.ToList());
        }
       /// <summary>
       /// добавление значения в хранилище
       /// </summary>
       /// <param name="item"></param>
       /// <param name="cancellationToken"></param>
       /// <returns></returns>
        public Task AddAsync(Item item, CancellationToken cancellationToken)
        {
            _items.Add(item);
            return Task.CompletedTask;
        }
        /// <summary>
        /// удаление значения из хранилища
        /// </summary>
        /// <param name="item"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task DeleteAsync(Item item, CancellationToken cancellationToken)
        {
            _items.Remove(item);
            return Task.CompletedTask;
        }
       /// <summary>
       /// обновление хранилища
       /// </summary>
       /// <param name="oldItem"></param>
       /// <param name="newItem"></param>
       /// <param name="cancellationToken"></param>
       /// <returns></returns>
        public Task UpdateAsync(Item oldItem, Item newItem, CancellationToken cancellationToken)
        {
            int index = _items.IndexOf(oldItem);
            if (index >= 0)
                _items[index] = newItem;

            return Task.CompletedTask;
        }
    }
}
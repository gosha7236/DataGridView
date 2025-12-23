using Entities;
using Services.Contacts;
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
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
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
        public Task UpdateAsync( Item newItem, CancellationToken cancellationToken)
        {
           var item = _items.FirstOrDefault(x => x.Id == newItem.Id);
            if (item != null)
            {
                item.Size = newItem.Size;
                item.Price = newItem.Price;
                item.Material = newItem.Material;
                item.Amount = newItem.Amount;
            }
           return Task.CompletedTask;
        }
    }
}
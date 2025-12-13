
using DataGridView.Classes;
using Services.Contacts;
using System.Linq;
namespace Services
{
    public class Storage : IStorage<Item>
    {
        private readonly List<Item> _items = new();

        public async Task<IEnumerable<Item>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await Task.FromResult(_items.ToList());
        }

        public async Task AddAsync(Item item, CancellationToken cancellationToken)
        {
            _items.Add(item);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Item item, CancellationToken cancellationToken)
        {
            _items.Remove(item);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Item oldItem, Item newItem, CancellationToken cancellationToken)
        {

            int index = _items.IndexOf(oldItem);
            if (index >= 0)
                _items[index] = newItem;

            await Task.CompletedTask;
        }
    }
}

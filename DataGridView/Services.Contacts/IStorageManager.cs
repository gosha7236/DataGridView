using DataGridView.Classes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Services.Contracts
{
    public interface IStorageManager
    {
        IReadOnlyList<Item> Items { get; }

        Task LoadAsync(CancellationToken cancellationToken = default);
        void Load();

        Task SaveAsync(CancellationToken cancellationToken = default);
        void Save();

        void AddItem(Item item);
        void RemoveItem(int index);
        void UpdateItem(int index, Item newItem);
    }
}
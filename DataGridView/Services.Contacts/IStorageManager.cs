using Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Services.Contracts
{
    /// <summary>
    /// интерфейс для хранилища
    /// </summary>
    public interface IStorageManager
    {
        void AddItem(Item item);
        void RemoveItem(Guid id);
        void UpdateItem( Item newItem);
        IReadOnlyCollection<Item> GetAll();
    }
}
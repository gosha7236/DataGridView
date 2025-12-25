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
        Task<IReadOnlyList<Item>> GetAllAsync(CancellationToken ct = default);
        Task AddItemAsync(Item item, CancellationToken ct = default);
        Task UpdateItemAsync(Item item, CancellationToken ct = default);
        Task RemoveItemAsync(Guid id, CancellationToken ct = default);
    }
}
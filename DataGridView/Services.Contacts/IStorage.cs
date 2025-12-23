using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Contacts
{
    /// <summary>
    /// интерфейс для Storage
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IStorage<T>
    {
        /// <summary>
        /// Получить все элементы.
        /// </summary>
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Добавить новый элемент.
        /// </summary>
        Task AddAsync(T item, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить элемент.
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить существующий элемент.
        /// </summary>
        Task UpdateAsync(T newItem, CancellationToken cancellationToken);
    }
}
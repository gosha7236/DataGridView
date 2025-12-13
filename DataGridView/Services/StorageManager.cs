using DataGridView.Classes;
using Services.Contacts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Services
{
    // Статический помощник, чтобы UI мог работать так же, как раньше — Storage.Items / AddItem / RemoveItem
    public class StorageManager
    {
        // Здесь мы держим реализацию IStorage<Item>.
        // В будущем можно инжектить другую реализацию.
        private static readonly Storage _impl = new Storage();

        // Кешированная рабочая коллекция (просто чтобы UI мог привязаться).
        // Если хотите, можно вернуть BindingList<Item> и привязывать DataGridView к BindingList.
        private static List<Item> _items = new List<Item>();

        public static IReadOnlyList<Item> Items => _items;
        
        public static async Task LoadAsync(CancellationToken cancellationToken = default)
        {
            // если вы сохраняете в файл через DataSerializer — загрузим
            _items = DataSerializer.LoadItems();
            // Если вы хотите загрузить из асинхронного хранилища — можете вызывать _impl.GetAllAsync(...)
            await Task.CompletedTask;
        }

        public static void Load() => LoadAsync().GetAwaiter().GetResult();

        public static async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            DataGridView.Classes.DataSerializer.SaveItems(_items);
            await Task.CompletedTask;
        }

        public static void Save() => SaveAsync().GetAwaiter().GetResult();

        public static void AddItem(Item item)
        {
            _items.Add(item);
            // сохранить (по желанию)
            Save();
        }

        public static void RemoveItem(int index)
        {
            if (index >= 0 && index < _items.Count)
            {
                _items.RemoveAt(index);
                Save();
            }
        }

        public static void UpdateItem(int index, Item newItem)
        {
            if (index >= 0 && index < _items.Count)
            {
                _items[index] = newItem;
                Save();
            }
        }
    }
}
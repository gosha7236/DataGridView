namespace DataGridView.Classes
{
    public static class Storage
    {
        private static List<Item> _items;

        public static List<Item> Items
        {
            get
            {
                if (_items == null)
                {
                    _items = DataSerializer.LoadItems();

                    // Если файла не было, создаем тестовые данные
                    if (_items.Count == 0)
                    {
                    //    _items = GetDefaultItems();
                        DataSerializer.SaveItems(_items);
                    }
                }
                return _items;
            }
        }

        public static void SaveData()
        {
            DataSerializer.SaveItems(_items);
        }

        public static void AddItem(Item item)
        {
            _items.Add(item);
            SaveData();
        }

        public static void UpdateItem(int index, Item item)
        {
            if (index >= 0 && index < _items.Count)
            {
                _items[index] = item;
                SaveData();
            }
        }

        public static void RemoveItem(int index)
        {
            if (index >= 0 && index < _items.Count)
            {
                _items.RemoveAt(index);
                SaveData();
            }
        }

       /* private static List<Item> GetDefaultItems()
        {
            return new List<Item>
            {

            };
        } */
    }
}
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using DataGridView.Classes;

namespace DataGridView
{
   /// <summary>
   /// класс для хранения
   /// </summary>
    public static class Storage
    {
        private static readonly string Path = "data.json";

        /// <summary>
        /// список значений
        /// </summary>
        public static List<Item> Items { get; private set; } = new List<Item>();

        static Storage() => LoadData();
        /// <summary>
        /// функция для добавления нового значения
        /// </summary>
         /// значение
        /// <param name="item"></param>
        public static void AddItem(Item item)
        {
            Items.Add(item);
            SaveData();
        }
        /// <summary>
        /// метод для обновления значений
        /// </summary>
        /// индекс
        /// <param name="index"></param>
        /// значение
        /// <param name="item"></param>
        public static void UpdateItem(int index, Item item)
        {
            Items[index] = item;
            SaveData();
        }
        /// <summary>
        /// удаление значения по индексу
        /// </summary>
        /// <param name="index"></param>
        public static void RemoveItem(int index)
        {
            Items.RemoveAt(index);
            SaveData();
        }
        /// <summary>
        /// сохранение значений
        /// </summary>
        public static void SaveData()
        {
            var json = JsonSerializer.Serialize(Items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Path, json);
        }
        /// <summary>
        /// загрузка значений
        /// </summary>
        public static void LoadData()
        {
            if (!File.Exists(Path))
                return;

            string json = File.ReadAllText(Path);
            Items = JsonSerializer.Deserialize<List<Item>>(json) ?? new List<Item>();
        }
    }
}
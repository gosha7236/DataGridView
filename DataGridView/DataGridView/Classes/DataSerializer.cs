using System.Text.Json;
using System.Text.Json.Serialization;

namespace DataGridView.Classes
{
    /// <summary>
    /// класс для сохранения данных
    /// </summary>
    public static class DataSerializer
    {
        private static readonly string FilePath = "items.json";
        /// <summary>
        /// функция для сохранения значений
        /// </summary>
        /// <param name="items"></param>
        public static void SaveItems(List<Item> items)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                string json = JsonSerializer.Serialize(items, options);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// загрузка значений из списка
        /// </summary>
        /// <returns></returns>
        public static List<Item> LoadItems()
        {
            try
            {
                if (!File.Exists(FilePath))
                    return new List<Item>();

                string json = File.ReadAllText(FilePath);
                var items = JsonSerializer.Deserialize<List<Item>>(json);
                return items ?? new List<Item>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Item>();
            }
        }
    }
}
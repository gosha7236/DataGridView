namespace DataGridView.Classes
{
    /// <summary>
    /// класс для хранения значения
    /// </summary>
    public class Item
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public int Amount { get; set; }

        // Переименовано в PascalCase чтобы биндинг DataGridView работал.
        public int MinCount { get; set; }

        public decimal Price { get; set; }

        // Вычисляемое поле (total)
        public decimal Total => Amount * Price;

        // Для биндинга столбца "AllPrice" у вас в DataGridView использовалось "AllPrice"
        // оставим удобное свойство с тем же именем:
        public decimal AllPrice => Total;

        public Item() { }

        public Item Clone()
        {
            return new Item
            {
                Name = this.Name,
                Size = this.Size,
                Material = this.Material,
                Amount = this.Amount,
                Price = this.Price,
                MinCount = this.MinCount
            };
        }
    }
}
namespace DataGridView.Classes
{
    /// <summary>
    /// класс для хранения значения
    /// </summary>
    public class Item
    {
        /// <summary>
        /// переменная с именем
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// хранит размер
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// хранит материал
        /// </summary>
        public string Material { get; set; }
        /// <summary>
        /// хранит количество
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// хранит мни.кол-во
        /// </summary>
        public int MinLimit { get; set; }
        /// <summary>
        /// хранит цену
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        ///  хранит общую цену
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Конструктор по умолчанию для JSON сериализации
        /// </summary>
        public Item() { }
        /// <summary>
        /// конструктор с параметрами
        /// </summary>
        /// <param name="name"></param>
        /// <param name="size"></param>
        /// <param name="material"></param>
        /// <param name="quantity"></param>
        /// <param name="minLimit"></param>
        /// <param name="price"></param>
        /// <param name="total"></param>
        public Item(string name, string size, string material, int quantity, int minLimit, decimal price, decimal total)
        {
            Name = name;
            Size = size;
            Material = material;
            Quantity = quantity;
            MinLimit = minLimit;
            Price = price;
            Total = total;
        }
    }
}
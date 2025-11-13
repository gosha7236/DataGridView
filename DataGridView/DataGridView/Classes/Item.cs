namespace DataGridView.Classes
{
    public class Item
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public int Quantity { get; set; }
        public int MinLimit { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }

        // Конструктор по умолчанию для JSON сериализации
        public Item() { }

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
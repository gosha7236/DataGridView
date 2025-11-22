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
        /// переменная с размером
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// переменная с материалом
        /// </summary>
        public string Material { get; set; }
        /// <summary>
        /// переменная с количеством
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// переменная с мин.количеством
        /// </summary>
        public int minCount { get; set; }
        /// <summary>
        /// переменная с ценой
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Total теперь не хранится в файле — он вычисляется каждый раз
        /// </summary>
        public decimal Total => Amount * Price;

        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public Item() { }
        /// <summary>
        /// метод
        /// </summary>
        /// <returns></returns>
        public Item Clone()
        {
            return new Item
            {
                Name = this.Name,
                Size = this.Size,
                Material = this.Material,
                Amount = this.Amount,
                Price = this.Price,
                minCount = this.minCount
            };
        }
    }
}
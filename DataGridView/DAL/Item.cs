namespace Entities
{
    /// <summary>
    /// класс значения
    /// </summary>
    public class Item
    {
        /// <summary>
        /// имя
        /// </summary>
        public string Name { get; set; } = string.Empty;
       /// <summary>
       /// размер
       /// </summary>
        public string Size { get; set; } = string.Empty;
       /// <summary>
       /// материал
       /// </summary>
        public string Material { get; set; } = string.Empty;
       /// <summary>
       /// количество
       /// </summary>

        public int Amount { get; set; }
       /// <summary>
       /// мин.количество
       /// </summary>
        public int MinCount { get; set; }
      /// <summary>
      ///  цена
      /// </summary>
        public decimal Price { get; set; }
       /// <summary>
       /// всего
       /// </summary>
        public decimal Total => Amount * Price;
       /// <summary>
       /// общая цена
       /// </summary>
        public decimal AllPrice => Total;

       /// <summary>
       /// метод для считывания
       /// </summary>
       /// <returns></returns>
        public Item Clone()
        {
            return new Item
            {
                Name = Name,
                Size = Size,
                Material = Material,
                Amount = Amount,
                MinCount = MinCount,
                Price = Price
            };
        }
    }
}
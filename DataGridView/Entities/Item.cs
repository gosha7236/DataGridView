using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// класс значения
    /// </summary>
    public class Item
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// имя
        /// </summary>
        [Required]
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
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        /// <summary>
        /// всего
        /// </summary>
        [NotMapped]
        public decimal Total => Amount * Price;
        /// <summary>
        /// общая цена
        /// </summary>
        [NotMapped]
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
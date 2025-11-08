using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // Общая сумма товара (без НДС)
        public decimal Total => Price * Quantity;
    }
}

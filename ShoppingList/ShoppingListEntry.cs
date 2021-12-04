using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    internal class ShoppingListEntry
    {
        public ShoppingListEntry() { }

        public ShoppingListEntry(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
        
        public string Name { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            string displayValue = Quantity.ToString();

            displayValue += $"x {Name}";

            return displayValue;
        }
    }
}

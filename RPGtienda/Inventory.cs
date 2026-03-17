using System;
using System.Collections.Generic;
using System.Text;

namespace RPGtienda
{
    public class Inventory
    {
        public List<Item> Equipment { get; private set; }
        public List<Item> Supplies { get; private set; }

        public Inventory()
        {
            Equipment = new List<Item>();
            Supplies = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (item.Category == ItemCategory.Supply)
            {
                Supplies.Add(item);
            }
            else
            {
                Equipment.Add(item);
            }
        }
    }
}

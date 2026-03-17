using System;
using System.Collections.Generic;
using System.Text;

namespace RPGtienda
{
    public class Item
    {
        public string Name { get; }
        public int Price { get; }
        public ItemCategory Category { get; }

        public Item(string name, int price, ItemCategory category)
        {

        }
    }
}

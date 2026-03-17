using System;
using System.Collections.Generic;
using System.Text;


namespace RPGtienda
{
    public class Item
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public ItemCategory Category { get; private set; }

        public Item(string name, int price, ItemCategory category)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException();

            if (price <= 0)
                throw new ArgumentException();

            Name = name;
            Price = price;
            Category = category;
        }
    }
}

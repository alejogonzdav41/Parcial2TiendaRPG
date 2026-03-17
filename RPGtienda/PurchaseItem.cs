using System;
using System.Collections.Generic;
using System.Text;

namespace RPGtienda
{
    public class PurchaseItem
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }

        public PurchaseItem(Item item, int quantity)
        {

        }
    }
}

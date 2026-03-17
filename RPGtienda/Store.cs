using System;
using System.Collections.Generic;
using System.Text;

namespace RPGtienda
{
    public class Store
    {
        private Dictionary<Item, int> inventory;

        public Store()
        {
            inventory = new Dictionary<Item, int>();
        }

        public void AddItem(Item item, int quantity)
        {
            if (inventory.ContainsKey(item))
            {
                inventory[item] += quantity;
            }
            else
            {
                inventory.Add(item, quantity);
            }
        }

        public int GetStock(Item item)
        {
            if (inventory.ContainsKey(item))
                return inventory[item];

            return 0;
        }

        public bool Buy(Player player, List<PurchaseItem> items)
        {
            int total = 0;

            int i = 0;

            while (i < items.Count)
            {
                PurchaseItem purchase = items[i];

                if (!inventory.ContainsKey(purchase.Item))
                    return false;

                if (inventory[purchase.Item] < purchase.Quantity)
                    return false;

                total += purchase.Item.Price * purchase.Quantity;

                i++;
            }

            if (!player.CanAfford(total))
                return false;

            player.Pay(total);

            i = 0;

            while (i < items.Count)
            {
                PurchaseItem purchase = items[i];

                inventory[purchase.Item] -= purchase.Quantity;

                int j = 0;

                while (j < purchase.Quantity)
                {
                    player.ReceiveItem(purchase.Item);
                    j++;
                }

                i++;
            }

            return true;
        }
    }
}

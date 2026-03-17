using System;
using System.Collections.Generic;
using System.Text;

namespace RPGtienda
{
    public class Player
    {
        public int Gold { get; private set; }

        public Inventory Inventory { get; private set; }

        public Player(int gold)
        {
            Gold = gold;
            Inventory = new Inventory();
        }

        public bool CanAfford(int price)
        {
            return Gold >= price;
        }

        public void Pay(int price)
        {
            Gold -= price;
        }

        public void ReceiveItem(Item item)
        {
            Inventory.AddItem(item);
        }
    }
}

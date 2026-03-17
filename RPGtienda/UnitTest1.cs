using NUnit.Framework;
using System.Collections.Generic;

namespace RPGtienda
{
    [TestFixture]
    public class Tests
    {
        // Creación de items

        private static IEnumerable<TestCaseData> ItemsData()
        {
            yield return new TestCaseData(new Item("Sword", 100, ItemCategory.Weapon))
                .SetName("CreateItem_Weapon");

            yield return new TestCaseData(new Item("Armor", 200, ItemCategory.Armor))
                .SetName("CreateItem_Armor");

            yield return new TestCaseData(new Item("Potion", 50, ItemCategory.Supply))
                .SetName("CreateItem_Supply");
        }


        [TestCaseSource(nameof(ItemsData))]
        public void CreateItem(Item item)
        {
            Assert.That(item.Name, Is.Not.Null);
            Assert.That(item.Name, Is.Not.EqualTo(string.Empty));
            Assert.That(item.Price, Is.GreaterThan(0));
        }


        // Creación de la tienda

        private static IEnumerable<TestCaseData> StoreData()
        {
            Store store = new Store();

            Item sword = new Item("Sword", 100, ItemCategory.Weapon);

            store.AddItem(sword, 5);

            yield return new TestCaseData(store, sword)
                .SetName("Store_AddItem");
        }

        [TestCaseSource(nameof(StoreData))]
        public void AddItemToStore(Store store, Item item)
        {
            Assert.That(store.GetStock(item), Is.GreaterThan(0));
        }

        // Creación de personaje
        private static IEnumerable<TestCaseData> PlayerData()
        {
            yield return new TestCaseData(new Player(100))
                .SetName("CreatePlayer_100Gold");

            yield return new TestCaseData(new Player(500))
                .SetName("CreatePlayer_500Gold");
        }

        [TestCaseSource(nameof(PlayerData))]
        public void CreatePlayer(Player player)
        {   
            Assert.That(player.Gold, Is.GreaterThanOrEqualTo(0));
            Assert.That(player.Inventory, Is.Not.Null);
        }

        // Error en en la compra por falta de items en stock

        private static IEnumerable<TestCaseData> PurchaseFailStockData()
        {
            Store store = new Store();
            Player player = new Player(500);

            Item sword = new Item("Sword", 100, ItemCategory.Weapon);

            store.AddItem(sword, 0);

            List<PurchaseItem> purchase = new List<PurchaseItem>();
            purchase.Add(new PurchaseItem(sword, 1));

            yield return new TestCaseData(store, player, purchase)
                .SetName("Purchase_Fail_NoStock");
        }

        [TestCaseSource(nameof(PurchaseFailStockData))]
        public void BuyItemFailStock(Store store, Player player, List<PurchaseItem> purchase)
        {
            bool result = store.Buy(player, purchase);

            Assert.That(result, Is.False);
        }

        // Error en l compra por falta de oro

        private static IEnumerable<TestCaseData> PurchaseFailMoneyData()
        {
            Store store = new Store();
            Player player = new Player(10);

            Item sword = new Item("Sword", 100, ItemCategory.Weapon);

            store.AddItem(sword, 5);

            List<PurchaseItem> purchase = new List<PurchaseItem>();
            purchase.Add(new PurchaseItem(sword, 1));

            yield return new TestCaseData(store, player, purchase)
                .SetName("Purchase_Fail_NotEnoughMoney");
        }

        [TestCaseSource(nameof(PurchaseFailMoneyData))]
        public void BuyItemFailMoney(Store store, Player player, List<PurchaseItem> purchase)
        {
            bool result = store.Buy(player, purchase);

            Assert.That(result, Is.False);
        }

        // Compra exitosa
        private static IEnumerable<TestCaseData> PurchaseSuccessData()
        {
            Store store = new Store();
            Player player = new Player(500);

            Item sword = new Item("Sword", 100, ItemCategory.Weapon);

            store.AddItem(sword, 5);

            List<PurchaseItem> purchase = new List<PurchaseItem>();
            purchase.Add(new PurchaseItem(sword, 1));

            yield return new TestCaseData(store, player, purchase)
                .SetName("Purchase_Success");
        }

        [TestCaseSource(nameof(PurchaseSuccessData))]
        public void BuyItemSuccess(Store store, Player player, List<PurchaseItem> purchase)
        {
            bool result = store.Buy(player, purchase);

            Assert.That(result);
            Assert.That(player.Gold, Is.LessThan(500));
        }

    }
}

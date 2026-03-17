using NUnit.Framework;
using System.Collections.Generic;

namespace RPGtienda
{
    [TestFixture]
    public class Tests
    {
        // CREACIÓN DE ITEMS

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



    }
}

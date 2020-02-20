using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new RegularItem { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        [Test]
        public void ItemSellInDecreasesAfterADay()
        {
            IList<Item> Items = new List<Item> { new RegularItem { Name = "foo", SellIn = 10, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].SellIn);
        }

        [Test]
        public void ItemDecreasesInQualityAfterADay()
        {
            IList<Item> Items = new List<Item> { new RegularItem { Name = "foo", SellIn = 10, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(4, Items[0].Quality);
        }
        
        [Test]
        public void QualityDegradesTwiceAsFastAfterSellIn()
        {
            IList<Item> Items = new List<Item> { new RegularItem { Name = "Bizzles", SellIn = 0, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(3, Items[0].Quality);
        }

        [Test]
        public void AgedBrieQualityIncreasesTwiceAsFastAfterSellIn()
        {
            IList<Item> Items = new List<Item> { new AgedBrie { Name = "Brie", SellIn = 0, Quality = 7 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].Quality);
        }

        [Test]
        public void QualityIsNeverNegative()
        {
            IList<Item> Items = new List<Item> { new RegularItem { Name = "Bizzles", SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }
        [Test]
        public void QualityIsNeverMoreThanFifty()
        {
            IList<Item> Items = new List<Item> { new AgedBrie { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.AreEqual(50, Items[0].Quality);
        }
        [Test]
        public void SulfurasNeverLosesQuality()
        {
            IList<Item> Items = new List<Item> { new Sulfuras { Name = "Sulfuras", SellIn = 0, Quality = 40 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(40, Items[0].Quality);
        }

        [Test]
        public void BackStagePassesQualityIncreasesBy1WithMoreThanTenDays()
        {
            IList<Item> Items = new List<Item> { new ConcertPass { Name = "Backstage pass", SellIn = 12, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(31, Items[0].Quality);
        }

        [Test]
        public void BackStagePassesQualityIncreasesBy2WithTenDaysOrLess()
        {
            IList<Item> Items = new List<Item> { new ConcertPass { Name = "Backstage passes", SellIn = 10, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(32, Items[0].Quality);
        }

        [Test]
        public void BackStagePassesQualityIncreasesBy3WithFiveDaysOrLess()
        {
            IList<Item> Items = new List<Item> { new ConcertPass { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(33, Items[0].Quality);
        }

        [Test]
        public void BackStagePassesQualityDropsToZeroAfterConcert()
        {
            IList<Item> Items = new List<Item> { new ConcertPass { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void AgedBrieIncreasesInQualityAfterADay()
        {
            IList<Item> items = new List<Item> { new AgedBrie {Name="", SellIn=10, Quality=5 } };
            
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(6, items[0].Quality);
        }
    }
}

using System.Collections.Generic;
using Xunit;

namespace csharp
{
    public class GildedRoseTest
    {
        [Fact]
        public void Empty()
        {
            var items = new List<Item>();
            UpdateQuality(items);
            Assert.Empty(items);
        }

        [Fact]
        public void RegularItem_QualityGreaterThanZero_ShouldDecreaseQuality()
        {
            var items = new List<Item>
            {
                new RegularItem { Quality = 50 }
            };
            
            UpdateQuality(items);

            var item = Assert.Single(items);
            
            Assert.Equal(49, item.Quality);
        }

        [Fact]
        public void RegularItem_QualityZero_ShouldNotUpdateQuality()
        {
            var items = new List<Item>
            {
                new RegularItem { Quality = 0 }
            };
            
            UpdateQuality(items);

            var item = Assert.Single(items);
            
            Assert.Equal(0, item.Quality);
        }

        private static void UpdateQuality(List<Item> items) => 
            new GildedRose(items).UpdateQuality();
    }

    public class RegularItem : Item
    {
        public RegularItem()
        {
            Name = "Milk";
            Quality = 10;
            SellIn = 10;
        }
    }
}

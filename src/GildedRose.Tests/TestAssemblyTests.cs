using GildedRose.Console;
using System;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void DefaultItemsShouldDecreaseSellInAndQuality()
        {
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
            var strategy = StrategyFactory.GetStrategy(item);
            strategy.UpdateQuality();

            Assert.Equal(item.SellIn, 9);
            Assert.Equal(item.Quality, 19);
            Assert.InRange(item.Quality, 0, 50);
        }

        [Fact]
        public void AgedBrieShouldDecreaseSellInAndIncreaseQuality()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0};
            var strategy = StrategyFactory.GetStrategy(item);
            strategy.UpdateQuality();

            Assert.Equal(item.SellIn, 1);
            Assert.Equal(item.Quality, 1);
            Assert.InRange(item.Quality, 0, 50);
        }

        [Fact]
        public void SulfurasDoesNotAlterSellInNorQuality()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
            var strategy = StrategyFactory.GetStrategy(item);
            strategy.UpdateQuality();

            Assert.Equal(item.SellIn, item.SellIn);
            Assert.Equal(item.Quality, item.Quality);
            Assert.Equal(item.Quality, 80);
        }

        [Fact]
        public void BackStagePassesShouldDecreaseSellInAndIncreaseQuality()
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            };
            var strategy = StrategyFactory.GetStrategy(item);
            strategy.UpdateQuality();

            Assert.Equal(item.SellIn, 14);
            Assert.Equal(item.Quality, 21);
            Assert.InRange(item.Quality, 0, 50);
        }

        [Fact]
        public void BackStagePassesShouldIncreaseQualityTwiceAsMuchWhenSellIn10OrLess()
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 20
            };
            var strategy = StrategyFactory.GetStrategy(item);
            strategy.UpdateQuality();

            Assert.Equal(item.SellIn, 9);
            Assert.Equal(item.Quality, 22);
            Assert.InRange(item.Quality, 0, 50);
        }

        [Fact]
        public void BackStagePassesShouldIncreaseQuality3TimesAsMuchWhenSellIn5OrLess()
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 20
            };
            var strategy = StrategyFactory.GetStrategy(item);
            strategy.UpdateQuality();

            Assert.Equal(item.SellIn, 4);
            Assert.Equal(item.Quality, 23);
            Assert.InRange(item.Quality, 0, 50);
        }

        [Fact]
        public void BackStagePassesShouldMakeQuality0WhenSellInOrLess()
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 0,
                Quality = 20
            };
            var strategy = StrategyFactory.GetStrategy(item);
            strategy.UpdateQuality();

            Assert.Equal(item.SellIn, -1);
            Assert.Equal(item.Quality, 0);
            Assert.InRange(item.Quality, 0, 50);
        }

        [Fact]
        public void ConjuredShouldDecreaseQualityTwiceAsFast()
        {
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 };
            var strategy = StrategyFactory.GetStrategy(item);
            strategy.UpdateQuality();

            Assert.Equal(item.SellIn, 2);
            Assert.Equal(item.Quality, 4);
            Assert.InRange(item.Quality, 0, 50);
        }
    }
}
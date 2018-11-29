using GildedRose.Console.Strategies;
using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public static class StrategyFactory
    {
        public static IUpdateQuality GetStrategy(Item item)
        {
            return Items[item.Name](item);
        }

        private static Dictionary<string, Func<Item, IUpdateQuality>> Items = new Dictionary<string, Func<Item, IUpdateQuality>>
        {
            { "+5 Dexterity Vest",  (item) => { return new DefaultStrategy(item); } },
            { "Aged Brie",  (item) => { return new AgedBrieStrategy(item); } },
            { "Elixir of the Mongoose",  (item) => { return new DefaultStrategy(item); } },
            { "Sulfuras, Hand of Ragnaros",  (item) => { return new SulfurasStrategy(item); } },
            { "Backstage passes to a TAFKAL80ETC concert",  (item) => { return new BackStagePassStrategy(item); } },
            { "Conjured Mana Cake",  (item) => { return new ConjuredStrategy(item); } }
        };
    }
}

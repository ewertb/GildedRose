using System.Collections.Generic;

namespace GildedRose.Console
{
    class Program
    {
        IList<IUpdateQuality> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<IUpdateQuality>
                                          {
                                              StrategyFactory.GetStrategy(new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}),
                                              StrategyFactory.GetStrategy(new Item {Name = "Aged Brie", SellIn = 2, Quality = 0}),
                                              StrategyFactory.GetStrategy(new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7}),
                                              StrategyFactory.GetStrategy(new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}),
                                              StrategyFactory.GetStrategy(new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  }),
                                              StrategyFactory.GetStrategy(new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6})
                                          }

                          };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Items[i].UpdateQuality();
            }
        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}

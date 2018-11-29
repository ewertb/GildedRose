namespace GildedRose.Console.Strategies
{
    public class BackStagePassStrategy : DefaultStrategy
    {
        public BackStagePassStrategy(Item item)
            : base(item)
        { }

        public override void IncreaseQuality()
        {
            if (base.CanIncreaseQuality())
            {
                if (item.SellIn < 0)
                {
                    item.Quality = 0;
                }
                else if (item.SellIn <= 5)
                {
                    item.Quality = item.Quality + 3;
                }
                else if (item.SellIn <= 10)
                {
                    item.Quality = item.Quality + 2;
                }
                else
                {
                    base.IncreaseQuality();
                }
            }
        }

        public override void UpdateQuality()
        {
            base.DecreaseSellIn();
            IncreaseQuality();
        }
    }
}

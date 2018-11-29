namespace GildedRose.Console.Strategies
{
    public class ConjuredStrategy : DefaultStrategy
    {
        public ConjuredStrategy(Item item)
            : base(item)
        { }

        public override void DecreaseQuality()
        {
            item.Quality = item.Quality - 2;
        }
    }
}

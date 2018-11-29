namespace GildedRose.Console.Strategies
{
    public class SulfurasStrategy : DefaultStrategy
    {
        public SulfurasStrategy(Item item)
            : base(item)
        {
            this.item = item;
        }

        public override bool CanDecreaseSellIn()
        {
            return false;
        }

        public override bool CanDecreaseQuality()
        {
            return false;
        }

        public override bool CanIncreaseQuality()
        {
            return false;
        }
    }
}

namespace GildedRose.Console
{
    public class AgedBrieStrategy: DefaultStrategy
    {
        public AgedBrieStrategy(Item item)
            : base(item)
        { }

        public override bool CanDecreaseQuality()
        {
            return false;
        }

        public override void UpdateQuality()
        {
            base.DecreaseSellIn();
            base.IncreaseQuality();
        }
    }
}

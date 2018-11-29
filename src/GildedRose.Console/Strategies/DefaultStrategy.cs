using GildedRose.Console.Interfaces;

namespace GildedRose.Console
{
    public class DefaultStrategy : IUpdateQuality, IIncreaseQuality, IDecreaseQuality, ICanDecreaseQuality, IDecreaseSellIn, ICanDecreaseSellIn, ICanIncreaseQuality
    {
        protected Item item;

        public DefaultStrategy(Item item)
        {
            this.item = item;
        }

        public virtual bool CanDecreaseQuality()
        {
            return item.Quality > 0;
        }

        public virtual bool CanDecreaseSellIn()
        {
            return true;
        }

        public virtual bool CanIncreaseQuality()
        {
            return item.Quality < 50;
        }

        public virtual void DecreaseQuality()
        {
            if (CanDecreaseQuality())
            {
                if (item.SellIn < 0)
                {
                    item.Quality = item.Quality - 2;
                }
                else
                {
                    item.Quality--;
                }
            }
        }

        public virtual void DecreaseSellIn()
        {
            if (CanDecreaseSellIn())
            {
                item.SellIn--;
            }
        }

        public virtual void IncreaseQuality()
        {
            if (CanIncreaseQuality())
            {
                item.Quality++;
            }
        }

        public virtual void UpdateQuality()
        {
            DecreaseSellIn();
            DecreaseQuality();
        }
    }
}

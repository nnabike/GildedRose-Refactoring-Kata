using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class BaseItem : Item
    {

        public int ModifyQuality(int quality, int amount)
        {
            var modifiedQuality = quality + (amount);
            return (modifiedQuality < 0) ? 0 : modifiedQuality > 50 ? 50 : modifiedQuality;

        }

        public int ReduceSellIn(int sellIn, int amount)
        {
            var modifiedSellIn = sellIn - (amount);
            return sellIn < 0 ? 0 : modifiedSellIn;
        }
    }
}

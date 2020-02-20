using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class AgedBrie : BaseItem, IUpdateable
    {
        public void RunUpdate()
        {
            var agedBrieZeroRule = new AgedBrieZeroRule();
            
            agedBrieZeroRule.SetSuccessor(new AgedBrieDefaultRule());

            var updateQualityBy = agedBrieZeroRule.Execute(SellIn, Quality);
            
            Quality = ModifyQuality(Quality, updateQualityBy);
            SellIn = ReduceSellIn(SellIn, 1);
        }


    }
}

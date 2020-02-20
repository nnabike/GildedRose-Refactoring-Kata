using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class RegularItem : BaseItem, IUpdateable
    {
        public void RunUpdate()
        {
            var regularItemZeroRule = new RegularItemZeroRule();
            var regularItemDefaultRule = new RegularItemDefaultRule();

            regularItemZeroRule.SetSuccessor(regularItemDefaultRule);

            int modifyQualityBy = regularItemZeroRule.Execute(SellIn, Quality);

            Quality = ModifyQuality(Quality, modifyQualityBy);
            SellIn = ReduceSellIn(SellIn, 1);

        }

    }
}

using System;

namespace csharp
{
    internal class ConcertPass : BaseItem, IUpdateable
    {
        public void RunUpdate()
        {
            var first = new ConcertPassGreaterThanTenRule();
            var second = new ConcertPassSixToTenRule();
            var third = new ConcertPassZeroToSixRule();
            var fourth = new ConcertPassZeroRule();

            first.SetSuccessor(second);
            second.SetSuccessor(third);
            third.SetSuccessor(fourth);

            int modifyQualityBy = first.Execute(SellIn, Quality);
            Quality = ModifyQuality(Quality, modifyQualityBy);

            SellIn = ReduceSellIn(SellIn, 1);
        }

    }
}
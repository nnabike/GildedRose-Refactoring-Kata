using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public abstract class Rules
    {
        private Rules _nextRule;

        public void SetSuccessor(Rules nextRule)
        {
            _nextRule = nextRule;
        }

        public virtual int Execute(int sellIn, int quality)
        {
            if (_nextRule != null)
            {
                return _nextRule.Execute(sellIn, quality);
            }
            return 0;
        }
    }

    public class ConcertPassGreaterThanTenRule : Rules
    {
        public override int Execute(int sellIn, int quality)
        {
            if (sellIn > 10)
            {
                return 1;
            }

            return base.Execute(sellIn, quality);
        }
    }

    public class ConcertPassSixToTenRule : Rules
    {
        public override int Execute(int sellIn, int quality)
        {
            if (sellIn <= 10 && sellIn >= 6)
            {
                return 2;
            }

            return base.Execute(sellIn, quality);
        }
    }

    public class ConcertPassZeroToSixRule : Rules
    {
        public override int Execute(int sellIn, int quality)
        {
            if (sellIn > 0 && sellIn < 6)
            {
                return 3;
            }

            return base.Execute(sellIn, quality);
        }
    }
    public class ConcertPassZeroRule : Rules
    {
        public override int Execute(int sellIn, int quality)
        {
            if (sellIn <= 0)
            {
                return -quality;
            }

            return base.Execute(sellIn, quality);
        }
    }

    public class RegularItemZeroRule : Rules
    {
        public override int Execute(int sellIn, int quality)
        {
            if (sellIn <= 0)
            {
                return -2;
            }
            return base.Execute(sellIn, quality);
        }

    }

    public class RegularItemDefaultRule : Rules
    {
        public override int Execute(int sellIn, int quality)
        {
            if (sellIn > 0)
            {
                return -1;
            }
            return base.Execute(sellIn, quality);
        }
    }

    public class AgedBrieZeroRule : Rules
    {
        public override int Execute(int sellIn, int quality)
        {
            if (sellIn <= 0)
            {
                return 2;
            }
            return base.Execute(sellIn, quality);
        }
    }

    public class AgedBrieDefaultRule : Rules
    {
        public override int Execute(int sellIn, int quality)
        {
            if (sellIn > 0)
            {
                return 1;
            }

            return base.Execute(sellIn, quality);
        }
    }
}

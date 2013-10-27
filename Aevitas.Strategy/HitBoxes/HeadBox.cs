using System;

namespace Aevitas.Strategy.HitBoxes
{
    public class HeadBox : StrategyBase
    {
        public override int CalculateDamage(int hits)
        {
            Console.WriteLine("{0} hit(s) taken in the Head!", hits);
            return 100 * hits;
        }
    }
}

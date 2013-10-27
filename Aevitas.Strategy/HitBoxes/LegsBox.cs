using System;

namespace Aevitas.Strategy.HitBoxes
{
    public class LegsBox : StrategyBase
    {
        public override int CalculateDamage(int hits)
        {
            Console.WriteLine("{0} hit(s) taken in the Leg!", hits);
            return 10 * hits;
        }
    }
}

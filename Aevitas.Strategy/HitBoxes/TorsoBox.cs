using System;

namespace Aevitas.Strategy.HitBoxes
{
    public class TorsoBox : StrategyBase
    {
        public override int CalculateDamage(int hits)
        {
            Console.WriteLine("{0} hit(s) taken in the Torso!", hits);
            return 20 * hits;
        }
    }
}

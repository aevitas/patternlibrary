using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aevitas.Strategy.HitBoxes
{
    public class ArmsBox : StrategyBase
    {
        public override int CalculateDamage(int hits)
        {
            Console.WriteLine("{0} hit(s) taken in the Arm!", hits);
            return 10 * hits;
        }
    }
}

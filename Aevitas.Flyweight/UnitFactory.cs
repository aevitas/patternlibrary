using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aevitas.Flyweight
{
    public static class UnitFactory
    {
        private static readonly Dictionary<UnitType, Unit> Units = new Dictionary<UnitType, Unit>();

        public static Unit CreateUnit(UnitType type)
        {
            if (Units.ContainsKey(type))
                return Units[type];

            Unit unit;

            switch (type)
            {
                case UnitType.Commando:
                    unit = new Commando()
                    {
                        Armour = 10,
                        Health = 100,
                        Name = "Commando",
                        Power = 50,
                        Range = 5
                    };
                    break;
                case UnitType.Infanty:
                    unit = new Infantry()
                    {
                        Armour = 5,
                        Health = 80,
                        Name = "Infantry",
                        Power = 30,
                        Range = 5
                    };
                    break;
                case UnitType.Tank:
                    unit = new Tank()
                    {
                        Armour = 250,
                        Health = 1500,
                        Name = "Tank",
                        Power = 150,
                        Range = 600
                    };
                    break;
                default:
                    throw new ArgumentException();
            }

            Units.Add(type, unit);
            return unit;
        }
    }

    public enum UnitType
    {
        Infanty,
        Tank,
        Commando
    }
}

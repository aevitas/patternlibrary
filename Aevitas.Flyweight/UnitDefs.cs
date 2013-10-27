using System;

namespace Aevitas.Flyweight
{
    public class Tank : Unit
    {
    }

    public class Commando : Unit
    {
    }

    public class Infantry : Unit
    {
    }

    public class Target
    {
        public Unit Unit { get; set; }
        public Guid Guid { get; set; }
    }
}

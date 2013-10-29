using System;

namespace Aevitas.Prototype
{
    public class BankAccount : IPrototype
    {
        public decimal Amount { get; set; }
        public string Owner { get; set; }
        public DateTime CreationTime { get; set; }

        public IPrototype Clone()
        {
            return (IPrototype) MemberwiseClone();
        }
    }
}

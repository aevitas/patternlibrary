using System;

namespace Aevitas.Decorator
{
    public class GreenWritingDecorator : Decorator
    {
        public GreenWritingDecorator(IComponent decorated) : base(decorated)
        {}

        public new void Operation()
        {
            var oldCol = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;

            base.Operation();

            Console.ForegroundColor = oldCol;
        }
    }
}

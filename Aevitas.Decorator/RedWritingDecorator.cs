using System;

namespace Aevitas.Decorator
{
    public class RedWritingDecorator : Decorator
    {
        public RedWritingDecorator(IComponent decorated) : base(decorated)
        {
        }

        public new void Operation()
        {
            var oldCol = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            base.Operation();

            Console.ForegroundColor = oldCol;
        }
    }
}

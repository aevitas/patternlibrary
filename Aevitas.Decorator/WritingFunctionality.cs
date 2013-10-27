using System;

namespace Aevitas.Decorator
{
    public class WritingFunctionality : IComponent
    {
        public void Operation()
        {
            Console.WriteLine("Console writing functionality, awesome!");
        }
    }
}

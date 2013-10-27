using System;

namespace Aevitas.Adapter
{
    public class Client
    {
        private static ITarget Target;

        public Client(ITarget target)
        {
            Target = target;
        }

        public void Calculate()
        {
            Console.WriteLine(Target.Calculate());
        }

        public void Report()
        {
            Target.Report();
        }
    }
}

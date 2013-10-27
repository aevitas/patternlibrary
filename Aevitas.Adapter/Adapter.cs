using System;

namespace Aevitas.Adapter
{
    public class Adapter : ITarget
    {
        private readonly Adaptee _ref;
        private readonly int _a, _b;

        public Adapter(Adaptee adaptee, int a, int b)
        {
            _ref = adaptee;
            _a = a;
            _b = b;
        }

        public double Calculate()
        {
            if (_ref != null)
                return _ref.CalculateSomething(_a, _b);

            throw new Exception("Adapter needs a valid Adaptee reference to do stuff!");
        }

        public void Report()
        {
            if (_ref != null)
                _ref.ReportFindings();
        }
    }
}

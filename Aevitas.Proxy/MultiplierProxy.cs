namespace Aevitas.Proxy
{
    public class MultiplierProxy : IProxyfiable<int>
    {
        private Multiplier _instance;
        private int _cachedValue = int.MinValue;

        public MultiplierProxy()
        {
            _instance = new Multiplier();
        }

        public int Run(params object[] args)
        {
            if (_cachedValue != int.MinValue)
                return _cachedValue;

            _cachedValue = _instance.Run(args);

            return Run();
        }

        public int Multiply(int left, int right)
        {
            return _instance != null ? Run(left, right) : 0;
        }
    }
}

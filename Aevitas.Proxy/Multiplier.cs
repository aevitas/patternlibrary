using System;
using System.Threading;

namespace Aevitas.Proxy
{
    internal class Multiplier : IProxyfiable<int>
    {
        public int Run(params object[] args)
        {
            int left, right;

            if (args.Length < 2 || !int.TryParse(args[0].ToString(), out left) || !int.TryParse(args[1].ToString(), out right))
                throw new Exception("Couldn't parse arguments for Multiplier, or less than 2 arguments were passed. Fix it!");

            int ret = left*right;

            // Sleeping to simulate resource intensiveness!
            Thread.Sleep(5000);

            return ret;
        }
    }
}

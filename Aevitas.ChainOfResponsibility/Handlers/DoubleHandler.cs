using System;

namespace Aevitas.ChainOfResponsibility.Handlers
{
    public class DoubleHandler : HandlerBase
    {
        public override void Handle(params object[] args)
        {
            RequestType reqType;
            if (!Enum.TryParse(args[0].ToString(), out reqType) || reqType != RequestType.Double)
            {
                // Lata.
                RequestManager.Continue(args);
                return;
            }

            Console.WriteLine("Integer handler handled: {0}", (double)args[1]);
        }
    }
}

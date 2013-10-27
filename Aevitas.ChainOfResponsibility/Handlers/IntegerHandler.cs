using System;

namespace Aevitas.ChainOfResponsibility.Handlers
{
    public class IntegerHandler : HandlerBase
    {
        public override void Handle(params object[] args)
        {
            RequestType reqType;
            if (!Enum.TryParse(args[0].ToString(), out reqType) || reqType != RequestType.Integer)
            {
                // Lata.
                RequestManager.Continue(args);
                return;
            }

            Console.WriteLine("Integer handler handled: {0}", (int) args[1]);
        }
    }
}

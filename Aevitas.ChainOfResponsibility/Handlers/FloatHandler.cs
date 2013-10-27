using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aevitas.ChainOfResponsibility.Handlers
{
    public class FloatHandler : HandlerBase
    {
        public override void Handle(params object[] args)
        {
            RequestType reqType;
            if (!Enum.TryParse(args[0].ToString(), out reqType) || reqType != RequestType.Float)
            {
                // Lata.
                RequestManager.Continue(args);
                return;
            }

            Console.WriteLine("Float handler handled: {0}", (float)args[1]);
        }
    }
}

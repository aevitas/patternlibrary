using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aevitas.Bridge.MessageProviders
{
    public class RedMessageProvider : MessageProvider
    {
        public override void Send(string format, params object[] args)
        {

            var oldCol = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(format, args);
            Console.ForegroundColor = oldCol;
        }
    }
}

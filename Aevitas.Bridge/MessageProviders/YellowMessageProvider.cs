using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aevitas.Bridge.MessageProviders
{
    public class YellowMessageProvider : MessageProvider
    {
        public override void Send(string format, params object[] args)
        {
            var oldCol = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(format, args);
            Console.ForegroundColor = oldCol;
        }
    }
}

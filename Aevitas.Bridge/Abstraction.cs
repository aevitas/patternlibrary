using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aevitas.Bridge.MessageProviders;

namespace Aevitas.Bridge
{
    public static class Abstraction
    {
        public static MessageProvider CurrentProvider { get; set; }

        static Abstraction()
        {
            CurrentProvider = new GreenMessageProvider();
        }

        public static void WriteMessage(string format, params object[] args)
        {
            CurrentProvider.Send(format, args);
        }
    }
}

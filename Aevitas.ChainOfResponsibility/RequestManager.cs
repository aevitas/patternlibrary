using System;
using System.Collections.Generic;
using System.Linq;

namespace Aevitas.ChainOfResponsibility
{
    /// <summary>
    /// This is the "client" in the original pattern. Only difference is this guy actually manages the chain
    /// and not the individual requests themselves.
    /// </summary>
    public static class RequestManager
    {
        // Could use a CircularQueue here as well, but resetting it every time? Meh.
        public static List<HandlerBase> Handlers = new List<HandlerBase>();

        /// <summary>
        /// Sends the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        public static void Send<T>(RequestType type, T value)
        {
            if (Handlers != null && Handlers.Count > 0)
            {
                // Make sure we reset the indexer back to the start of the chain.
                _idx = 0;
                Handlers.First().Handle(type, value);
            }
        }

        private static int _idx;
        public static void Continue(params object[] args)
        {
            if (Handlers.Count > ++_idx)
            {
                Handlers[_idx].Handle(args);
            }
            else
            {
                Console.WriteLine("RequestManager.Continue(): Reached end of chain!");
            }
        }
    }
}

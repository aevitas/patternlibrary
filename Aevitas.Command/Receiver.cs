using System;

namespace Aevitas.Command
{
    /// <summary>
    /// 
    /// </summary>
    public class Receiver
    {
        /// <summary>
        /// Logs the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogMessage(string message)
        {
            Console.WriteLine("Receiver executing LogMessage: {0}", message);
        }
    }
}

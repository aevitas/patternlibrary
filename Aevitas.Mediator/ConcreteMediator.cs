using System.Collections.Generic;

namespace Aevitas.Mediator
{
    /// <summary>
    /// An actual mediator.
    /// </summary>
    public class ConcreteMediator : MediatorBase
    {
        public ConcreteMediator()
        {
            Colleagues = new List<ColleagueBase>();
        }

        /// <summary>
        /// Sends the specified message to all colleagues apart from the caller.
        /// </summary>
        /// <param name="caller">The caller.</param>
        /// <param name="message">The message.</param>
        public override void SendMessage(ColleagueBase caller, string message)
        {
            // Can't really forward stuff if there's no colleagues.
            if (Colleagues.Count == 0)
                return;

            foreach (var c in Colleagues)
            {
                // We don't have to send the message back to the caller.
                if (c == caller)
                    continue;

                c.Receive(this, message);
            }
        }
    }
}

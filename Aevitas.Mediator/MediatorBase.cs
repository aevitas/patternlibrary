using System.Collections.Generic;

namespace Aevitas.Mediator
{
    /// <summary>
    /// Base class for Mediators.
    /// </summary>
    public abstract class MediatorBase
    {
        /// <summary>
        /// List of references to colleagues this mediator services.
        /// </summary>
        protected List<ColleagueBase> Colleagues { get; set; }

        public abstract void SendMessage(ColleagueBase caller, string message);

        /// <summary>
        /// Registers the colleague with the mediator.
        /// </summary>
        /// <param name="colleague">The colleague.</param>
        public void RegisterColleague(ColleagueBase colleague)
        {
            if (Colleagues == null || Colleagues.Contains(colleague))
                return;

            Colleagues.Add(colleague);
        }
    }
}

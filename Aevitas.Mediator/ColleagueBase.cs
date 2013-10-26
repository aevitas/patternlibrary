namespace Aevitas.Mediator
{
    /// <summary>
    /// Base class for all colleagues.
    /// </summary>
    public abstract class ColleagueBase
    {
        /// <summary>
        /// Holds a reference to the mediator this colleague uses.
        /// </summary>
        protected MediatorBase Mediator { get; set; }

        protected string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColleagueBase" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="name">The name.</param>
        protected ColleagueBase(MediatorBase mediator, string name)
        {
            Mediator = mediator;
            Name = name;

            // Register ourselves with the specified mediator so it holds a reference to us.
            Mediator.RegisterColleague(this);
        }

        public abstract void Receive(MediatorBase caller, string message);
        public abstract void Send(string message);
    }
}

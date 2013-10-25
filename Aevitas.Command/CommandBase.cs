namespace Aevitas.Command
{
    public abstract class CommandBase
    {
        /// <summary>
        /// Executes this Command.
        /// </summary>
        public abstract void Execute();

        protected Receiver Handler { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBase"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        protected CommandBase(Receiver handler)
        {
            Handler = handler;
        }
    }
}

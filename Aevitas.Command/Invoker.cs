namespace Aevitas.Command
{
    public sealed class Invoker
    {
        /// <summary>
        /// Gets the command to be invoked.
        /// </summary>
        public CommandBase Command { get; private set; }

        public Invoker(CommandBase command)
        {
            Command = command;
        }

        public void Invoke()
        {
            if (Command != null)
                Command.Execute();
        }
    }
}

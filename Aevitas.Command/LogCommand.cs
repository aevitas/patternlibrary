namespace Aevitas.Command
{
    public class LogCommand : CommandBase
    {
        private string FormattedArgs { get; set; }

        public LogCommand(Receiver handler, string format, params object[] args) : base(handler)
        {
            FormattedArgs =  string.Format(format, args);
        }

        public override void Execute()
        {
            Handler.LogMessage(FormattedArgs);
        }
    }
}

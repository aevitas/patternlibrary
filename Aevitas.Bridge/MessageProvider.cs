namespace Aevitas.Bridge
{
    public abstract class MessageProvider
    {
        public abstract void Send(string format, params object[] args);
    }
}

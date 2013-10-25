using System.Diagnostics;

namespace Aevitas.Command
{
    public static class Client
    {
        public static void Run()
        {
            var stackFrame = new StackTrace().GetFrame(0);

            var handler = new Receiver();
            var cmd = new LogCommand(handler, "This is passed from {0}", stackFrame);
            var invoker = new Invoker(cmd);

            invoker.Invoke();
        }
    }
}

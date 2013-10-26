using System;

namespace Aevitas.Mediator.Colleagues
{
    public class ColleagueSender : ColleagueBase
    {
        public ColleagueSender(MediatorBase mediator) : base(mediator, "Sending Colleague")
        {
        }

        public override void Receive(MediatorBase caller, string message)
        {
            Console.WriteLine("{0} received message: {1} - (sender shouldn't receive anything?)", Name, message);
        }

        public override void Send(string message)
        {
            Mediator.SendMessage(this, message);
        }
    }
}

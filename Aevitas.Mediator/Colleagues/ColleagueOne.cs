using System;

namespace Aevitas.Mediator.Colleagues
{
    public class ColleagueOne : ColleagueBase
    {
        public ColleagueOne(MediatorBase mediator) : base(mediator, "Colleague One")
        {
        }

        public override void Receive(MediatorBase caller, string message)
        {
            Console.WriteLine("{0} received message: {1}", Name, message);
        }

        public override void Send(string message)
        {
            Mediator.SendMessage(this, message);
        }
    }
}

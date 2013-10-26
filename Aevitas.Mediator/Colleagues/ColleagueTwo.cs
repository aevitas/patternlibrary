using System;

namespace Aevitas.Mediator.Colleagues
{
    public class ColleagueTwo : ColleagueBase
    {
        public ColleagueTwo(MediatorBase mediator) : base(mediator, "Colleague Two")
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

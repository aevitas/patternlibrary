using System;

namespace Aevitas.State.States
{
    public class LessThanTen : State
    {
        public override void Handle(Context ctx, params object[] args)
        {
            int num;
            if (int.TryParse(args[0].ToString(), out num) && num > 10)
                ctx.CurrentState = new GreaterThanTen();

            Console.WriteLine("Less than 10 state is currently running.");

            ctx.CurrentState = new IdleState();
        }
    }
}

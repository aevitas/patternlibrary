using System;

namespace Aevitas.State.States
{
    public class GreaterThanTen : State
    {
        public override void Handle(Context ctx, params object[] args)
        {
            int num;
            if (int.TryParse(args[0].ToString(), out num) && num < 10)
                ctx.CurrentState = new LessThanTen();

            Console.WriteLine("Greater than ten state is currently running.");

            ctx.CurrentState = new IdleState();
        }
    }
}

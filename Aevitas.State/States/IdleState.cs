using System;

namespace Aevitas.State.States
{
    // This state is basically here to bandaid a shortcoming in the pattern; the inability to
    // determine what state should be run from the context, rather than the states setting the next
    // one themselves. This state basically does that for the context.

    // This implementation of state is completely ass backwards and could really be a lot better than it is..
    // unfortunately, we're sticking to the patterns as they are defined by the authors.
    public class IdleState : State
    {
        public override void Handle(Context ctx, params object[] args)
        {
            int i;

            if (!int.TryParse(args[0].ToString(), out i))
            {
                Console.WriteLine("{0} is not an integer; enter a number you muppet!", args[0]);
                return;
            }

            if (i > 10)
                ctx.CurrentState = new GreaterThanTen();
            else
                ctx.CurrentState = new LessThanTen();

            ctx.Pulse(args);
        }
    }
}


using System;
using System.Threading;
using Aevitas.ChainOfResponsibility.Handlers;
using Aevitas.Command;
using Aevitas.Composite;
using Aevitas.Interpreter;
using Aevitas.Mediator;
using Aevitas.Mediator.Colleagues;
using Aevitas.MementoPattern;
using Aevitas.Observer;
using Aevitas.State.States;
using Aevitas.ChainOfResponsibility;
using Aevitas.Strategy;
using Aevitas.Strategy.HitBoxes;
using Action = Aevitas.Composite.Action;

namespace PatternTester
{
    class Program
    {
#if INTERPRETER
        private static readonly TerminalExpression<int> Left = new TerminalExpression<int>(10);
        private static readonly TerminalExpression<int> Right = new TerminalExpression<int>(8);

        private static readonly SubtractionExpression Subtract = new SubtractionExpression(Left, Right);
        private static readonly MultiplyExpression Multiply = new MultiplyExpression(Left, Right);
        private static readonly AdditionExpression Add = new AdditionExpression(Left, Right);

        // Dividing requires a new set of expressions because of the different data type, and you can't cast generics... >_>
        private static readonly TerminalExpression<float> LeftDivide = new TerminalExpression<float>(10);
        private static readonly TerminalExpression<float> RightDivide = new TerminalExpression<float>(8); 

        private static readonly DivideExpression Divide = new DivideExpression(LeftDivide, RightDivide);

        static void Main(string[] args)
        {
            Console.WriteLine("Left operand: {0} - Right operand: {1}", Left.Value, Right.Value);

            Console.WriteLine("Subtract: " + Subtract.Interpret());
            Console.WriteLine("Multiply: " + Multiply.Interpret());
            Console.WriteLine("Addition: " + Add.Interpret());
            Console.WriteLine("Division: " + Divide.Interpret());

            Console.WriteLine();

            Console.Read();
        }
#endif

#if COMMAND

        static void Main(string[] args)
        {
            Client.Run();

            Console.ReadLine();
        }

#endif

#if OBSERVER

        static void Main(string[] argsv)
        {
            var subject = new ConcreteSubject("Cooking is fun!");
            var observer = new CookingBlog(subject);
            var observer2 = new CookingBlog(subject);

            subject.SetState("Cooking sucks!");
            subject.SetState("Smoking marihuana is good for your health!");

            Console.Read();
        }

#endif

#if MEDIATOR

        static void Main(string[] argsv)
        {
            var mediator = new ConcreteMediator();

            var colleagueOne = new ColleagueOne(mediator);
            var colleagueTwo = new ColleagueTwo(mediator);

            var sendingColleague = new ColleagueSender(mediator);

            sendingColleague.Send("Foobar!");

            Console.Read();
        }

#endif

#if STATE

        static void Main(string[] argsv)
        {
            var number = 0;

            var ctx = new Aevitas.State.Context(new IdleState());

            while (true)
            {
                Console.WriteLine("Enter a number and hit enter:");
                var n = Console.ReadLine();

                ctx.Pulse(n);
            }
        }

#endif

#if MEMENTO
        static void Main(string[] argsv)
        {
            var careTaker = new Caretaker();

            var timeWarden = new TimeWarden();

            // Add a memento of this guy's current state.
            Console.WriteLine("Changing state of TimeWarden object and creating three mementos..\n");
            timeWarden.CurrentState = Guid.NewGuid().ToString().Trim('-');
            Console.WriteLine("State: {0}", timeWarden.CurrentState);
            careTaker.AddMemento(timeWarden.GetMemento());
            Thread.Sleep(500);

            timeWarden.CurrentState = Guid.NewGuid().ToString().Trim('-');
            Console.WriteLine("State: {0}", timeWarden.CurrentState);
            careTaker.AddMemento(timeWarden.GetMemento());

            Thread.Sleep(500);

            timeWarden.CurrentState = Guid.NewGuid().ToString().Trim('-');
            Console.WriteLine("State: {0}", timeWarden.CurrentState);
            careTaker.AddMemento(timeWarden.GetMemento());

            Console.WriteLine("\nDone. Retrieving mementos in 1 second (reverse order)..\n\n");
            
            Thread.Sleep(1000);

            timeWarden.SetMemento(careTaker.NextMemento);
            Console.WriteLine(timeWarden);

            timeWarden.SetMemento(careTaker.NextMemento);
            Console.WriteLine(timeWarden);

            timeWarden.SetMemento(careTaker.NextMemento);
            Console.WriteLine(timeWarden);

            Console.WriteLine("\n\nDone retrieving mementos.. Caretaker out!");

            Console.ReadLine();
        }
#endif

#if COMPOSITE
        static void Main(string[] argsv)
        {
            // Since the API of our composite code is constructor based, you get a pretty simple overview of the actual "tree".
            var tree = new Composite(new Action(() => Console.WriteLine("First leaf of the tree")),
                new Action(() => Console.ForegroundColor = ConsoleColor.Yellow),
                new Action(() => Console.WriteLine("Third leaf of the tree")),
                new Action(() => Console.ForegroundColor = ConsoleColor.Magenta),
                new Action(() => Console.WriteLine("Fifth lead of the tree")));

            Console.WriteLine("Press enter to actually execute the tree.");
            Console.ReadLine();

            tree.Execute();

            Console.ReadLine();
        }
#endif

#if CHAINOFRESPONS
        static void Main(string[] argsv)
        {
            var doubleHandler = new DoubleHandler();
            var intHandler = new IntegerHandler();
            var floatHandler = new FloatHandler();

            RequestManager.Send<uint>(RequestType.UnsignedInteger, 5);

            Console.ReadLine();
        }
#endif

#if STRATEGY
        static void Main(string[] argsv)
        {
            // Let's construct our body parts. Yay!
            var head = new HeadBox();
            var legs = new LegsBox();
            var arms = new ArmsBox();
            var torso = new TorsoBox();

            // Now let's take a couple of hits.
            var player = new Player();

            player.TakeHit(legs, 1); // One hit in the leg.
            player.TakeHit(torso, 2); // Two in the torso.
            player.TakeHit(arms, 1); // And one in the arm.

            // So that should be 10+20+20+10=60 damage, 40 health left:
            Console.WriteLine("Remaining health: {0}", player.Health);

            Console.ReadLine();

            // Let's take one in the head for laughs.
            player.TakeHit(head, 1);
            Console.WriteLine("Remaining health: {0}", player.Health);

            Console.ReadLine();
        }
#endif

    }
}

﻿
using System;
using System.Runtime.InteropServices;
using System.Threading;
using Aevitas.Adapter;
using Aevitas.Bridge;
using Aevitas.Bridge.MessageProviders;
using Aevitas.Builder;
using Aevitas.ChainOfResponsibility.Handlers;
using Aevitas.Command;
using Aevitas.Composite;
using Aevitas.Decorator;
using Aevitas.Flyweight;
using Aevitas.Interpreter;
using Aevitas.Mediator;
using Aevitas.Mediator.Colleagues;
using Aevitas.MementoPattern;
using Aevitas.Observer;
using Aevitas.Proxy;
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

#if BRIDGE
        static void Main(string[] argsv)
        {
            var red = new RedMessageProvider();
            var yellow = new YellowMessageProvider();
            var green = new GreenMessageProvider();

            Abstraction.WriteMessage("This one should be written by the default green provider.");
            Abstraction.CurrentProvider = yellow;
            Abstraction.WriteMessage("This one should be handled by the yellow one.");
            Abstraction.CurrentProvider = red;
            Abstraction.WriteMessage("And this one should be done by the red one.");
            Abstraction.CurrentProvider = green;
            Abstraction.WriteMessage("And green again!");

            Console.ReadLine();
        }
#endif

#if DECORATOR
        static void Main(string[] argsv)
        {
            var write = new WritingFunctionality();
            var green = new GreenWritingDecorator(write);
            var red = new RedWritingDecorator(write);

            write.Operation();
            green.Operation();
            red.Operation();

            Console.ReadLine();
        }
#endif

#if PROXY
        static void Main(string[] argsv)
        {
            Console.WriteLine("First calculation will take 5 seconds, the other 9 will come from the proxy caching it, and will be near-instant.");

            var proxy = new MultiplierProxy();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(proxy.Multiply(5, 5));
            }

            Console.ReadLine();
        }
#endif

#if ADAPTER
        static void Main(string[] argsv)
        {
            var adaptee = new Adaptee();
            var adapter = new Adapter(adaptee, 15, 67);
            var client = new Aevitas.Adapter.Client(adapter);

            client.Calculate();

            Console.WriteLine("\n\n");

            client.Report();

            Console.ReadLine();
        }
#endif

#if FLYWEIGHT
        static void Main(string[] argsv)
        {
            var target = new Target
            {
                Unit = UnitFactory.CreateUnit(UnitType.Tank),
                Guid = Guid.NewGuid()
            };

            var otherTarget = new Target
            {
                Unit = UnitFactory.CreateUnit(UnitType.Tank),
                Guid = Guid.NewGuid()
            };

            bool b = otherTarget.Unit == target.Unit;
            int fp = target.Unit.Power;

            Console.WriteLine("Equals: {0}", b);
            Console.WriteLine("Power: {0}", fp);

            target.Unit.Power = 12;

            Console.WriteLine("Still equal: {0}", target.Unit == otherTarget.Unit);

            Console.ReadLine();
        }
#endif

#if BUILDER
        static void Main(string[] argsv)
        {
            var breakfastBuilder = new BreakfastMealBuilder();
            var lunchBuilder = new LunchMealBuilder();
            var munchBuilder = new MunchMealBuilder();

            var breakfast = Orders.MakeMeal(breakfastBuilder);
            var lunch = Orders.MakeMeal(lunchBuilder);
            var munch = Orders.MakeMeal(munchBuilder);

            Console.WriteLine(breakfast);
            Console.WriteLine(lunch);
            Console.WriteLine(munch);

            Console.WriteLine();

            Console.ReadLine();
        }
#endif

    }
}

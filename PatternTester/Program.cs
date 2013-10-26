
using System;
using Aevitas.Command;
using Aevitas.Interpreter;
using Aevitas.Mediator;
using Aevitas.Mediator.Colleagues;
using Aevitas.Observer;

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
    }
}

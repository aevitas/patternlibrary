using System.Linq;

namespace Aevitas.Interpreter
{
    /// <summary>
    /// A simple addition expression.
    /// </summary>
    public class AdditionExpression : NonTerminalExpression<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionExpression"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        public AdditionExpression(TerminalExpression<int> left, TerminalExpression<int> right) : base(left, right)
        {}

        public override int Interpret(Context ctx = null)
        {
            // Really shouldn't be using first and last here, but whatever for now.
            return Addition(Expressions.First().Value, Expressions.Last().Value);
        }

        private static int Addition(int left, int right)
        {
            return left + right;
        }
    }
}

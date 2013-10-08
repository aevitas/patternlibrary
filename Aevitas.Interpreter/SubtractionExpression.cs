using System.Linq;

namespace Aevitas.Interpreter
{
    /// <summary>
    /// A simple subtraction expression.
    /// </summary>
    public class SubtractionExpression : NonTerminalExpression<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubtractionExpression"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        public SubtractionExpression(TerminalExpression<int> left, TerminalExpression<int> right) : base(left, right)
        {}

        public override int Interpret(Context ctx = null)
        {
            // Again, First and Last are bad - but in this specific case there'll only ever be two objects in the Expressions list.
            return Subtract(Expressions.First().Value, Expressions.Last().Value);
        }

        private static int Subtract(int left, int right)
        {
            return left - right;
        }
    }
}

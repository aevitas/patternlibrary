using System.Linq;

namespace Aevitas.Interpreter
{
    /// <summary>
    /// Simple multiply expression
    /// </summary>
    public class MultiplyExpression : NonTerminalExpression<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiplyExpression"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        public MultiplyExpression(TerminalExpression<int> left, TerminalExpression<int> right) : base(left, right)
        {
        }

        /// <summary>
        /// Interprets the specified CTX.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        /// <returns></returns>
        public override int Interpret(Context ctx = null)
        {
            return Multiply(Expressions.First().Value, Expressions.Last().Value);
        }

        /// <summary>
        /// Multiplies the specified left.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        private int Multiply(int left, int right)
        {
            return left*right;
        }
    }
}

using System;
using System.Linq;

namespace Aevitas.Interpreter
{
    /// <summary>
    /// Simple divide expression.
    /// </summary>
    public class DivideExpression : NonTerminalExpression<float>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DivideExpression" /> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        public DivideExpression(TerminalExpression<float> left, TerminalExpression<float> right) : base(left, right)
        {
        }

        /// <summary>
        /// Interprets the specified CTX.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        /// <returns></returns>
        public override float Interpret(Context ctx = null)
        {
            return Divide(Expressions.First().Value, Expressions.Last().Value);
        }

        /// <summary>
        /// Divides the specified left.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        /// <exception cref="System.DivideByZeroException"></exception>
        public float Divide(float left, float right)
        {
            if (Math.Abs(right) < 0)
                throw new DivideByZeroException();

            return left/right;
        }
    }
}

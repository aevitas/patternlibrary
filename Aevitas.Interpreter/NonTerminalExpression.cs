using System.Collections.Generic;

namespace Aevitas.Interpreter
{
    public class NonTerminalExpression<T> : Expression<T>
    {
        public List<TerminalExpression<T>> Expressions { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NonTerminalExpression" /> class.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public NonTerminalExpression(params TerminalExpression<T>[] args)
        {
            Expressions = new List<TerminalExpression<T>>();

            foreach (var e in args)
                Expressions.Add(e);
        }

        /// <summary>
        /// Interprets this NonTerminalExpression.
        /// </summary>
        /// <param name="ctx"></param>
        public override T Interpret(Context ctx = null)
        {
            foreach (var e in Expressions)
                e.Interpret(ctx);

            return default(T);
        }
    }
}

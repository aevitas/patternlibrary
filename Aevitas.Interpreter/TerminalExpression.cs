using System;

namespace Aevitas.Interpreter
{
    public class TerminalExpression<T> : Expression<T>
    {
        private readonly Action _executor;
        public T Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TerminalExpression{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="action">Optional delegate for executing whatever code when this expression is interpeted.</param>
        public TerminalExpression(T value, Action action = null)
        {
            Value = value;
            _executor = action;
        }

        public override T Interpret(Context ctx = null)
        {
            if (_executor != null)
                _executor();

            // Anything inheriting from TerminalExpression will return before the base returns anyway. (I think)
            return default(T);
        }
    }
}

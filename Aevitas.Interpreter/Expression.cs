namespace Aevitas.Interpreter
{
    /// <summary>
    /// Provides the base "Expression" for the interpreter pattern; to be implemented by a TerminalExpression or a NonTerminalExpression.
    /// </summary>
    public abstract class Expression<T>
    {
        /// <summary>
        /// Interprets this Expression.
        /// </summary>
        public abstract T Interpret(Context ctx = null);
    }

    /// <summary>
    /// A context in which the interpreter is ran.
    /// </summary>
    public class Context
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Context"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Context(string name)
        {
            Name = name;
        }
    }
}

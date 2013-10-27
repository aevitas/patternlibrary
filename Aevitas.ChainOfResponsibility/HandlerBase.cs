namespace Aevitas.ChainOfResponsibility
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class HandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HandlerBase"/> class.
        /// </summary>
        protected HandlerBase()
        {
            RequestManager.Handlers.Add(this);
        }

        /// <summary>
        /// Handles the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public abstract void Handle(params object[] args);
    }
}

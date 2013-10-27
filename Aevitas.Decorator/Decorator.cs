namespace Aevitas.Decorator
{
    public abstract class Decorator : IComponent
    {
        private IComponent Decorated { get; set; }

        protected Decorator(IComponent decorated)
        {
            Decorated = decorated;
        }

        public void Operation()
        {
            Decorated.Operation();
        }
    }
}

namespace Aevitas.State
{
    public abstract class State
    {
        public abstract void Handle(Context ctx, params object[] args);
    }
}

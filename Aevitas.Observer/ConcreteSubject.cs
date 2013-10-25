namespace Aevitas.Observer
{
    // ConcreteSubject classes must be abstract as to prevent loads of trouble with virtual member
    // usages in the ctor.
    public sealed class ConcreteSubject : SubjectBase
    {
        public ConcreteSubject(string initialState) : base()
        {
            State = initialState;
        }

        public override string GetState()
        {
            return State;
        }

        public override string State
        {
            get; set;
        }

        public void SetState(string newState)
        {
            State = newState;
            Notify();
        }
    }
}

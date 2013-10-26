using System;

namespace Aevitas.MementoPattern
{
    /// <summary>
    /// This guy keeps close track of the time. He knows what time it is. 
    /// </summary>
    public struct TimeWarden
    {
        public string CurrentState;

        public Memento GetMemento()
        {
            // Really?
            return new Memento(this);
        }

        public void SetMemento(Memento memento)
        {
            CurrentState = memento.AsType<TimeWarden>().CurrentState;
        }

        public override string ToString()
        {
            return string.Format("State: {0}", CurrentState);
        }
    }
}

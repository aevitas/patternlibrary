using System;
using Aevitas.State.States;

namespace Aevitas.State
{
    /// <summary>
    /// The actual "manager" of our state machine; the so-called context.
    /// </summary>
    public class Context
    {
        /// <summary>
        /// The current state.
        /// </summary>
        public State CurrentState { get; set; }

        /// <summary>
        /// Creates a Context around the specified state.
        /// </summary>
        /// <param name="initialState">The initial state.</param>
        public Context(State initialState)
        {
            CurrentState = initialState;
        }

        public void Pulse(params object[] args)
        {
            if (CurrentState != null)
                CurrentState.Handle(this, args);
        }
    }
}

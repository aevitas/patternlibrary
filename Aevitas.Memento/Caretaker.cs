using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aevitas.MementoPattern
{
    public class Caretaker
    {
        private readonly Stack<Memento> StoredMementos = new Stack<Memento>();

        /// <summary>
        /// Adds the memento.
        /// </summary>
        /// <param name="memento">The memento.</param>
        public void AddMemento(Memento memento)
        {
            StoredMementos.Push(memento);
        }

        /// <summary>
        /// Gets the next memento.
        /// </summary>
        /// <value>
        /// The next memento.
        /// </value>
        public Memento NextMemento
        {
            get { return StoredMementos.Pop(); }
        }

        public void DebugDump()
        {
            foreach (var m in StoredMementos)
                Console.WriteLine(m.AsType<TimeWarden>().CurrentState);
        }
    }
}

using System.Collections.Generic;
using System.Data;

namespace Aevitas.Observer
{
    /// <summary>
    /// Base class for any concrete subjects.
    /// </summary>
    public abstract class SubjectBase
    {
        public List<ObserverBase> Observers { get; private set; }

        protected SubjectBase()
        {
            Observers = new List<ObserverBase>();
        }

        public void RegisterObserver(ObserverBase observer)
        {
            // ObserverBase implements IEquatable, so we can safely do this.
            // Anyway, an observer only needs to be registered once, so don't register them if they exist already.
            if (Observers.Contains(observer))
                return;

            Observers.Add(observer);
        }

        public void UnregisterObserver(ObserverBase observer)
        {
            // Dave? Who's Dave?
            if (!Observers.Contains(observer))
                return;

            // Could pull some fancy LINQ stuff, but this will probably do.
            Observers.Remove(observer);
        }

        public void Notify()
        {
            // Nothing to send notifications to, yay!
            if (Observers.Count == 0)
                return;

            foreach (var o in Observers)
                o.Update();
        }

        #region Abstract Members

        public abstract string GetState();
        public abstract string State { get; set; }

        #endregion
    }
}

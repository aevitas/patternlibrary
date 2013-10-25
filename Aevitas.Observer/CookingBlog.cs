using System;

namespace Aevitas.Observer
{
    /// <summary>
    /// This cooking blog is very interested in our cooking subject, so he decided to subscribe to it.
    /// </summary>
    public class CookingBlog : ObserverBase, IDisposable
    {
        private ConcreteSubject _subject;
        public CookingBlog(ConcreteSubject subject) : base("Cooking Blog")
        {
            _subject = subject;

            _subject.RegisterObserver(this);
        }

        public override void Update()
        {
            var state = _subject.GetState();
            Console.WriteLine("Subject state changed to: {0}", state);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Make sure we're no longer subscribed if we are disposed.
            _subject.UnregisterObserver(this);
        }
    }
}

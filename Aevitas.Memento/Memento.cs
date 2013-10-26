namespace Aevitas.MementoPattern
{
    /// <summary>
    /// A memento of a specified object.
    /// </summary>
    public class Memento
    {
        private readonly object _state;

        public Memento(object state)
        {
            _state = state;
        }

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T AsType<T>() where T : struct
        {
            return (T)_state;
        }
    }
}

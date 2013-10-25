using System;

namespace Aevitas.Observer
{
    /// <summary>
    /// Base observer all concrete observers should inherit from.
    /// </summary>
    public abstract class ObserverBase : IEquatable<ObserverBase>
    {
        public abstract void Update();
        public string Name { get; set; }

        protected ObserverBase(string name)
        {
            Name = name;
        }

        #region Implementation of IEquatable

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(ObserverBase other)
        {
            return Equals(other as object);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" }, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ObserverBase)) return false;
            return Equals((ObserverBase) obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return 18*(Name.GetHashCode()) ^ 10;
        }

        #endregion
    }
}

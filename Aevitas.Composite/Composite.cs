using System.Collections;
using System.Collections.Generic;

namespace Aevitas.Composite
{
    /// <summary>
    /// 
    /// </summary>
    public class Composite : Component, IEnumerable<Component>
    {
        private List<Component> Children { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Composite"/> class.
        /// </summary>
        /// <param name="children">The children.</param>
        public Composite(params Component[] children)
        {
            Children = new List<Component>(children);
        }

        /// <summary>
        /// Executes this instance. (Called Operate in the original design)
        /// </summary>
        public override void Execute()
        {
            if (Children == null || Children.Count == 0)
                return;

            // Run all child nodes.
            foreach (var c in Children)
                c.Execute();
        }

        #region Implementation of IEnumerable

        public IEnumerator<Component> GetEnumerator()
        {
            // Could also just return Children.GetEnumerator, probably.
            foreach (Component c in Children)
                yield return c;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}

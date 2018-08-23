


using System.Collections.Generic;

namespace TI.Utilities.Patterns.Visitor
{
    /// <summary>
    /// A visitor that tracks (stores) objects in the order they were visited.
    /// Handy for demonstrating and testing different ordered visits implementations on
    /// data structures.
    /// </summary>
    /// <typeparam name="T">The type of objects to be visited.</typeparam>
    public sealed class TrackingVisitor<T> : IVisitor<T>
    {
        #region Globals

        private readonly List<T> tracks;

        #endregion

        #region Construction


        /// <inheritdoc/>
        public TrackingVisitor()
        {
            tracks = new List<T>();
        }

        #endregion		

        #region IVisitor<T> Members
        /// <inheritdoc />
        public void Visit(T obj)
        {
            tracks.Add(obj);
        }

        /// <inheritdoc />
        public bool HasCompleted {
            get
            {
                return false;
            }
        }

        #endregion

        #region Public Members 

        /// <summary>
        /// Gets the tracking list.
        /// </summary>
        /// <value>The tracking list.</value>        
        public IList<T> TrackingList
        {
            get
            {
                return tracks;
            }
        }

        #endregion
    }
}
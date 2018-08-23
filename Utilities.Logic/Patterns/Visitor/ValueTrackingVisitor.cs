


using System.Collections.Generic;

namespace TI.Utilities.Patterns.Visitor
{
    /// <summary>
    /// A visitor that tracks (stores) keys from KeyValuePairs in the order they were visited.
    /// </summary>
    /// <typeparam name="TKey">The type of key of the KeyValuePair.</typeparam>
    /// <typeparam name="TValue">The type of value of the KeyValuePair.</typeparam>
    public sealed class ValueTrackingVisitor<TKey, TValue> : IVisitor<KeyValuePair<TKey, TValue>>
    {
        #region Globals

        private readonly List<TValue> tracks;

        #endregion

        #region Construction


        /// <inheritdoc/>
        public ValueTrackingVisitor()
        {
            tracks = new List<TValue>();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets the tracking list.
        /// </summary>
        /// <value>The tracking list.</value>
        public IList<TValue> TrackingList
        {
            get
            {
                return tracks;
            }
        }

        #endregion

        #region IVisitor<KeyValuePair<TKey,TValue>> Members


        /// <inheritdoc />
        public void Visit(KeyValuePair<TKey, TValue> obj)
        {
            tracks.Add(obj.Value);
        }

        /// <inheritdoc />
        public bool HasCompleted
        {
            get
            {
                return false;
            }
        }

        #endregion
    }
}
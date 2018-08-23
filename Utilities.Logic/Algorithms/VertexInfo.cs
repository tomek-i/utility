using TI.Utilities.Collections.General;

namespace TI.Utilities.Algorithms
{
    internal class VertexInfo<T>
    {
        #region Construction

        public VertexInfo(double distance, Edge<T> edgeFollowed, bool isFinalised)
        {
            Distance = distance;
            EdgeFollowed = edgeFollowed;
            IsFinalised = isFinalised;
        }

        #endregion

        #region Properties

        public double Distance { get; set; }

        public Edge<T> EdgeFollowed { get; set; }

        public bool IsFinalised { get; set; }

        #endregion
    }
}

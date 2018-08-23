namespace TI.Utilities.Collections.Queues
{
    /// <summary>
    /// Specifies the Priority Queue type (min or max).
    /// </summary>
    public enum PriorityQueueType
    {
        /// <summary>
        /// Specify a Minimum <see cref="PriorityQueue{TValue, TPriority}"/>.
        /// </summary>
        Minimum = 0,

        /// <summary>
        /// Specify a Maximum <see cref="PriorityQueue{TValue, TPriority}"/>.
        /// </summary>
        Maximum = 1
    }
}
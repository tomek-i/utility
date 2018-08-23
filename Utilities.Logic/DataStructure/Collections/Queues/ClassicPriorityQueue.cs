namespace TI.Utilities.Collections.Queues
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ClassicPriorityQueue<T> : PriorityQueue<T, int>
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassicPriorityQueue&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="queueType">Type of the queue.</param>
        /// <example>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Queues\PriorityQueueExamples.cs" region="Constructor" lang="cs" title="The following example shows how to use the default constructor."/>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Queues\PriorityQueueExamples.vb" region="Constructor" lang="vbnet" title="The following example shows how to use the default constructor."/>
        /// </example>
        public ClassicPriorityQueue(PriorityQueueType queueType) : base(queueType)
        {
            // Do nothing
        }

        #endregion
    }
}

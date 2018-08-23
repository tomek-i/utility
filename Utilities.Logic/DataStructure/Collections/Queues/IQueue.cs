using System;
using System.Diagnostics.CodeAnalysis;

namespace TI.Utilities.Collections.Queues
{
    /// <summary>
    /// A queue interface.
	/// </summary>
	/// <typeparam name="T">The type of the elements in the queue.</typeparam>
    [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
	public interface IQueue<T>
	{
		/// <summary>
		/// Enqueues the item at the back of the queue.
		/// </summary>
		/// <param name="item">The item.</param>
		void Enqueue(T item);

		/// <summary>
		/// Dequeues the item at the front of the queue.
		/// </summary>
		/// <returns>The item at the front of the queue.</returns>
		/// <exception cref="InvalidOperationException">The <see cref="Deque{T}"/> is empty.</exception>
		T Dequeue();

		/// <summary>
		/// Peeks at the item in the front of the queue, without removing it.
		/// </summary>
		/// <returns>The item at the front of the queue.</returns>
		/// <exception cref="InvalidOperationException">The <see cref="Deque{T}"/> is empty.</exception>
		T Peek();
	}
}



using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TI.Utilities.Collections.Trees {
    /// <summary>
    /// An interface for Search Trees that mimic a dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the <see cref="ISearchTreeDictionary{TKey,TValue}"/>.</typeparam>
    /// <typeparam name="TValue">The type of the values in the <see cref="ISearchTreeDictionary{TKey,TValue}"/>.</typeparam>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    public interface ISearchTreeDictionary<TKey, TValue> : ISearchTree<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue> {

    }
}

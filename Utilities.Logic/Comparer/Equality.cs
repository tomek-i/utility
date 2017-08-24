using System;
using System.Collections.Generic;

namespace TIUtilities.Logic
{
    public static class Equality<T>
    {
        public static IEqualityComparer<T> CreateComparer<V>(Func<T,V> keySelector)
        {
            return CreateComparer(keySelector, null);
        }
        public static IEqualityComparer<T> CreateComparer<V>(Func<T, V> keySelector,IEqualityComparer<V> comparer)
        {
            return new KeyEqualityComparer<V>(keySelector, comparer);
        }
        private class KeyEqualityComparer<V>:IEqualityComparer<T>
        {
            private readonly Func<T, V> keySelector;
            private readonly IEqualityComparer<V> comparer;

            public KeyEqualityComparer(Func<T,V> keySelector,IEqualityComparer<V> comparer)
            {
                if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
                this.keySelector = keySelector;
                this.comparer = comparer ?? EqualityComparer<V>.Default;
            }
            public bool Equals(T left, T right)
            {
                return comparer.Equals(keySelector(left), keySelector(right));
            }

            public int GetHashCode(T obj)
            {
                return comparer.GetHashCode(keySelector(obj));
            }
        }
    }
}
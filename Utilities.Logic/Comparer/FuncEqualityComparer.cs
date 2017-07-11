using System;
using System.Collections.Generic;

namespace TIUtilities.Logic
{
    public class FuncEqualityComparer<T>:IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _comparer;
        private readonly Func<T, int> _hash;
        public FuncEqualityComparer(Func<T,T,bool> comparer):this(comparer,T=>0)
            //NB cannot assume anything about how eg. t.GetHashCode() interacts with the comparers behavriour
        {

        }

        public FuncEqualityComparer(Func<T, T, bool> comparer, Func<T,int> hash) 
        {
            _comparer = comparer;
            _hash = hash;
        }

        public bool Equals(T left, T right)
        {
            return _comparer(left, right);
        }

        public int GetHashCode(T obj)
        {
            return _hash(obj);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace TI.Utilities
{

    
    public static class TypeMapping
    {
        private static readonly IDictionary<Type, object> mappings;

        static TypeMapping()
        {
            mappings = new Dictionary<Type, object>();
        }

        public static void Map<T>(object obj)
        {
            Map(typeof(T), obj);
        }

        public static void Map(Type type, object obj)
        {
            mappings.Add(type, obj);
        }

        public static object Get(Type t)
        {
            return mappings.ContainsKey(t) ? mappings[t] : null;
        }
        public static T Get<T>()
            where T : class
        {
            var t = typeof(T);
            return Get(t) as T;
        }


        public static TRet Get<T, TRet>()
            where T : class
            where TRet : class
        {
            var t = typeof(T);
            return Get(t) as TRet;
        }

        public static void Clear()
        {
            mappings.Clear();
        }
    }
}
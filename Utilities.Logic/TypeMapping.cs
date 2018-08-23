using System;
using System.Collections.Generic;

namespace TI.Utilities
{
    /// <summary>
    /// Utility class to map types to physical objects
    /// </summary>
    public static class TypeMapping
    {
        private static readonly IDictionary<Type, object> mappings;

        static TypeMapping()
        {
            mappings = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Mapps T and uses activator to crteate instance of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Map<T>()
        {
            mappings.Add(typeof(T), Activator.CreateInstance<T>());
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
        public static void Remove(Type type)
        {

            if (mappings.ContainsKey(type))
            {
                mappings.Remove(type);
            }
        }


        /// <summary>
        /// Gets the T mapping as TReturn
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <returns></returns>
        public static TReturn Get<T, TReturn>()
           where T : class
           where TReturn : class
        {
            return Get(typeof(T)) as TReturn;
        }
        /// <summary>
        /// Gets the type mapping as T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>the value type as T</returns>
        public static T Get<T>() where T : class
        {
            return Get(typeof(T)) as T;
        }
        public static void Remove<T>()
        {
            Remove(typeof(T));
        }

        public static void Clear()
        {
            mappings.Clear();
        }
    }
}
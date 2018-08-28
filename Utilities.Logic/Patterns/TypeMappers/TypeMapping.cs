using System;

namespace TI.Utilities
{

    /// <summary>
    /// Utility class to map types to physical objects
    /// </summary>
    public class TypeMapping : GenericMapper<Type, object>
    {
        
        private static TypeMapping _instance;

        public static TypeMapping Instance { get { return _instance ?? (_instance = new TypeMapping()); } }

        public TypeMapping():base()
        {
        }

        /// <summary>
        /// Mapps T and uses activator to crteate instance of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void Map<T>()
        {
            Map(typeof(T));
        }
        public void Map<T>(object obj)
        {
            Map(typeof(T), obj);
        }
        public void Map(Type type)
        {
            Map(type, Activator.CreateInstance(type));
        }
           
       


        /// <summary>
        /// Gets the T mapping as TReturn
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <returns></returns>
        public TReturn Get<T, TReturn>()
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
        public T Get<T>() where T : class
        {
            return Get(typeof(T)) as T;
        }
        public void Remove<T>()
        {
            Remove(typeof(T));
        }

       
    }
}
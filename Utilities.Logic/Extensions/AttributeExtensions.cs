using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TI.Utilities.Extensions
{
    public static class AttributeExtensions
    {

        public static IEnumerable<T> GetAttributes<T>(this object obj) where T : Attribute
        {
            return obj.GetType().GetCustomAttributes<T>();
        }
        public static T GetAttribute<T>(this object obj) where T : Attribute
        {
            return obj.GetType().GetCustomAttribute<T>();
        }
        public static T GetAttribute<T>(this object o, bool inherit) where T : Attribute
        {
            if (o == null) throw new NullReferenceException(nameof(o));

            return o.GetType().GetCustomAttributes(typeof(T), inherit).First() as T;
        }
        public static T GetAttribute<T>(this Type type, bool inherit) where T : Attribute
        {
            return type.GetCustomAttributes(typeof(T), inherit).First() as T;
        }
        public static bool ContainsAttribute<T>(this Type type, bool inherit) where T : Attribute
        {
            var attributes = type.GetCustomAttributes(typeof(T), inherit);
            return attributes.Length > 0;
        }



    }
}
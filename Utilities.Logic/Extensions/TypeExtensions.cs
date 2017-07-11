using System;
using System.Linq.Expressions;
using System.Reflection;

namespace TIUtilities.Logic
{
    public static class TypeExtensions
    {
        public static bool InheritsFrom(this Type type, Type targetType)
        {
            return type.GetInterface(targetType.ToString()) != null;
        }
        public static bool InheritsFrom<T>(this Type type)
        {
            return type.InheritsFrom(typeof(T));
        }
        public static PropertyInfo GetPropertyEx(this System.Type type, string propertyName)
        {
            var property = type.GetProperty(propertyName);
            if (property != null) return property;
            //base types
            var baseTypes = type.GetInterfaces();
            foreach (var basetype in baseTypes)
            {
                return GetPropertyEx(basetype, propertyName);
            }
            return null;
        }
        /// <summary>
        /// Can be used Like Object.Name(x=> x.Property);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProp"></typeparam>
        /// <param name="obj"></param>
        /// <param name="propertySSelector"></param>
        /// <returns></returns>
        public static string Name<T,TProp>(this T obj, Expression<Func<T,TProp>> propertySSelector)
        {
            MemberExpression body = (MemberExpression)propertySSelector.Body;
            return body.Member.Name;
        }
    }
}
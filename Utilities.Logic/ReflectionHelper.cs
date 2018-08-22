using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TI.Utilities
{
    public static class ReflectionHelper
    {

        public static IEnumerable<Type> GetTypesWithInterface<T>()
        {
            return GetTypesWithInterface<T>(AppDomain.CurrentDomain.GetAssemblies());
        }
        public static IEnumerable<Type> GetTypesWithInterface<T>(Assembly assembly)
        {
            Assembly[] assemblies = { assembly };
            return GetTypesWithInterface<T>(assemblies);
        }
        public static IEnumerable<Type> GetTypesWithInterface<T>(IEnumerable<Assembly> assemblies)
        {
            return assemblies
                .SelectMany(s => s.GetTypes())
                .Where(assemblyType => assemblyType.GetInterfaces().Contains(typeof(T)));
        }
        public static IEnumerable<Type> GetTypesInheritFrom<T>()
        {
            return GetTypesInheritFrom<T>(AppDomain.CurrentDomain.GetAssemblies(), null);
        }


        /// <remarks>
        /// you can specify predicates like so:
        ///     <example>
        ///          <code>
        ///             GetTypesInheritFrom(x => x.IsClass && !x.IsAbstract && x != typeof(T) && x.IsSubclassOf(typeof(T)));
        ///         </code>
        ///     </example>
        /// </remarks>
        public static IEnumerable<Type> GetTypesInheritFrom<T>(Func<Type, bool> wherePredicate)
        {
            return GetTypesInheritFrom<T>(AppDomain.CurrentDomain.GetAssemblies(), wherePredicate);
        }
        public static IEnumerable<Type> GetTypesInheritFrom<T>(Assembly assembly)
        {
            Assembly[] assemblies = { assembly };
            return GetTypesInheritFrom<T>(assemblies, null);
        }
        public static IEnumerable<Type> GetTypesInheritFrom<T>(IEnumerable<Assembly> assemblies)
        {
            return GetTypesInheritFrom<T>(assemblies, null);
        }

        /// <remarks>
        /// you can specify predicates like so:
        ///     <example>
        ///          <code>
        ///             GetTypesInheritFrom(x => x.IsClass && !x.IsAbstract && x != typeof(T) && x.IsSubclassOf(typeof(T)));
        ///         </code>
        ///     </example>
        /// </remarks>
        public static IEnumerable<Type> GetTypesInheritFrom<T>(Assembly assembly, Func<Type, bool> wherePredicate)
        {
            Assembly[] assemblies = { assembly };
            return GetTypesInheritFrom<T>(assemblies, wherePredicate);
        }

        /// <remarks>
        /// you can specify predicates like so:
        ///     <example>
        ///          <code>
        ///             GetTypesInheritFrom(x => x.IsClass && !x.IsAbstract && x != typeof(T) && x.IsSubclassOf(typeof(T)));
        ///         </code>
        ///     </example>
        /// </remarks>
        public static IEnumerable<Type> GetTypesInheritFrom<T>(IEnumerable<Assembly> assemblies, Func<Type, bool> wherePredicate)
        {
            return assemblies
                .SelectMany(x => x.GetTypes())
                .Where(type =>
                {
                    bool isSubclass = type.IsSubclassOf(typeof(T));

                    if (wherePredicate != null)
                        return isSubclass && wherePredicate.Invoke(type);

                    return isSubclass;
                });
        }

    }
}

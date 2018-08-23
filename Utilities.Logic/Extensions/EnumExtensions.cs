using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TI.Utilities.Extensions
{

    /// <summary>
    /// Extensions for the IEnumerable interface.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Performs the specified action on each element of the collection.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="enumerable"/>.</typeparam>
        /// <param name="enumerable">The collection to enumerate over.</param>
        /// <param name="action">The action to perform on each item..</param>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Extensions\IEnumerableExtensionsExamples.cs" region="ForEach" lang="cs" title="The following example shows how to use the ForEach method."/>
        /// </example>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            Guard.ArgumentNotNull(enumerable, "enumerable");
            Guard.ArgumentNotNull(action, "action");


            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        /// <summary>
        /// Concatenates all the values into a string using ", " as in betweeen each value.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="enumerable"/>.</typeparam>
        /// <param name="enumerable">The <see cref="IEnumerable{T}"/> to concatenate.</param>
        /// <param name="func">A <see cref="Func{T,V}"/> to convert each <typeparamref name="T"/> to a string.</param>
        /// <returns>All values concatenated into a string using ", " as in betweeen each value.</returns>
        public static string ConcatToString<T>(this IEnumerable<T> enumerable, Func<T, string> func)
        {
            return ConcatToString(enumerable, func, ", ");
        }

        /// <summary>
        /// Concatenates all the values into a string using <paramref name="joinString"/> as in betweeen each value.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="enumerable"/>.</typeparam>
        /// <param name="enumerable">The <see cref="IEnumerable{T}"/> to concatenate.</param>
        /// <param name="func">A <see cref="Func{T,V}"/> to convert each <typeparamref name="T"/> to a string.</param>
        /// <param name="joinString">The <see cref="string"/> to use in between each value.</param>
        /// <returns>All values concatenated into a string using ", " as in betweeen each value.</returns>
        private static string ConcatToString<T>(this IEnumerable<T> enumerable, Func<T, string> func, string joinString)
        {
            var stringBuilder = new StringBuilder();
            var list = Enumerable.ToList(enumerable);
            for (var index = 0; index < list.Count; index++)
            {
                var item = list[index];
                stringBuilder.Append(func(item));
                if (index != list.Count - 1)
                {
                    stringBuilder.Append(joinString);
                }
            }
            return stringBuilder.ToString();
        }
    }

    public static class EnumExtensions
    {

        public static T GetEnumFromDescription<T>(this string value)where T:struct,IConvertible
        {
            if (!typeof(T).IsEnum) throw new ArgumentException("must be an enumerated type");
            foreach (var val in Enum.GetValues(typeof(T)))
            {
                Enum v = (Enum)val;
                if (v.Description() != value)continue;
                if (val != null) return ((T)val);

            }
            return default(T);
        }

        /// <summary>
        /// can be usded like <c>("Test").ToEnum<T>();</c>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string str) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum) throw new ArgumentException("must be an enumerated type");

            foreach (var value in Enum.GetValues(typeof(T)))
            {
                if (value.ToString() == str) return (T)value;
            }
            return default(T);
        }
        public static string Description(this Enum en)
        {
            var memberInfo = en.GetType().GetMember(en.ToString());
            if (memberInfo.Length <= 0) return en.ToString();
            MemberInfo m = memberInfo.First();
            var x = m.GetAttribute<DescriptionAttribute>(false);
            return x == null ? en.ToString() : x.Description;
        }
    }
}
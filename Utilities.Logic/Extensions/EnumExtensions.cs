using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace TIUtilities.Logic
{
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
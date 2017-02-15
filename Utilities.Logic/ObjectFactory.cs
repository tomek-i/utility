using System;
using System.Collections.Generic;

namespace TIUtilities.Logic.ValidationFramework
{
    public static class ObjectFactory
    {
        static readonly Dictionary<Type, object> Register = new Dictionary<Type, object>();
        public static void RegisterType<T>(object obj)
        {
            RegisterType(typeof (T), obj);
        }

        public static void RegisterType(Type type, object obj)
        {
            Register.Add(type, obj);
        }

        public static object GetInstance(Type type)
        {
            return Register.ContainsKey(type) ? Register[type] : null;
        }

        public static T GetInstance<T>() where T : class
        {
            return GetInstance(typeof (T)) as T;
        }
    }
}
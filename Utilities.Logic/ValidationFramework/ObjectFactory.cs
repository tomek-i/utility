using System;
using System.Collections.Generic;

namespace TIUtilities.Logic.ValidationFramework
{
    public static class ObjectFactory
    {
        static readonly Dictionary<Type, object> Register = new Dictionary<Type, object>();
        public static void RegisterType<T>(object obj)
        {
            Register.Add(typeof(T), obj);
        }
        public static T GetInstance<T>() where T : class
        {
            return Register[typeof(T)] as T;
        }
    }
}
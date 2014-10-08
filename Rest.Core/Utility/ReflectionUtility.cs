using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace Rest.Core.Utility
{
    public class ReflectionUtility
    {
        public static List<T2> ListConvertor<T1, T2>(List<T1> from)
            where T2 : class
        {
            List<T2> result = new List<T2>() { };
            if (from != null)
            {
                from.ForEach(x =>
                {
                    T2 tmp = Activator.CreateInstance(typeof(T2)) as T2;
                    result.Add(tmp);
                });
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
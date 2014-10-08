using System;
using System.ComponentModel;
using System.Reflection;

namespace Rest.Core.Utility
{
    public class EnumHelper
    {
        public static string GetEnumDescription<T>(T value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static T GetEnumByName<T>(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return default(T);
            }
            else
            {
                T rtn;
                try
                {
                    rtn = (T)Enum.Parse(typeof(T), value, true);
                }
                catch
                {
                    rtn = default(T);
                }
                return rtn;
            }
        }
    }
}
using System.Linq;

namespace Rest.Core.Utility
{
    public class AttributeHelper
    {
        /// <summary>
        /// Return the attrubute object, you can get value from the object.
        /// </summary>
        /// <typeparam name="T">Attribute filter</typeparam>
        /// <param name="value">Class for the attrubute apply.</param>
        /// <returns>Attrubute object</returns>
        public static T GetAttribute<T>(object value)
        {
            if (value != null)
            {
                object[] attributes = value.GetType().GetCustomAttributes(typeof(T), true);
                if (attributes != null && attributes.Count() > 0)
                {
                    return (T)attributes[0];
                }
                else
                {
                    return default(T);
                }
            }
            else
            {
                return default(T);
            }
        }
    }
}
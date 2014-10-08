using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using Rest.Core.Constancy;

namespace Rest.Core.Utility
{
    public static class Extension
    {
        public static object CloneObject(this object toClass, object fromClass)
        {
            if (fromClass != null)
            {
                Type fromType = fromClass.GetType();
                Type toType = toClass.GetType();
                foreach (PropertyInfo prop in fromType.GetProperties())
                {
                    var toprop = toType.GetProperty(prop.Name);
                    if (toprop != null && toprop.PropertyType == prop.PropertyType)
                    {
                        object fromValue = prop.GetValue(fromClass, null);

                        if (string.Compare("System", prop.PropertyType.Namespace, true) == 0)
                        {
                            toType.GetProperty(prop.Name).SetValue(toClass, fromValue, null);
                        }
                        else if (prop.PropertyType.IsSerializable)
                        {
                            var newObj = fromValue.CloneObjectBySerializable();
                            toType.GetProperty(prop.Name).SetValue(toClass, newObj, null);
                        }
                        else
                        {
                            var newObj = CloneObjectByReflection(fromValue);
                            toType.GetProperty(prop.Name).SetValue(toClass, newObj, null);
                        }
                    }
                }
                return toClass;
            }
            else
            {
                return null;
            }
        }

        public static object CloneObjectByReflection(object objSource)
        {
            //step : 1 Get the type of source object and create a new instance of that type
            Type typeSource = objSource.GetType();
            object objTarget = Activator.CreateInstance(typeSource);

            //Step2 : Get all the properties of source object type
            PropertyInfo[] propertyInfo = typeSource.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            //Step : 3 Assign all source property to taget object 's properties
            foreach (PropertyInfo property in propertyInfo)
            {
                //Check whether property can be written to
                if (property.CanWrite)
                {
                    //Step : 4 check whether property type is value type, enum or string type
                    if (property.PropertyType.IsValueType || property.PropertyType.IsEnum || property.PropertyType.Equals(typeof(System.String)))
                    {
                        property.SetValue(objTarget, property.GetValue(objSource, null), null);
                    }
                    //else property type is object/complex types, so need to recursively call this method until the end of the tree is reached
                    else
                    {
                        object objPropertyValue = property.GetValue(objSource, null);
                        if (objPropertyValue == null)
                        {
                            property.SetValue(objTarget, null, null);
                        }
                        else
                        {
                            property.SetValue(objTarget, CloneObjectByReflection(objPropertyValue), null);
                        }
                    }
                }
            }
            return objTarget;
        }

        public static object CloneObjectBySerializable(this object fromObj)
        {
            if (fromObj != null)
            {
                using (var ms = new MemoryStream())
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(ms, fromObj);
                    ms.Position = 0;

                    return (object)formatter.Deserialize(ms);
                }
            }
            else
            {
                return null;
            }
        }

        public static List<T2> ListConvertor<T1, T2>(this List<T1> from)
            where T2 : class
        {
            List<T2> result = new List<T2>() { };
            if (from != null)
            {
                from.ForEach(x =>
                {
                    T2 tmp = Activator.CreateInstance(typeof(T2)) as T2;
                    tmp.CloneObject(x);
                    result.Add(tmp);
                });
                return result;
            }
            else
            {
                return null;
            }
        }

        public static int ToInt(this TrueOrFalse obj)
        {
            return (int)obj;
        }
    }
}

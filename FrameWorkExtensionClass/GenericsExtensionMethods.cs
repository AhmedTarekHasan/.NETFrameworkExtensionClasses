using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;

namespace DevelopmentSimplyPut.ExtensionMethods.GenericsExtensionMethods
{
    public static class GenericsExtensionMethods
    {
        /// <summary>
        /// Returns a bool indicating whether the object is nullable or not
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool ext_IsNullable<T>(this T source)
        {
            bool result = false;

            if (source == null)
            {
                result = true;
            }
            else
            {
                Type type = typeof(T);

                if (!type.IsValueType)
                {
                    result = true;
                }
                else if (Nullable.GetUnderlyingType(type) != null)
                {
                    result = true;
                }
            }

            return result;
        }
        /// <summary>
        /// Returns a bool indicating whether the object is value type or not
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool ext_IsItValueType<T>(this T source)
        {
            Type type = typeof(T);
            return (type.IsValueType);
        }
        /// <summary>
        /// Converts from T1 to T2 if doable or just return a default value
        /// </summary>
        /// <typeparam name="T1">Type of Object to convert</typeparam>
        /// <typeparam name="T2">Type of Object to convert to</typeparam>
        /// <param name="source">Object to convert</param>
        /// <param name="CustomConvertOrDefault">Predicate to be used for conversion</param>
        /// <returns>Converted object of type T2 or a default value</returns>
        public static T2 ext_ConvertOrDefault<T1, T2>(this T1 source, Func<T1, T2> CustomConvertOrDefault)
        {
            return CustomConvertOrDefault(source);
        }
        /// <summary>
        /// Converts from T1 to T2 if doable or just return a default value
        /// </summary>
        /// <typeparam name="T1">Type of Object to convert</typeparam>
        /// <typeparam name="T2">Type of Object to convert to</typeparam>
        /// <param name="source">Object to convert</param>
        /// <param name="CustomConvertOrDefault">Predicate to be used for conversion</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails</param>
        /// <returns>Converted object of type T2 or a default value</returns>
        public static T2 ext_ConvertOrDefault<T1, T2>(this T1 source, Func<T1, T2, T2> CustomConvertOrDefault, T2 defaultValue)
        {
            return CustomConvertOrDefault(source, defaultValue);
        }
        /// <summary>
        /// Serialises an object of type T in to an xml string
        /// </summary>
        /// <typeparam name="T">Any class type</typeparam>
        /// <param name="objectToSerialise">Object to serialise</param>
        /// <returns>A string that represents Xml, empty oterwise</returns>
        public static string ext_XmlSerialize<T>(this T objectToSerialise) where T : class
        {
            var serialiser = new XmlSerializer(typeof(T));
            string xml;
            using (var memStream = new MemoryStream())
            {
                using (var xmlWriter = new XmlTextWriter(memStream, Encoding.UTF8))
                {
                    serialiser.Serialize(xmlWriter, objectToSerialise);
                    xml = Encoding.UTF8.GetString(memStream.GetBuffer());
                }
            }

            // ascii 60 = '<' and ascii 62 = '>'
            xml = xml.Substring(xml.IndexOf(Convert.ToChar(60)));
            xml = xml.Substring(0, (xml.LastIndexOf(Convert.ToChar(62)) + 1));
            return xml;
        }
        /// <summary>
        /// Checks if a value falls in between two given values
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="value"></param>
        /// <param name="low">Lower bound value</param>
        /// <param name="high">Higher bound value</param>
        /// <returns></returns>
        public static bool ext_IsBetween<T>(this T value, T low, T high) where T : IComparable<T>
        {
            return value.CompareTo(low) >= 0 && value.CompareTo(high) <= 0;
        }
    }
}
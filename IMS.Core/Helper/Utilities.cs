using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.ComponentModel;
using System.Reflection;

namespace IMS.Core.Helper
{
    public class Utilities
    {
        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[-a-zA-Z0-9][-_.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.
                    (com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$";

            Regex check = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
            bool valid = false;

            if (string.IsNullOrEmpty(email))
            {
                valid = false;
            }
            else
            {
                valid = check.IsMatch(email);
            }
            return valid;
        }

        public static string CleanJsonRawValue(string rawJson)
        {
            var cleanedData = rawJson.Replace("\"{", "{").Replace("}\"", "}").Replace("\\", "");
            return Uri.UnescapeDataString(cleanedData);
        }

        public static T ConvertJsonToObject<T>(string rawJson)
        {
            var jsonSerializer = new JavaScriptSerializer();
            var parsedSiteSettingsCollection = jsonSerializer.Deserialize<T>(rawJson);

            return (T)parsedSiteSettingsCollection;
        }

        public static string ConvertObjectToJson(object input)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(input);
        }

        public static string StringValueOf(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])
                fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        public static object EnumValueOf(string value, Type enumType)
        {
            string[] names = Enum.GetNames(enumType);
            foreach (string name in names)
            {
                if (StringValueOf((Enum)Enum.Parse(enumType, name)).Equals(value))
                {
                    return Enum.Parse(enumType, name);
                }
            }

            throw new ArgumentException("The string is not a description or value of the specified enum.");
        }
    }
}

using System;
using System.ComponentModel;
using System.Reflection;

namespace Ticket.Utility.Helper
{
    public static class EnumHelper
    {
        public static string GetDescription<T>(this Enum @enum)
        {
            var type = typeof(T);
            var fieldName = Enum.GetName(type, @enum);
            var attrs = type.GetField(fieldName).GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attrs.Length > 0)
            {
                return (attrs[0] as DescriptionAttribute).Description;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// get enum description by name
        /// </summary>
        /// <typeparam name="T">enum type</typeparam>
        /// <param name="enumItemName">the enum name</param>
        /// <returns></returns>
        public static string GetDescriptionName<T>(this T enumItemName)
        {
            FieldInfo fi = enumItemName.GetType().GetField(enumItemName.ToString());
            if (fi == null)
            {
                return "";
            }
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : enumItemName.ToString();
        }
    }
}

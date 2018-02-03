using System;
using System.ComponentModel;

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
    }
}

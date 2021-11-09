using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MenuConfigurator.Model
{
    public static class AttributeExtensions
    {
        public static string Description<T>(this T source) where T : Enum
        {
            var attribute = source.GetAttribute<T, DescriptionAttribute>();
            if (attribute is null)
                return source.ToString();

            return attribute.Description;
        }

        public static string DisplayName<T>(this T source) where T : Enum
        {
            var attribute = source.GetAttribute<T, DisplayAttribute>();
            if (attribute is null)
                return source.ToString();

            return attribute.Name;
        }

        private static TAttribute GetAttribute<TEnum, TAttribute>(this TEnum source)
            where TEnum : Enum
            where TAttribute : Attribute
        {
            var typeInfo = source.GetType().GetTypeInfo();
            var memberInfo = typeInfo.GetMember(source.ToString());
            var attributes = memberInfo[0].GetCustomAttributes<TAttribute>();
            if (attributes.Any())
            {
                return attributes.First();
            }
            return null;
        }

       
    }
}
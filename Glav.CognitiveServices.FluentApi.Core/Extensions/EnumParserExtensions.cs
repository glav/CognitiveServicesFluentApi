using System;

namespace Glav.CognitiveServices.FluentApi.Core.Extensions
{
    public static class EnumParserExtensions
    {
        public static T ToEnumType<T>(this string textValue) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("Not an Enumerated type.");
            }

            var enumNames = System.Enum.GetNames(typeof(T));
            if (string.IsNullOrWhiteSpace(textValue))
            {
                return (T)Enum.Parse(typeof(T), enumNames[0]);
            }
            var normalised = textValue.ToLowerInvariant();

            foreach (var ev in enumNames)
            {
                if (ev.ToLowerInvariant() == normalised)
                {
                    return (T)System.Enum.Parse(typeof(T), ev);
                }
            }
            return (T)Enum.Parse(typeof(T), enumNames[0]);
        }

    }
}

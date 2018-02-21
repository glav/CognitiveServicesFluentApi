using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.Communication
{
    public static class UrlQueryParameterFromEnumFormatter
    {
        public static string ToUrlQueryParameters<T>(T options, string queryParamName) where T : struct, IComparable, IConvertible, IFormattable
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("Not an Enumerated type.");
            }

            var optionsVal = options.ToInt32(System.Globalization.CultureInfo.InvariantCulture);


            if (optionsVal == 0)
            {
                return string.Empty;
            }

            var urlArgs = new List<string>();
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                var itemVal = item.ToInt32(System.Globalization.CultureInfo.InvariantCulture);
                if ((optionsVal & itemVal) == itemVal && itemVal != 0)
                {
                    urlArgs.Add(item.ToString());
                }
            }
            return string.Format("{0}={1}", queryParamName, string.Join(",", urlArgs.ToArray()));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.Extensions
{
    public static class StringExtensions
    {
        public static DateTime ToUtc(this string dateTimeValue)
        {
            if (string.IsNullOrWhiteSpace(dateTimeValue))
            {
                throw new CognitiveServicesArgumentException("Unable to convert to UTC, dateTimeValue is NULL or empty");
            }

            return DateTime.Parse(dateTimeValue, CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.RoundtripKind);
        }
    }
}

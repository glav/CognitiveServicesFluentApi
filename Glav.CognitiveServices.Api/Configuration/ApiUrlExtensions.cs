using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Configuration
{
    public static class ApiUrlExtensions
    {
        public static string ApiServiceUrl(this ApiActionType apiActionType)
        {
            if (apiActionType == ApiActionType.TextAnalyticsSentiment)
            {
                return string.Format(ApiServiceUrlFragments.TextAnalyticsSentiment.Template, ApiServiceUrlFragments.TextAnalyticsSentiment.Version);
            }

            if (apiActionType == ApiActionType.TextAnalyticsKeyphrases)
            {
                return string.Format(ApiServiceUrlFragments.TextAnalyticsKeyPhrase.Template, ApiServiceUrlFragments.TextAnalyticsSentiment.Version);
            }

            throw new NotSupportedException();
        }
    }
}

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
                return ApiServiceUrlFragments.SentimentService.ServiceUri;
            }

            if (apiActionType == ApiActionType.TextAnalyticsKeyphrases)
            {
                return ApiServiceUrlFragments.KeyPhraseService.ServiceUri;
            }

            if (apiActionType == ApiActionType.TextAnalyticsLanguages)
            {
                return ApiServiceUrlFragments.LanguageService.ServiceUri;
            }

            if (apiActionType == ApiActionType.TextAnalyticsTopics)
            {
                return ApiServiceUrlFragments.TopicService.ServiceUri;
            }

            throw new NotSupportedException();
        }
    }
}

using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public static class TextAnalyticUrlExtensions
    {
        private static ApiServiceUrlFragments _urlFragments = new ApiServiceUrlFragments();

        public static string ApiServiceUrl(this ApiActionType apiActionType)
        {
            if (apiActionType == ApiActionType.TextAnalyticsSentiment)
            {
                return _urlFragments.SentimentService.ServiceUri;
            }

            if (apiActionType == ApiActionType.TextAnalyticsKeyphrases)
            {
                return _urlFragments.KeyPhraseService.ServiceUri;
            }

            if (apiActionType == ApiActionType.TextAnalyticsLanguages)
            {
                return _urlFragments.LanguageService.ServiceUri;
            }

            if (apiActionType == ApiActionType.TextAnalyticsTopics)
            {
                return _urlFragments.TopicService.ServiceUri;
            }

            throw new NotSupportedException();
        }
    }
}

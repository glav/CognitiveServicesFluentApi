using Glav.CognitiveServices.Api.Configuration.TextAnalytic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Core.Configuration
{
    public static class ApiServiceUrlFragments
    {
        public const string BASE_URL_TEMPLATE = "https://{0}.api.cognitive.microsoft.com/";
        private static Dictionary<ApiActionType, BaseApiServiceUriFragment> _services = new Dictionary<ApiActionType, BaseApiServiceUriFragment>();

        static ApiServiceUrlFragments()
        {
            _services.Add(ApiActionType.TextAnalyticsTopics, new TopicServiceConfig());
            _services.Add(ApiActionType.TextAnalyticsSentiment, new SentimentServiceConfig());
            _services.Add(ApiActionType.TextAnalyticsKeyphrases, new KeyPhraseServiceConfig());
            _services.Add(ApiActionType.TextAnalyticsLanguages, new LanguageServiceConfig());
            _services.Add(ApiActionType.TextAnalyticsOperationStatus, new OperationStatusServiceConfig());
        }

        public static SentimentServiceConfig SentimentService => _services[ApiActionType.TextAnalyticsSentiment] as SentimentServiceConfig;
        public static KeyPhraseServiceConfig KeyPhraseService => _services[ApiActionType.TextAnalyticsKeyphrases] as KeyPhraseServiceConfig;
        public static LanguageServiceConfig LanguageService => _services[ApiActionType.TextAnalyticsLanguages] as LanguageServiceConfig;
        public static TopicServiceConfig TopicService => _services[ApiActionType.TextAnalyticsTopics] as TopicServiceConfig;
        public static OperationStatusServiceConfig OperationStatusService => _services[ApiActionType.TextAnalyticsOperationStatus] as OperationStatusServiceConfig;
        public static EmotionServiceConfig EmotionService => _services[ApiActionType.Emotion] as EmotionServiceConfig;
    }
}

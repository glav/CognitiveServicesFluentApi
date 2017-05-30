using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public class ApiServiceUriCollection : ApiServiceUriCollectionBase
    {
        public ApiServiceUriCollection()
        {
            Services.Add(ApiActionType.TextAnalyticsTopics, new TopicServiceConfig());
            Services.Add(ApiActionType.TextAnalyticsSentiment, new SentimentServiceConfig());
            Services.Add(ApiActionType.TextAnalyticsKeyphrases, new KeyPhraseServiceConfig());
            Services.Add(ApiActionType.TextAnalyticsLanguages, new LanguageServiceConfig());
            Services.Add(ApiActionType.TextAnalyticsOperationStatus, new OperationStatusServiceConfig());
        }
    }
}

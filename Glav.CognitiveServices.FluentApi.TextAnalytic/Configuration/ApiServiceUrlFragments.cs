using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public class ApiServiceUrlFragments : ApiServiceUrlFragmentsBase
    {
        public ApiServiceUrlFragments()
        {
            Services.Add(ApiActionType.TextAnalyticsTopics, new TopicServiceConfig());
            Services.Add(ApiActionType.TextAnalyticsSentiment, new SentimentServiceConfig());
            Services.Add(ApiActionType.TextAnalyticsKeyphrases, new KeyPhraseServiceConfig());
            Services.Add(ApiActionType.TextAnalyticsLanguages, new LanguageServiceConfig());
            Services.Add(ApiActionType.TextAnalyticsOperationStatus, new OperationStatusServiceConfig());
            Services.Add(ApiActionType.Emotion, new EmotionServiceConfig());
        }

        //public SentimentServiceConfig SentimentService => Services[ApiActionType.TextAnalyticsSentiment] as SentimentServiceConfig;
        //public KeyPhraseServiceConfig KeyPhraseService => Services[ApiActionType.TextAnalyticsKeyphrases] as KeyPhraseServiceConfig;
        //public LanguageServiceConfig LanguageService => Services[ApiActionType.TextAnalyticsLanguages] as LanguageServiceConfig;
        //public TopicServiceConfig TopicService => Services[ApiActionType.TextAnalyticsTopics] as TopicServiceConfig;
        //public OperationStatusServiceConfig OperationStatusService => Services[ApiActionType.TextAnalyticsOperationStatus] as OperationStatusServiceConfig;
        //public EmotionServiceConfig EmotionService => Services[ApiActionType.Emotion] as EmotionServiceConfig;
    }
}

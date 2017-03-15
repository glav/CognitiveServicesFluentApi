using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Configuration
{
    public static class ApiServiceUrlFragments
    {
        public const string BASE_URL_TEMPLATE = "https://{0}.api.cognitive.microsoft.com/";
        public const string TEXT_ANALYTIC_VERSION = "v2.0";

        static ApiServiceUrlFragments()
        {
        }
        public static class TextAnalyticsSentiment
        {
            static TextAnalyticsSentiment()
            {
                Version = TEXT_ANALYTIC_VERSION;
            }
            public const string Template = "text/analytics/{0}/sentiment";
            public static string Version { get; set; }

        }

        public static class TextAnalyticsKeyPhrase
        {
            static TextAnalyticsKeyPhrase()
            {
                Version = TEXT_ANALYTIC_VERSION;
            }
            public const string Template = "text/analytics/{0}/keyPhrases";
            public static string Version { get; set; }

        }

        public static class TextAnalyticsLanguage
        {
            static TextAnalyticsLanguage()
            {
                Version = TEXT_ANALYTIC_VERSION;
            }
            public const string Template = "text/analytics/{0}/languages";
            public static string Version { get; set; }

        }

        public static class TextAnalyticsTopics
        {
            static TextAnalyticsTopics()
            {
                Version = TEXT_ANALYTIC_VERSION;
            }
            public const string Template = "text/analytics/{0}/topics";
            public static string Version { get; set; }

        }

        public static class TextAnalyticsOperationStatus
        {
            static TextAnalyticsOperationStatus()
            {
                Version = TEXT_ANALYTIC_VERSION;
            }
            public const string Template = "text/analytics/{0}/operations";
            public static string Version { get; set; }

        }

        public static class Emotion
        {
            static Emotion()
            {
                Version = "v1.0";
            }
            public const string Template = "emotion/{0}";
            public static string Version { get; set; }
        }
    }
}

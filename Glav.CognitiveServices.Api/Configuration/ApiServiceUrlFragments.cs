using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Configuration
{
    public static class ApiServiceUrlFragments
    {
        public const string BASE_URL_TEMPLATE = "https://{0}.api.cognitive.microsoft.com/";

        static ApiServiceUrlFragments()
        {
        }
        public static class TextAnalyticsSentiment
        {
            static TextAnalyticsSentiment()
            {
                Version = "v2.0";
            }
            public const string Template = "text/analytics/{0}/sentiment";
            public static string Version { get; set; }

        }

        public static class TextAnalyticsKeyPhrase
        {
            static TextAnalyticsKeyPhrase()
            {
                Version = "v2.0";
            }
            public const string Template = "text/analytics/{0}/keyPhrases";
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

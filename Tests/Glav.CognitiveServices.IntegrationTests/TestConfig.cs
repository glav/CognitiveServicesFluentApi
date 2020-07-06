using Microsoft.Extensions.Configuration;
using Microsoft.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace Glav.CognitiveServices.IntegrationTests
{
    public static class TestConfig
    {
        private static object _lockObject = new object();

        private static string _textAnalyticsApiKey;
        private static string _computerVisionApiKey;
        private static string _faceApiKey;
        private static string _luisAppApiKey;
        private static string _luisSubscriptionApiKey;

        public static IConfigurationRoot Configuration { get; set; }

        static TestConfig()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            if (Environment.GetEnvironmentVariable("BuildConfiguration") == "development")
            {
                builder.AddUserSecrets<ComputerVision.ImageAnalysisApiTests>();
            }

            Configuration = builder.Build();

            _textAnalyticsApiKey = GetConfigOrEnvironmentVariable("ApiKeys:TextAnalytics", "TEXTANALYTIC_API_KEY");
            _computerVisionApiKey = GetConfigOrEnvironmentVariable("ApiKeys:ComputerVision", "COMPUTERVISION_API_KEY");
            _faceApiKey = GetConfigOrEnvironmentVariable("ApiKeys:Face", "FACE_API_KEY");
            _luisAppApiKey = GetConfigOrEnvironmentVariable("ApiKeys:LuisApp", "LUIS_APP_API_KEY");
            _luisSubscriptionApiKey = GetConfigOrEnvironmentVariable("ApiKeys:LuisSubscription", "LUIS_SUBSCRIPTION_API_KEY");



        }

        public static string TextAnalyticsApiKey => _textAnalyticsApiKey;
        public static string ComputerVisionApiKey => _computerVisionApiKey;
        public static string FaceApiKey => _faceApiKey;

        public static string LuisAppApiKey => _luisAppApiKey;
        public static string LuisSubscriptionApiKey => _luisSubscriptionApiKey;

        private static string GetConfigOrEnvironmentVariable(string configKey, string envVariable)
        {
            return !string.IsNullOrWhiteSpace(Configuration[configKey]) ? Configuration[configKey] : Environment.GetEnvironmentVariable(envVariable);
        }
    }
}

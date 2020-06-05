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

            _textAnalyticsApiKey = GetConfigOrEnvironmentVariable("ApiKeys:TextAnalytics", "TEXTANALYTIC_API_KEY", "SECRET_TEXTANALYTIC_API_KEY");
            _computerVisionApiKey = GetConfigOrEnvironmentVariable("ApiKeys:ComputerVision", "COMPUTERVISION_API_KEY", "SECRET_COMPUTERVISION_API_KEY");
            _faceApiKey = GetConfigOrEnvironmentVariable("ApiKeys:Face", "FACE_API_KEY", "SECRET_FACE_API_KEY");



        }

        public static string TextAnalyticsApiKey => _textAnalyticsApiKey;
        public static string ComputerVisionApiKey => _computerVisionApiKey;
        public static string FaceApiKey => _faceApiKey;

        private static string GetConfigOrEnvironmentVariable(string configKey, string envVariable1, string envVariable2)
        {
            if (string.IsNullOrWhiteSpace(Configuration[configKey]))
            {
                return Configuration[configKey];
            }
            return string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(envVariable1)) ? Environment.GetEnvironmentVariable(envVariable1) : Environment.GetEnvironmentVariable(envVariable2);
        }
    }
}

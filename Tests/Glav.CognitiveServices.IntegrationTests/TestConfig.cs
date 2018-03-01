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

        public static IConfigurationRoot Configuration { get; set; }

        static TestConfig()
        {
            var builder = new ConfigurationBuilder();
            if (Environment.GetEnvironmentVariable("BuildConfiguration") == "development")
            {
                builder.AddUserSecrets<ComputerVision.ImageAnalysisApiTests>();
            }

            Configuration = builder.Build();
        }

        public static string TextAnalyticsApiKey => Configuration["ApiKeys:TextAnalytics"];
        public static string EmotionApiKey => Configuration["ApiKeys:Emotion"];
        public static string ComputerVisionApiKey => Configuration["ApiKeys:ComputerVision"];
    }
}

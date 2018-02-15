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
            EnsureSetup();
        }
        private static void EnsureSetup()
        {
            if (Configuration == null)
            {
                lock(_lockObject)
                {
                    try
                    {
                        var builder = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .AddEnvironmentVariables();

                        if (Environment.GetEnvironmentVariable("BuildConfiguration") == "development")
                        {
                            //TODO: User secrets - perhaps load in apikeys from environ vars
                        }

                        Configuration = builder.Build();
                        
                    } catch
                    {
                        Debug.WriteLine("No appsettings.json file or it was invalid.");
                    }
                }
            }
        }

        public static string TextAnalyticsApiKey => Configuration["ApiKeys:TextAnalytics"];
        public static string EmotionApiKey => Configuration["ApiKeys:Emotion"];
        public static string ComputerVisionApiKey => Configuration["ApiKeys:ComputerVision"];


    }
}

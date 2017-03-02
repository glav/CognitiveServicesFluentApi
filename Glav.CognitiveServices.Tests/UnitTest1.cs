using Glav.CognitiveServices.Api.Fluent;
using Glav.CognitiveServices.Api.Configuration;
using System;
using Xunit;

namespace Glav.CognitiveServices.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var asyncResult = ConfigurationBuilder.CreateUsingApiKey("....")
                .WithSentimentAnalysis("This is really good.")
                .AnalyseAllAsync().Result;



        }
    }
}

using Glav.CognitiveServices.Api.Fluent;
using System;
using Xunit;

namespace Glav.CognitiveServices.IntegrationTests
{
    public class TextAnalyticApiTests
    {
        [Fact]
        public void SimplePositiveTextShouldAnalyseAsPositive()
        {
            var asyncResult = ConfigurationBuilder.CreateUsingApiKey("....")
                .WithSentimentAnalysis("This is really good.")
                .AnalyseAllAsync().Result;
        }
    }
}

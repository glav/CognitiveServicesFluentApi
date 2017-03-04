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
            var result = ConfigurationBuilder.CreateUsingApiKey("636868abf46c47bc8e92306989e281cd")
                .WithSentimentAnalysis("This is really good.")
                .AnalyseAllAsync().Result;
        }
    }
}

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
            var result = ConfigurationBuilder.CreateUsingApiKey("636868abf46c47bc8e92306989e281cd")
                .WithSentimentAnalysis("This is really good.")
                .Analyse();


        }
    }
}

using Xunit;
using Glav.CognitiveServices.FluentApi.TextAnalytic;
using System;
using System.Collections.Generic;

namespace Glav.CognitiveServices.UnitTests.TextAnalytic
{
    public class TextAnalyticConfigTests
    {
        [Fact]
        public void ShouldProvideValidUrlsForLocationSpecificConfig()
        {
            var expectedList = new List<Tuple<FluentApi.Core.LocationKeyIdentifier, string>>(new[]
            {
                new Tuple<FluentApi.Core.LocationKeyIdentifier, string>(FluentApi.Core.LocationKeyIdentifier.WestUs, "https://westus.api.cognitive.microsoft.com/"),
                new Tuple<FluentApi.Core.LocationKeyIdentifier, string>(FluentApi.Core.LocationKeyIdentifier.AustraliaEast, "https://australiaeast.api.cognitive.microsoft.com/"),
                new Tuple<FluentApi.Core.LocationKeyIdentifier, string>(FluentApi.Core.LocationKeyIdentifier.EastUs2, "https://eastus2.api.cognitive.microsoft.com/"),
                new Tuple<FluentApi.Core.LocationKeyIdentifier, string>(FluentApi.Core.LocationKeyIdentifier.AustraliaSouthEast, "https://australiasoutheast.api.cognitive.microsoft.com/"),
                new Tuple<FluentApi.Core.LocationKeyIdentifier, string>(FluentApi.Core.LocationKeyIdentifier.Global, "https://api.cognitive.microsoft.com/"),
            });

            expectedList.ForEach(i =>
            {
                var config = TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("12345", i.Item1);
                var url = config.BaseUrl;
                Assert.Equal(i.Item2, url);
            });
        }

    }
}

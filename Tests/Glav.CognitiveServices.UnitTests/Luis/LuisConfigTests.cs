using Xunit;
using Glav.CognitiveServices.FluentApi.Luis;
using System;
using System.Collections.Generic;
using Glav.CognitiveServices.FluentApi.Luis.Configuration;
using Glav.CognitiveServices.FluentApi.Luis.Domain;

namespace Glav.CognitiveServices.UnitTests.uis
{
    public class LuisConfigTests
    {
        // [Fact]
        // public void ShouldProvideValidUrlsForLocationSpecificConfig()
        // {
        //     var expectedList = new List<Tuple<FluentApi.Core.LocationKeyIdentifier, string>>(new[]
        //     {
        //         new Tuple<FluentApi.Core.LocationKeyIdentifier, string>(FluentApi.Core.LocationKeyIdentifier.WestUs, "https://westus.api.cognitive.microsoft.com/"),
        //         new Tuple<FluentApi.Core.LocationKeyIdentifier, string>(FluentApi.Core.LocationKeyIdentifier.AustraliaEast, "https://australiaeast.api.cognitive.microsoft.com/"),
        //         new Tuple<FluentApi.Core.LocationKeyIdentifier, string>(FluentApi.Core.LocationKeyIdentifier.EastUs2, "https://eastus2.api.cognitive.microsoft.com/"),
        //         new Tuple<FluentApi.Core.LocationKeyIdentifier, string>(FluentApi.Core.LocationKeyIdentifier.AustraliaSouthEast, "https://australiasoutheast.api.cognitive.microsoft.com/"),
        //         new Tuple<FluentApi.Core.LocationKeyIdentifier, string>(FluentApi.Core.LocationKeyIdentifier.Global, "https://api.cognitive.microsoft.com/"),
        //     });

        //     expectedList.ForEach(i =>
        //     {
        //         var config = uisConfigurationSettings.CreateUsingConfigurationKeys("12345", i.Item1);
        //         var url = config.BaseUrl;
        //         Assert.Equal(i.Item2, url);
        //     });
        // }

        [Fact]
        public void ShouldHaveDefinedUrisForuisActions()
        {
            // Get our text analytic config
            var uriLocations = new Glav.CognitiveServices.FluentApi.Luis.Configuration.ApiServiceUriCollection();

            Assert.NotNull(uriLocations.GetServiceConfig(LuisAnalysisApiOperations.LuisAnalysis));
            const string expected = "luis/prediction/v3.0/apps";
            var actual = uriLocations.GetServiceConfig(LuisAnalysisApiOperations.LuisAnalysis).ServiceUri;
            Assert.Equal(actual,expected);
        }
    }
}

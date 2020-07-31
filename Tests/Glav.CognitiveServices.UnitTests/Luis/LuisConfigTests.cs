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

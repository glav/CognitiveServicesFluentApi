using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Luis;
using Glav.CognitiveServices.FluentApi.Luis.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Glav.CognitiveServices.UnitTests.Luis
{
    public class LuisUrlTests
    {
        [Fact]
        public void ShouldParseFaceDetectionResultSuccessfully()
        {
            const string appId = "APPID";
            const string subKey = "SUBKEY";
            var actionItem = new LuisAppActionDataItem(1,appId,subKey,"123");
            var config = new LuisConfigurationSettings(appId,subKey, LocationKeyIdentifier.AustraliaEast);
            var actual = config.GetAbsoluteUrlForApiAction(actionItem);
            Assert.Equal("https://australiaeast.api.cognitive.microsoft.com/luis/prediction/v3.0/apps/APPID/slots/staging/predict?subscription-key=SUBKEY&verbose=True&show-all-intents=True&log=True&query=123", actual);
        }
    }
}

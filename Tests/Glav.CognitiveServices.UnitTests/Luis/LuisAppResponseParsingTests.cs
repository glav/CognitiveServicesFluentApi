using Glav.CognitiveServices.FluentApi.Luis.Domain;
using Glav.CognitiveServices.UnitTests.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Glav.CognitiveServices.UnitTests.Luis
{
    public class LuisAppResponseParsingTests
    {
        private TestDataHelper _helper = new TestDataHelper();

        [Fact]
        public void ShouldParseLuisAppResultSuccessfully()
        {
            var input = _helper.GetFileDataEmbeddedInAssembly("LuisAppResponse.json");
            var result = new LuisAppAnalysisResult(new MockCommsResult(input));

            Assert.NotNull(result);
            Assert.NotNull(result.ApiCallResult);
            Assert.True(result.ActionSubmittedSuccessfully);
            Assert.NotNull(result.ResponseData);
            Assert.Null(result.ResponseData.error);
            Assert.NotEmpty(result.ResponseData.query);
            Assert.NotNull(result.ResponseData.prediction);
            Assert.NotNull(result.ResponseData.prediction.intents);
            Assert.NotNull(result.ResponseData.prediction.entities);
        }

    }

}

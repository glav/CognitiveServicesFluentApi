using Glav.CognitiveServices.FluentApi.Luis.Domain;
using Glav.CognitiveServices.UnitTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Assert.NotNull(result.ResponseData.prediction.intents.Length > 0);
            Assert.True(result.ResponseData.prediction.intents.All(i => i.score > 0),"All scores should report as non zero for this response data");
            Assert.NotNull(result.ResponseData.prediction.entityInstanceList.entityIdentifiers.Length > 0);
            Assert.False(result.ResponseData.prediction.entityInstanceList.entityIdentifiers
                            .SelectMany(e => e.entities)
                            .Any(i => string.IsNullOrWhiteSpace(i)),"All entities should be not blank or empty forthis response data");
        }

    }

}

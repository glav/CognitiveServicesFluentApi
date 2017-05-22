using Xunit;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.TextAnalytic;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;
using Glav.CognitiveServices.UnitTests.Helpers;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core;

namespace Glav.CognitiveServices.UnitTests.TextAnalytic
{
    public class TextAnalyticParsingTests
    {
        private TestDataHelper _dataHelper = new TestDataHelper();

        [Fact]
        public void ShouldParseResultSuccessfully()
        {
            var input = "{\"documents\":[{\"score\":0.7988085,\"id\":\"1\"}],\"errors\":[]}";
            var result = new SentimentResult(new MockCommsResult(input));

            Assert.NotNull(result);
            Assert.NotNull(result.ApiCallResult);
            Assert.True(result.ActionSubmittedSuccessfully);
            Assert.NotNull(result.ResponseData);
            Assert.NotEmpty(result.ResponseData.documents);
            Assert.Equal<long>(1, result.ResponseData.documents[0].id);
            Assert.Equal<double>(0.7988085, result.ResponseData.documents[0].score);
            Assert.Empty(result.ResponseData.errors);
        }

        [Fact]
        public async Task ShouldParseTopicResultWithSucceededResponseAsync()
        {
            var testData = _dataHelper.GetFileDataEmbeddedInAssembly("topic-api-raw-result.json");

            var config = TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("test", LocationKeyIdentifier.WestUs)
                .UsingCustomCommunication(new MockCommsEngine(new MockCommsResult(testData)))
                .WithTextAnalyticAnalysisActions()
                .AddKeyTopicAnalysis(testData);
            var analysisResult = await config.AnalyseAllSentimentsAsync();
            var checkResult = await analysisResult.CheckTopicAnalysisStatusAsync();

            Assert.NotNull(checkResult);
            Assert.Equal(OperationStateType.CompletedSuccessfully, checkResult.OperationState);

        }
    }
}

using Glav.CognitiveServices.FluentApi.TextAnalytic.Fluent;
using Xunit;
using System.Reflection;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;

namespace Glav.CognitiveServices.UnitTests.TextAnalytic
{
    public class TextAnalyticParsingTests
    {
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
            var asm = this.GetType().GetTypeInfo().Assembly;
            string testData;
            using (var stream = asm.GetManifestResourceStream("Glav.CognitiveServices.UnitTests.TestData.topic-api-raw-result.json"))
            {
                using (var sr = new System.IO.StreamReader(stream))
                {
                    testData = sr.ReadToEnd();
                }
            }

            var config = TextAnalyticConfigurationSettings.CreateUsingApiKey("test")
                .UsingCustomCommunication(new MockCommsEngine(new MockCommsResult(testData)))
                .WithKeyTopicAnalysis(testData);


            var analysisResult = await config.AnalyseAllSentimentsAsync();
            var checkResult = await analysisResult.CheckTopicAnalysisStatusAsync();

            Assert.NotNull(checkResult);
            Assert.Equal(OperationStateType.CompletedSuccessfully, checkResult.OperationState);

        }
    }
}

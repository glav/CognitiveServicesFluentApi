using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace Glav.CognitiveServices.IntegrationTests.TextAnalytic
{
    public class TopicAnalysisApiTests
    {


        [Fact]
        public async Task SimpleTopicsShouldAnalyseAndBeDetected()
        {
            var config = TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.TextAnalyticsApiKey, LocationKeyIdentifier.WestUs)
                .UsingHttpCommunication()
                .WithTextAnalyticAnalysisActions();

            var asm = this.GetType().GetTypeInfo().Assembly;
            string testData;
            using (var stream = asm.GetManifestResourceStream("Glav.CognitiveServices.IntegrationTests.TestData.SampleTopicText.txt"))
            {
                using (var sr = new System.IO.StreamReader(stream))
                {
                    testData = sr.ReadToEnd();
                }
            }
            //Build up at least 100 documents as the service requires a minimum of 100
            config.AddKeyTopicAnalysisSplittingDataIntoSentences(testData);

            var analysisResult = await config.AnalyseAllSentimentsAsync();

            Assert.NotNull(analysisResult);
            Assert.NotNull(analysisResult.TextAnalyticTopicAnalysis);
            Assert.NotNull(analysisResult.TextAnalyticTopicAnalysis.AnalysisResult);
            Assert.NotNull(analysisResult.TextAnalyticTopicAnalysis.AnalysisResult.ResponseData);
            Assert.NotNull(analysisResult.TextAnalyticTopicAnalysis.AnalysisResult.ApiCallResult.OperationLocationUri);

            var checkResult = await analysisResult.CheckTopicAnalysisStatusAsync();

            Assert.NotNull(checkResult);
            Assert.True(checkResult.ActionSubmittedSuccessfully);
            Assert.Equal(OperationStateType.NotStarted, checkResult.OperationState);

            var waitForResult = await analysisResult.WaitForTopicAnalysisToCompleteAsync();

            Assert.NotNull(waitForResult);
            Assert.True(waitForResult.ActionSubmittedSuccessfully);
            Assert.Equal(OperationStateType.CompletedSuccessfully, waitForResult.OperationState);

        }
    }
}
 
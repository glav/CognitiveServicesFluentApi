using Xunit;
using Glav.CognitiveServices.UnitTests.Helpers;
using Glav.CognitiveServices.FluentApi.Core;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Face;

namespace Glav.CognitiveServices.UnitTests.TextAnalytic
{
    public class LargePersonGroupTests
    {
        private TestDataHelper _helper = new TestDataHelper();

        [Fact]
        public async Task ShouldParseFaceDetectionResultSuccessfully()
        {
            var commsEngine = new MockCommsEngine(new MockCommsResult(null, System.Net.HttpStatusCode.OK));
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.AustraliaEast)
                .AddConsoleDiagnosticLogging()
                .UsingCustomCommunication(commsEngine)
                .WithFaceAnalysisActions()
                .DeleteLargePersonGroup("123")
                .AnalyseAllAsync();

            Assert.NotNull(result.LargePersonGroupDeleteAnalysis);
            Assert.NotNull(result.LargePersonGroupDeleteAnalysis.AnalysisResult);
            Assert.NotNull(result.LargePersonGroupDeleteAnalysis.AnalysisResult.ApiCallResult);
            Assert.True(result.LargePersonGroupDeleteAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.True(result.LargePersonGroupDeleteAnalysis.IsSuccessfull());
        }

    }

}

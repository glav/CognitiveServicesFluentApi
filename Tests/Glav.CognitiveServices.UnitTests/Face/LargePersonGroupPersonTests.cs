using Xunit;
using Glav.CognitiveServices.UnitTests.Helpers;
using Glav.CognitiveServices.FluentApi.Core;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Face;

namespace Glav.CognitiveServices.UnitTests.TextAnalytic
{
    public class LargePersonGroupPersonTests
    {
        private TestDataHelper _helper = new TestDataHelper();

        [Fact]
        public async Task ShouldParseLargePersonGroupPersonDeleteResultSuccessfully()
        {
            var commsEngine = new MockCommsEngine(new MockCommsResult(null, System.Net.HttpStatusCode.OK));
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.AustraliaEast)
                .AddConsoleDiagnosticLogging()
                .UsingCustomCommunication(commsEngine)
                .WithFaceAnalysisActions()
                .DeleteLargePersonGroupPerson("123","456")
                .AnalyseAllAsync();

            Assert.NotNull(result.LargePersonGroupPersonDeleteAnalysis);
            Assert.NotNull(result.LargePersonGroupPersonDeleteAnalysis.AnalysisResult);
            Assert.NotNull(result.LargePersonGroupPersonDeleteAnalysis.AnalysisResult.ApiCallResult);
            Assert.True(result.LargePersonGroupPersonDeleteAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.True(result.LargePersonGroupPersonDeleteAnalysis.IsSuccessfull());
        }

        [Fact]
        public async Task ShouldParseLargePersonGroupPersonCreateResultSuccessfully()
        {
            const string returnData = "{    \"personId\": \"25985303-c537-4467-b41d-bdb45cd95ca1\"  }";
            var commsEngine = new MockCommsEngine(new MockCommsResult(returnData));
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.AustraliaEast)
                .AddConsoleDiagnosticLogging()
                .UsingCustomCommunication(commsEngine)
                .WithFaceAnalysisActions()
                .CreateLargePersonGroupPerson("123", "unittest","unittest-data")
                .AnalyseAllAsync();

            Assert.NotNull(result.LargePersonGroupPersonCreateAnalysis);
            Assert.NotNull(result.LargePersonGroupPersonCreateAnalysis.AnalysisResult);
            Assert.NotNull(result.LargePersonGroupPersonCreateAnalysis.AnalysisResult.ApiCallResult);
            Assert.True(result.LargePersonGroupPersonCreateAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.NotNull(result.LargePersonGroupPersonCreateAnalysis.AnalysisResult.ResponseData);
            Assert.NotNull(result.LargePersonGroupPersonCreateAnalysis.AnalysisResult.ResponseData.personId);
        }

    }

}

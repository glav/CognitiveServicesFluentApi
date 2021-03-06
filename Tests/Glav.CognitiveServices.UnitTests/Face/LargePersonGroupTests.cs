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
        public async Task ShouldParseLargePersonGroupDeleteResultSuccessfully()
        {
            var commsEngine = new MockCommsEngine(new MockCommsResult(null, System.Net.HttpStatusCode.OK));
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.AustraliaEast)
                .AddConsoleDiagnosticLogging()
                .UsingCustomCommunication(commsEngine)
                .WithFaceAnalysisActions()
                .DeleteLargePersonGroup("123")
                .AnalyseAllAsync();

            result.LargePersonGroupDeleteAnalysis.AssertAnalysisContextValidity();
            Assert.True(result.LargePersonGroupDeleteAnalysis.IsSuccessfull());
        }

        [Fact]
        public async Task ShouldParseLargePersonGroupCreateResultSuccessfully()
        {
            var commsEngine = new MockCommsEngine(new MockCommsResult(null, System.Net.HttpStatusCode.OK));
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.AustraliaEast)
                .AddConsoleDiagnosticLogging()
                .UsingCustomCommunication(commsEngine)
                .WithFaceAnalysisActions()
                .CreateLargePersonGroup("123","unittest","unittest-data")
                .AnalyseAllAsync();

            result.LargePersonGroupCreateAnalysis.AssertAnalysisContextValidity();
            Assert.True(result.LargePersonGroupCreateAnalysis.IsSuccessfull());
        }

    }

}

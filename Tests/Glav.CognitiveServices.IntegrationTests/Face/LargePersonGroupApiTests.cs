using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Face;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Glav.CognitiveServices.IntegrationTests.Helpers;
using Glav.CognitiveServices.FluentApi.Face.Domain;

namespace Glav.CognitiveServices.IntegrationTests.ComputerVision
{
    public class LargePersonGroupApiTests
    {
        private TestDataHelper _testDataHelper = new TestDataHelper();
        [Fact]
        public async Task FaceDataShouldBeProvidedWhenRequestedAsPartOfAnalysisForUrlAnalysis()
        {
            var groupId = System.Guid.NewGuid().ToString();
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .CreateLargePersonGroup(groupId,$"Unittest-{groupId}")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.LargePersonGroupCreateAnalysis);
            Assert.NotNull(result.LargePersonGroupCreateAnalysis.AnalysisResult);
            Assert.NotNull(result.LargePersonGroupCreateAnalysis.AnalysisResult.ApiCallResult);
            Assert.NotNull(result.LargePersonGroupCreateAnalysis.AnalysisResult.ResponseData);
            Assert.True(result.LargePersonGroupCreateAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
        }


    }
}

using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Face;
using Glav.CognitiveServices.IntegrationTests.Helpers;
using System.Threading.Tasks;
using Xunit;

namespace Glav.CognitiveServices.IntegrationTests.ComputerVision
{
    public class LargePersonGroupFaceApiTests
    {
        private TestDataHelper _testDataHelper = new TestDataHelper();
        [Fact]
        public async Task ShouldBeAbleToTrainLargePersonGroupWithFaces()
        {
            var groupId = System.Guid.NewGuid().ToString();
            var personName = $"Person-{groupId}";

            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                .AddConsoleAndTraceLogging()
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .CreateLargePersonGroup(groupId, $"test-{groupId}")
                .CreateLargePersonGroupPerson(groupId, personName, "Used for integration testing only - can be deleted")
                .AnalyseAllAsync();
            
            Assert.NotNull(result);
            result.LargePersonGroupCreateAnalysis.AssertAnalysisContextValidity();
            result.LargePersonGroupPersonCreateAnalysis.AssertAnalysisContextValidity();
            var personId = result.LargePersonGroupPersonCreateAnalysis.AnalysisResult.ResponseData.personId;

            var addFaceResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                            .AddConsoleAndTraceLogging()
                            .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                            .UsingHttpCommunication()
                            .WithFaceAnalysisActions()
                            .AddFaceToPersonGroupPerson(groupId, personId, new System.Uri("http://www.scface.org/examples/001_frontal.jpg"))
                            .AnalyseAllAsync();

            addFaceResult.LargePersonGroupPersonFaceAddAnalysis.AssertAnalysisContextValidity();

            var faceResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                            .AddConsoleAndTraceLogging()
                            .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                            .UsingHttpCommunication()
                            .WithFaceAnalysisActions()
                           .StartTrainingLargePersonGroup(groupId)
                           .CheckTrainingStatusLargePersonGroup(groupId)
                           .AnalyseAllAsync();

            await faceResult.WaitForTrainingToCompleteAsync(new System.Threading.CancellationToken());

            Assert.NotNull(faceResult);
            faceResult.LargePersonGroupTrainStartAnalysis.AssertAnalysisContextValidity();
            faceResult.LargePersonGroupTrainStatusAnalysis.AssertAnalysisContextValidity();
            Assert.True(faceResult.IsTrainingSuccessful());

            var deleteResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                    .AddConsoleAndTraceLogging()
                    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                    .UsingHttpCommunication()
                    .WithFaceAnalysisActions()
                    .DeleteLargePersonGroupPerson(groupId,personId)
                    .DeleteLargePersonGroup(groupId)
                    .AnalyseAllAsync();

            deleteResult.LargePersonGroupPersonDeleteAnalysis.AssertAnalysisContextValidity();
            deleteResult.LargePersonGroupDeleteAnalysis.AssertAnalysisContextValidity();
        }

    }
}

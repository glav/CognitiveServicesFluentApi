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
    public class FaceIdentificationApiTests
    {
        private TestDataHelper _testDataHelper = new TestDataHelper();
        [Fact]
        public async Task FaceDataShouldBeProvidedWhenRequestedAsPartOfAnalysisForUrlAnalysis()
        {
            var setupResult = await _testDataHelper.EnsureLargePersonGroupIsSetupAsync();
            if (!setupResult.Success)
            {
                Assert.True(false, "Setup person group person failed");
            }
            var personId = setupResult.PersonId;
            var groupId = setupResult.GroupId;

            // Add some faces to the person in the group
            var addFaceResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                            .AddConsoleAndTraceLogging()
                            .SetDiagnosticLoggingLevel(LoggingLevel.ErrorsOnly)
                            .UsingHttpCommunication()
                            .WithFaceAnalysisActions()
                            .AddFaceToPersonGroupPerson(TestDataHelper.GroupId, personId, new System.Uri("http://www.scface.org/examples/001_frontal.jpg"))
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

        }


    }
}

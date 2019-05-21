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

            // Change this once on master branch
            const string baseImageUrl = "https://raw.githubusercontent.com/glav/CognitiveServicesFluentApi/glav/PersonGroupSupport/Tests/Glav.CognitiveServices.IntegrationTests/TestData/";

            // Add some faces to the person in the group
            var addFaceResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                            .AddConsoleAndTraceLogging()
                            .SetDiagnosticLoggingLevel(LoggingLevel.ErrorsOnly)
                            .UsingHttpCommunication()
                            .WithFaceAnalysisActions()
                            .AddFaceToPersonGroupPerson(TestDataHelper.GroupId, personId, new System.Uri($"{baseImageUrl}me1.jpg"))
                            .AddFaceToPersonGroupPerson(TestDataHelper.GroupId, personId, new System.Uri($"{baseImageUrl}me2.jpg"))
                            .AddFaceToPersonGroupPerson(TestDataHelper.GroupId, personId, new System.Uri($"{baseImageUrl}me3.jpg"))
                            .AddFaceToPersonGroupPerson(TestDataHelper.GroupId, personId, new System.Uri($"{baseImageUrl}me4.jpg"))
                           .StartTrainingLargePersonGroup(groupId)
                           .CheckTrainingStatusLargePersonGroup(groupId)
                            .AnalyseAllAsync();

            addFaceResult.LargePersonGroupPersonFaceAddAnalysis.AssertAnalysisContextValidity();

            await addFaceResult.WaitForTrainingToCompleteAsync(new System.Threading.CancellationToken());

            addFaceResult.LargePersonGroupTrainStartAnalysis.AssertAnalysisContextValidity();
            addFaceResult.LargePersonGroupTrainStatusAnalysis.AssertAnalysisContextValidity();

            Assert.True(addFaceResult.IsTrainingSuccessful());

        }


    }
}

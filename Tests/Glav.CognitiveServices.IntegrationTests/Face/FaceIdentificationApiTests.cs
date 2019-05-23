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

            var listFaceResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                .AddConsoleAndTraceLogging()
                .SetDiagnosticLoggingLevel(LoggingLevel.ErrorsOnly)
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .ListLargePersonGroupPersons(groupId)
                .AnalyseAllAsync();

            listFaceResult.LargePersonGroupPersonListAnalysis.AssertAnalysisContextValidity();
            const string baseImageUrl = "https://raw.githubusercontent.com/glav/CognitiveServicesFluentApi/glav/PersonGroupSupport/Tests/Glav.CognitiveServices.IntegrationTests/TestData/";

            // Only add in faces if we have to
            if (listFaceResult.LargePersonGroupPersonListAnalysis.AnalysisResult.ResponseData.LargePersonGroupPersons == null ||
                listFaceResult.LargePersonGroupPersonListAnalysis.AnalysisResult.ResponseData.LargePersonGroupPersons.Length == 0 ||
                listFaceResult.LargePersonGroupPersonListAnalysis.AnalysisResult.ResponseData.LargePersonGroupPersons[0].persistedFaceIds == null ||
                listFaceResult.LargePersonGroupPersonListAnalysis.AnalysisResult.ResponseData.LargePersonGroupPersons[0].persistedFaceIds.Length == 0)
            {
                // Change this once on master branch

                // Add some faces to the person in the group
                var addFaceResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                                .AddConsoleAndTraceLogging()
                                .SetDiagnosticLoggingLevel(LoggingLevel.ErrorsOnly)
                                .UsingHttpCommunication()
                                .WithFaceAnalysisActions()
                                .AddFaceToPersonGroupPerson(TestDataHelper.GroupId, personId, new System.Uri($"{baseImageUrl}me1.jpg"))
                                .AddFaceToPersonGroupPerson(TestDataHelper.GroupId, personId, new System.Uri($"{baseImageUrl}me2.jpg"))
                                .AddFaceToPersonGroupPerson(TestDataHelper.GroupId, personId, new System.Uri($"{baseImageUrl}Me3.jpg"))
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

            // Detect a face to identify against and grab the face Id
            var addFaceTestResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                .AddConsoleAndTraceLogging()
                .SetDiagnosticLoggingLevel(LoggingLevel.ErrorsOnly)
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .AddUriForFaceDetection(new System.Uri($"{baseImageUrl}me5.jpg"), FaceDetectionAttributes.Age)
               .StartTrainingLargePersonGroup(groupId)
               .CheckTrainingStatusLargePersonGroup(groupId)
                .AnalyseAllAsync();

            Assert.True(addFaceTestResult.FaceDetectionAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            var faceId = addFaceTestResult.FaceDetectionAnalysis.AnalysisResult.ResponseData.detectedFaces.First().faceId;


            var identifyResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                            .AddConsoleAndTraceLogging()
                            .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                            .UsingHttpCommunication()
                            .WithFaceAnalysisActions()
                            .IdentifyFace(groupId, faceId)
                            .AnalyseAllAsync();

            identifyResult.FaceIdentificationAnalysis.AssertAnalysisContextValidity();
            Assert.NotNull(identifyResult.FaceIdentificationAnalysis);
            Assert.NotEmpty(identifyResult.FaceIdentificationAnalysis.AnalysisResults);
            Assert.True(identifyResult.FaceIdentificationAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.NotNull(identifyResult.FaceIdentificationAnalysis.AnalysisResult.ResponseData);
            Assert.NotEmpty(identifyResult.FaceIdentificationAnalysis.AnalysisResult.ResponseData.identifiedFaces);
            Assert.NotEmpty(identifyResult.FaceIdentificationAnalysis.AnalysisResult.ResponseData.identifiedFaces[0].candidates);

            var returnedFace = identifyResult.FaceIdentificationAnalysis.AnalysisResult.ResponseData.identifiedFaces[0].candidates[0];
            Assert.Equal(personId, returnedFace.personId);
        }


    }
}

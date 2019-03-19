    using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Face;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Glav.CognitiveServices.IntegrationTests.Helpers;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using System.Net;

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

            var config = FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithFaceAnalysisActions();

            var result = await config
                .CreateLargePersonGroup(groupId,$"test-{groupId}")
                .CreateLargePersonGroupPerson(groupId,personName,"Used for integration testing only - can be deleted")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            result.LargePersonGroupCreateAnalysis.AssertAnalysisContextValidity();
            result.LargePersonGroupPersonCreateAnalysis.AssertAnalysisContextValidity();
            var personId = result.LargePersonGroupPersonCreateAnalysis.AnalysisResult.ResponseData.personId;

            var ListResult = await config
                            .AddFaceToPersonGroupPerson(groupId, personId, new System.Uri("http://www.scface.org/examples/001_frontal.jpg"))
                            .AnalyseAllAsync();

            var faceResult = await config
                           .StartTrainingLargePersonGroup(groupId)
                           .CheckTrainingStatusLargePersonGroup(groupId)
                           .AnalyseAllAsync();

            await faceResult.WaitForTrainingToCompleteAsync(new System.Threading.CancellationToken());

            Assert.NotNull(faceResult);
            faceResult.LargePersonGroupPersonFaceAddAnalysis.AssertAnalysisContextValidity();
            faceResult.LargePersonGroupTrainStartAnalysis.AssertAnalysisContextValidity();
            faceResult.LargePersonGroupTrainStatusAnalysis.AssertAnalysisContextValidity();
            Assert.True(faceResult.IsTrainingSuccessful());


        }

      
    }
}

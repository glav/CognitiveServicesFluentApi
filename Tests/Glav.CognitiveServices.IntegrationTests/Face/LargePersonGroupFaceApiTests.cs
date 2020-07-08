using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Face;
using Glav.CognitiveServices.IntegrationTests.Helpers;
using System.Threading.Tasks;
using Xunit;

namespace Glav.CognitiveServices.IntegrationTests.Face
{
    public class LargePersonGroupFaceApiTests
    {
        [Fact]
        public async Task ShouldBeAbleToTrainLargePersonGroupWithFaces()
        {
            var groupId = System.Guid.NewGuid().ToString();

            var setupResult = await FaceTestHelper.EnsureLargePersonGroupIsSetupAsync(groupId);
            if (!setupResult.Success)
            {
                Assert.True(false, "Setup person group person failed");
            }
            var personId = setupResult.PersonId;

            var addFaceResult = await FaceTestHelper.CreateFaceConfig()
                            .AddConsoleAndTraceLogging()
                            .SetDiagnosticLoggingLevel(LoggingLevel.ErrorsOnly)
                            .UsingHttpCommunication()
                            .WithFaceAnalysisActions()
                            .AddFaceToPersonGroupPerson(groupId, personId, new System.Uri("http://www.scface.org/examples/001_frontal.jpg"))
                            .AnalyseAllAsync();

            addFaceResult.LargePersonGroupPersonFaceAddAnalysis.AssertAnalysisContextValidity();

            var faceResult = await FaceTestHelper.CreateFaceConfig()
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

            var deleteResult = await FaceTestHelper.CreateFaceConfig()
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

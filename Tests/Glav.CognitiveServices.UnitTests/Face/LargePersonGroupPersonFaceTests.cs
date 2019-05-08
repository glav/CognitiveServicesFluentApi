using Xunit;
using Glav.CognitiveServices.UnitTests.Helpers;
using Glav.CognitiveServices.FluentApi.Core;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Face;
using System.Linq;

namespace Glav.CognitiveServices.UnitTests.TextAnalytic
{
    public class LargePersonGroupPersonFaceTests
    {
        [Fact]
        public async Task ShouldParseLargePersonGroupPersonFaceGetResultSuccessfully()
        {
            const string resultData = "{    \"persistedFaceId\": \"015839fb-fbd9-4f79-ace9-7675fc2f1dd9\", " +
                "\"userData\": \"User-provided data attached to the person face.\"}";

            var commsEngine = new MockCommsEngine(new MockCommsResult(resultData));
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.AustraliaEast)
                .AddConsoleDiagnosticLogging()
                .UsingCustomCommunication(commsEngine)
                .WithFaceAnalysisActions()
                .GetFaceForPersonGroupPerson("group-id","person-id","some-id")
                .AnalyseAllAsync();

            result.LargePersonGroupPersonFaceGetAnalysis.AssertAnalysisContextValidity();
            Assert.Equal("015839fb-fbd9-4f79-ace9-7675fc2f1dd9", result.LargePersonGroupPersonFaceGetAnalysis.AnalysisResults[0].ResponseData.persistedFaceId);
            Assert.Equal("User-provided data attached to the person face.", result.LargePersonGroupPersonFaceGetAnalysis.AnalysisResults[0].ResponseData.userData);
        }

        [Fact]
        public async Task ShouldParseLargePersonGroupPersonFaceDeleteResultSuccessfully()
        {
            var commsEngine = new MockCommsEngine(new MockCommsResult(null,System.Net.HttpStatusCode.OK));
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.AustraliaEast)
                .AddConsoleDiagnosticLogging()
                .UsingCustomCommunication(commsEngine)
                .WithFaceAnalysisActions()
                .DeleteFaceForPersonGroupPerson("group-id", "person-id","persisted face id")
                .AnalyseAllAsync();

            result.LargePersonGroupPersonFaceDeleteAnalysis.AssertAnalysisContextValidity();
        }

        [Fact]
        public async Task ShouldDetectTrainingCompleted()
        {
            const string resultData = "{\"status\":\"running\",\"createdDateTime\":\"2019-03-28T06:51:39.1054821Z\",\"lastActionDateTime\":\"2019-03-28T06:51:39.1054821Z\",\"message\":null}";

            var commsEngine = new MockCommsEngine(new MockCommsResult(resultData));
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.AustraliaEast)
                .AddConsoleDiagnosticLogging()
                .UsingCustomCommunication(commsEngine)
                .WithFaceAnalysisActions()
                .CheckTrainingStatusLargePersonGroup("group-id")
                .AnalyseAllAsync();

            result.LargePersonGroupTrainStatusAnalysis.AssertAnalysisContextValidity();
            Assert.False(result.IsTrainingComplete());
        }

    }
}

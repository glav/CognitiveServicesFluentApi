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
        private TestDataHelper _helper = new TestDataHelper();

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
    }
}

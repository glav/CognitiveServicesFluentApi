using Xunit;
using Glav.CognitiveServices.UnitTests.Helpers;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Extensions;
using Glav.CognitiveServices.FluentApi.Face;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.UnitTests.Core
{
    public class CommunicationsTests
    {

        [Fact]
        public async Task ShouldReturnHandledFailureWhenDownstreamApiCallBlowsUp()
        {
            var commsEngine = new MockCommsEngine(new MockCommsResult(null, System.Net.HttpStatusCode.OK),true);
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.AustraliaEast)
                .AddConsoleDiagnosticLogging()
                .UsingCustomCommunication(commsEngine)
                .WithFaceAnalysisActions()
                .DeleteFaceForPersonGroupPerson("group-id", "person-id", "persisted face id")
                .AnalyseAllAsync();

            Assert.False(result.LargePersonGroupPersonFaceDeleteAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
        }

    }
}

using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Luis;
using Glav.CognitiveServices.FluentApi.Luis.Domain;
using Glav.CognitiveServices.UnitTests.Helpers;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Glav.CognitiveServices.UnitTests.Luis
{

    public class LuisExtensionTests
    {
        private TestDataHelper _helper = new TestDataHelper();
        private string _inputData;

        public LuisExtensionTests()
        {
            _inputData = _helper.GetFileDataEmbeddedInAssembly("LuisAppResponse.json");
        }
        [Fact]
        public async Task ShouldGetTopIntents()
        {
            
            var result = await LuisConfigurationSettings.CreateUsingConfigurationKeys("APPID", "sub-key",LocationKeyIdentifier.AustraliaEast)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddConsoleAndTraceLogging()
                .UsingCustomCommunication(new MockCommsEngine(new MockCommsResult(_inputData)))
                .WithLuisAnalysisActions()
                .AddLuisAnalysis("whatevs")
                .AnalyseAllAsync();

            var topIntents = result.LuisAppAnalysis.GetTopIntents();
            Assert.NotEmpty(topIntents);
            Assert.Equal(1, topIntents.Count());
            Assert.Equal("Find Cloud based resources", topIntents.First());
        }
    }
}

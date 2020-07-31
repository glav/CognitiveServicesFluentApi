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

        [Fact]
        public async Task ShouldGetEntities()
        {

            var result = await LuisConfigurationSettings.CreateUsingConfigurationKeys("APPID", "sub-key", LocationKeyIdentifier.AustraliaEast)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddConsoleAndTraceLogging()
                .UsingCustomCommunication(new MockCommsEngine(new MockCommsResult(_inputData)))
                .WithLuisAnalysisActions()
                .AddLuisAnalysis("whatevs")
                .AnalyseAllAsync();

            var entities = result.LuisAppAnalysis.GetEntities();
            Assert.NotEmpty(entities);
            var entityList = entities.ToList();
            Assert.Equal(2, entityList.Count);
            Assert.Equal("cloud", entityList[0].entityIdentifier);
            Assert.NotEmpty(entityList[0].entities);
            Assert.NotEmpty(entityList[1].entities);
            Assert.Equal("azure",entityList[0].entities[0]);

            Assert.Equal("resourceToSearchFor", entityList[1].entityIdentifier);
            Assert.Equal("arm templates", entityList[1].entities[0]);
            Assert.Equal("scripts", entityList[1].entities[1]);
        }

        [Fact]
        public async Task ShouldGetIntents()
        {

            var result = await LuisConfigurationSettings.CreateUsingConfigurationKeys("APPID", "sub-key", LocationKeyIdentifier.AustraliaEast)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddConsoleAndTraceLogging()
                .UsingCustomCommunication(new MockCommsEngine(new MockCommsResult(_inputData)))
                .WithLuisAnalysisActions()
                .AddLuisAnalysis("whatevs")
                .AnalyseAllAsync();

            var intents = result.LuisAppAnalysis.GetIntents();
            Assert.NotEmpty(intents);
            var intentList = intents.ToList();
            Assert.Equal(2, intentList.Count);
            Assert.Equal("Find Cloud based resources", intentList[0].intent);
            Assert.Equal("None", intentList[1].intent);
            Assert.Equal(0.9956735, intentList[0].score);
            Assert.Equal(0.00427947845, intentList[1].score);
        }
    }
}

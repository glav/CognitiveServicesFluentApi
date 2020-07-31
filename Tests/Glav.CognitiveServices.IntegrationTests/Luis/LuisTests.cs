using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Luis;
using Glav.CognitiveServices.IntegrationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Glav.CognitiveServices.IntegrationTests.Luis
{
    
    public class LuisTests
    {
        [Fact]
        public async Task ShouldInterpretPhrase()
        {
            const string query = "Where can I find example ARM Templates";
            const string mainIntent = "Find Cloud based resources";

            var result = await LuisConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.LuisAppApiKey,TestConfig.LuisSubscriptionApiKey, LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithLuisAnalysisActions()
                .AddLuisAnalysis(query)
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.LuisAppAnalysis);
            result.LuisAppAnalysis.AssertAnalysisContextValidity();
            Assert.True(result.LuisAppAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.Equal(query,result.LuisAppAnalysis.AnalysisResult.ResponseData.query);
            Assert.Equal(mainIntent, result.LuisAppAnalysis.AnalysisResult.ResponseData.prediction.topIntent);
            Assert.NotEmpty(result.LuisAppAnalysis.AnalysisResult.ResponseData.prediction.intents);
            Assert.True(result.LuisAppAnalysis.AnalysisResult.ResponseData.prediction.intents.Length == 2);
            Assert.Equal(mainIntent, result.LuisAppAnalysis.AnalysisResult.ResponseData.prediction.intents[0].intent);
            Assert.True(result.LuisAppAnalysis.AnalysisResult.ResponseData.prediction.intents[0].score > 0.5);
            Assert.Equal("None", result.LuisAppAnalysis.AnalysisResult.ResponseData.prediction.intents[1].intent);
            
            Assert.NotEmpty(result.LuisAppAnalysis.AnalysisResult.ResponseData.prediction.entityInstanceList.entityIdentifiers);
            Assert.NotEmpty(result.LuisAppAnalysis.AnalysisResult.ResponseData.prediction.entityInstanceList.entityIdentifiers[0].entities);
            Assert.Equal("ARM Templates",result.LuisAppAnalysis.AnalysisResult.ResponseData.prediction.entityInstanceList.entityIdentifiers[0].entities[0]);
            

        }
    }
}

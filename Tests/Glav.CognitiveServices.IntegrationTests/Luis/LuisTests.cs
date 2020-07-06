using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Luis;
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
            var result = await LuisConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.LuisAppApiKey,TestConfig.LuisSubscriptionApiKey, LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithLuisAnalysisActions()
                .AddLuisAnalysis("Where can I find example ARM Templates")
                .AnalyseAllAsync();

            Assert.NotNull(result);

        }
    }
}

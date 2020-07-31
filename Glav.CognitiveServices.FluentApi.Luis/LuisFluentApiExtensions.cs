using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Luis.Configuration;
using Glav.CognitiveServices.FluentApi.Luis.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.FluentApi.Luis
{
    public static class LuisFluentApiExtensions
    {
        public static async Task<LuisAppAnalysisResults> AnalyseAllAsync(this LuisAnalysisSettings apiAnalysisSettings)
        {
            var engine = new LuisAppAnalysisEngine(apiAnalysisSettings);
            return await engine.AnalyseAllAsync().ConfigureAwait(continueOnCapturedContext: false);
        }

        public static LuisAnalysisSettings AddLuisAnalysis(this LuisAnalysisSettings apiAnalysis, string textToAnalyse, LuisAppSlot appSlot = LuisAppSlot.Staging)
        {
            return apiAnalysis.AddTextForAnalysis(textToAnalyse, LuisAnalysisApiOperations.LuisAnalysis);
        }

        private static LuisAnalysisSettings AddTextForAnalysis(this LuisAnalysisSettings apiAnalysis, string textToAnalyse, ApiActionDefinition actionType, LuisAppSlot appSlot = LuisAppSlot.Staging)
        {
            var appId = apiAnalysis.ConfigurationSettings.ApiKeys[LuisConfigurationSettings.APP_ID];
            var subKey = apiAnalysis.ConfigurationSettings.ApiKeys[LuisConfigurationSettings.SUBSCRIPTION_KEY];

            var actionData = apiAnalysis.GetOrCreateActionDataInstance<LuisAppActionData>(actionType);
            actionData.Add(appId,subKey,textToAnalyse,appSlot);
            return apiAnalysis;
        }

    }
}

using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Analysis;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Luis.Domain;
using System;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.FluentApi.Luis
{
    public class LuisAppAnalysisEngine : BaseAnalysisEngine<LuisAppAnalysisResults>
    {
        public LuisAppAnalysisEngine(CoreAnalysisSettings analysisSettings) : base(analysisSettings)
        { }

        public override async Task<LuisAppAnalysisResults> AnalyseAllAsync()
        {
            var apiResults = new LuisAppAnalysisResults(AnalysisSettings);
            await AnalyseApiActionAsync(apiResults, LuisAnalysisApiOperations.LuisAnalysis).ConfigureAwait(continueOnCapturedContext: false);
            return apiResults;
        }

        public override async Task AnalyseApiActionAsync(LuisAppAnalysisResults apiResults, ApiActionDefinition apiAction)
        {
            await base.AnalyseApiActionAsync(apiAction, (actionData, commsResult) =>
            {
                if (apiAction == LuisAnalysisApiOperations.LuisAnalysis)
                {
                    apiResults.AddLuisAppAnalysisResult(actionData, commsResult);
                    return;
                }
                throw new NotSupportedException($"{apiAction.ToString()} not supported yet");

            }).ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}

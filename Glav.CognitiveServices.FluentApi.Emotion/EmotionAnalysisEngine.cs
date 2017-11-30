using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Emotion.Domain;
using Glav.CognitiveServices.FluentApi.Core;

namespace Glav.CognitiveServices.FluentApi.Emotion
{
    public class EmotionAnalysisEngine : BaseAnalysisEngine<EmotionAnalysisResults, EmotionActionData>
    {
        public EmotionAnalysisEngine(CoreAnalysisSettings analysisSettings) : base(analysisSettings)
        {
        }

        public override async Task<EmotionAnalysisResults> AnalyseAllAsync()
        {
            var apiResults = new EmotionAnalysisResults(AnalysisSettings);
            await base.ExecuteApiActionAsync(apiResults, ApiActionType.EmotionImageRecognition, (actionData, commsResult) =>
            {
                apiResults.SetResult(new ImageRecognitionAnalysisContext((actionData as EmotionActionData), new ImageRecognitionResult(commsResult)));

            });
            return apiResults;

        }
    }
}

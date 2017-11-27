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
            await AnalyseApiActionAsync(apiResults, ApiActionType.EmotionImageRecognition);
            return apiResults;

        }

        public override async Task AnalyseApiActionAsync(EmotionAnalysisResults apiResults, ApiActionType apiAction)
        {
            await base.AnalyseApiActionAsync(apiResults, apiAction, (actionData, commsResult) =>
            {
                switch (apiAction)
                {
                    case ApiActionType.EmotionImageRecognition:
                        apiResults.SetResult(new ImageRecognitionAnalysisContext((actionData as EmotionActionData), new ImageRecognitionResult(commsResult)));
                        break;
                    default:
                        throw new NotSupportedException($"{apiAction.ToString()} not supported yet");
                }

            });
        }

    }
}

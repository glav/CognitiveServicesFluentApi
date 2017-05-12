using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.FluentApi.Core;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Emotion.Domain;

namespace Glav.CognitiveServices.FluentApi.Emotion
{
    public class EmotionAnalysisEngine : IAnalysisEngine<EmotionAnalysisResults>
    {
        public EmotionAnalysisEngine(CoreAnalysisSettings analysisSettings)
        {
            AnalysisSettings = analysisSettings;
        }
        public CoreAnalysisSettings AnalysisSettings { get; private set; }

        public async Task<EmotionAnalysisResults> AnalyseAllAsync()
        {
            var apiResults = new EmotionAnalysisResults(AnalysisSettings);
            await AnalyseAllAsyncForAction(apiResults, ApiActionType.EmotionImageRecognition);
            return apiResults;

        }

        private async Task AnalyseAllAsyncForAction(EmotionAnalysisResults apiResults, ApiActionType apiAction)
        {
            if (AnalysisSettings.ActionsToPerform.ContainsKey(apiAction))
            {
                var actions = AnalysisSettings.ActionsToPerform[apiAction];
                var payload = (actions as EmotionActionData).ToString();
                var result = await AnalysisSettings.CommunicationEngine.CallServiceAsync(apiAction, payload);

                switch (apiAction)
                {
                    case ApiActionType.EmotionImageRecognition:
                        apiResults.SetResult(new ImageRecognitionAnalysisContext((actions as EmotionActionData), new ImageRecognitionResult(result)));
                        break;
                    default:
                        throw new NotSupportedException($"{apiAction.ToString()} not supported yet");
                }
            }
        }

    }
}

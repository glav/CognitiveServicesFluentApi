using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Emotion.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.FluentApi.Emotion.Fluent
{
    public static class EmotionFluentApiExtensions
    {
        public static AnalysisSettings WithImageRecognition(this AnalysisSettings apiAnalysis, string url)
        {
            apiAnalysis.ActionsToPerform.Add(ApiActionType.EmotionImageRecognition, new EmotionActionData(new Uri(url)));
            return apiAnalysis;
        }
        public static AnalysisSettings WithImageRecognition(this AnalysisSettings apiAnalysis, Uri uri)
        {
            apiAnalysis.ActionsToPerform.Add(ApiActionType.EmotionImageRecognition, new EmotionActionData(uri));
            return apiAnalysis;
        }

        public static async Task<EmotionAnalysisResults> AnalyseAllEmotionsAsync(this AnalysisSettings apiAnalysisSettings)
        {
            var engine = new EmotionAnalysisEngine(apiAnalysisSettings);
            return await engine.AnalyseAllAsync();
        }

    }
}

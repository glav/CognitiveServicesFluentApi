using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.Emotion.Domain;
using Glav.CognitiveServices.FluentApi.Emotion.Domain.ApiResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Emotion
{
    public static class ImageRecognitionAnalysisContextExtensions
    {
        public static IEnumerable<EmotionImageRecognitionResponseItem> GetFacesRecognised(this ImageRecognitionAnalysisContext imageRecognitionContext)
        {
            if (!imageRecognitionContext.AnalysisResult.ActionSubmittedSuccessfully)
            {
                return new List<EmotionImageRecognitionResponseItem>();
            }
            return imageRecognitionContext.AnalysisResult.ResponseData.faces;
        }

        public static ImageRecognitionAnalysisContext UseCustomScoreLevelsAndDefaultScoringEngine(this ImageRecognitionAnalysisContext analysisContext, IScoreLevelBoundsCollection scoreLevels)
        {
            analysisContext.SetScoringEngine(new DefaultScoreEvaluationEngine(scoreLevels));
            return analysisContext;
        }
        public static ImageRecognitionAnalysisContext UseCustomScoringEngine(this ImageRecognitionAnalysisContext analysisContext, IScoreEvaluationEngine scoreEngine)
        {
            analysisContext.SetScoringEngine(scoreEngine);
            return analysisContext;
        }

    }
}

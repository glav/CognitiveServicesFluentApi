using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic
{
    public static class ScoringEngineContextExtensions
    {
        public static SentimentAnalysisContext UseCustomScoreLevelsAndDefaultScoringEngine(this SentimentAnalysisContext analysisContext, IScoreLevelBoundsCollection scoreLevels)
        {
            analysisContext.SetScoringEngine(new SentimentCustomScoreEvaluationEngine(scoreLevels));
            return analysisContext;
        }
        public static SentimentAnalysisContext UseCustomScoringEngine(this SentimentAnalysisContext analysisContext, IScoreEvaluationEngine<SentimentResultResponseItem> scoreEngine)
        {
            analysisContext.SetScoringEngine(scoreEngine);
            return analysisContext;
        }


        public static LanguageAnalysisContext UseCustomScoreLevelsAndDefaultScoringEngine(this LanguageAnalysisContext analysisContext, IScoreLevelBoundsCollection scoreLevels)
        {
            analysisContext.SetScoringEngine(new NumericScoreEvaluationEngine(scoreLevels));
            return analysisContext;
        }
        public static LanguageAnalysisContext UseCustomScoringEngine(this LanguageAnalysisContext analysisContext, IScoreEvaluationEngine<double> scoreEngine)
        {
            analysisContext.SetScoringEngine(scoreEngine);
            return analysisContext;
        }
    }
}

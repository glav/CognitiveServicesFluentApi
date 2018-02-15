using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic
{
    public static class ScoringEngineContextExtensions
    {
        public static SentimentAnalysisContext UseCustomScoreLevelsAndDefaultScoringEngine(this SentimentAnalysisContext analysisContext, IScoreLevelBoundsCollection scoreLevels)
        {
            analysisContext.SetScoringEngine(new DefaultScoreEvaluationEngine(scoreLevels));
            return analysisContext;
        }
        public static SentimentAnalysisContext UseCustomScoringEngine(this SentimentAnalysisContext analysisContext, IScoreEvaluationEngine scoreEngine)
        {
            analysisContext.SetScoringEngine(scoreEngine);
            return analysisContext;
        }

        public static KeyPhraseAnalysisContext UseCustomScoreLevelsAndDefaultScoringEngine(this KeyPhraseAnalysisContext analysisContext, IScoreLevelBoundsCollection scoreLevels)
        {
            analysisContext.SetScoringEngine(new DefaultScoreEvaluationEngine(scoreLevels));
            return analysisContext;
        }
        public static KeyPhraseAnalysisContext UseCustomScoringEngine(this KeyPhraseAnalysisContext analysisContext, IScoreEvaluationEngine scoreEngine)
        {
            analysisContext.SetScoringEngine(scoreEngine);
            return analysisContext;
        }

        public static LanguageAnalysisContext UseCustomScoreLevelsAndDefaultScoringEngine(this LanguageAnalysisContext analysisContext, IScoreLevelBoundsCollection scoreLevels)
        {
            analysisContext.SetScoringEngine(new DefaultScoreEvaluationEngine(scoreLevels));
            return analysisContext;
        }
        public static LanguageAnalysisContext UseCustomScoringEngine(this LanguageAnalysisContext analysisContext, IScoreEvaluationEngine scoreEngine)
        {
            analysisContext.SetScoringEngine(scoreEngine);
            return analysisContext;
        }
    }
}

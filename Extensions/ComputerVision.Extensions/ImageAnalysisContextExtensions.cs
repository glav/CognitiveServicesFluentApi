using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public static class ImageAnalysisContextExtensions
    {
        public static bool IsAdultContent(this ImageAnalysisContext context)
        {
            return context.AnalysisResult.ResponseData.adult.isAdultContent;
        }
        public static bool IsRacyContent(this ImageAnalysisContext context)
        {
            return context.AnalysisResult.ResponseData.adult.isRacyContent;
        }

        public static string[] GetDescriptiveCaptions(this ImageAnalysisContext context, double minimumConfidenceLevel)
        {
            return context.AnalysisResult.ResponseData.description.captions
                .Where(d => context.ScoringEngine.EvaluateScore(d.confidence).LowerBound >= minimumConfidenceLevel)
                .Select(i => i.text)
                .ToArray();
        }
        public static string[] GetDescriptiveCaptions(this ImageAnalysisContext context, string scoreLevelDescription)
        {
            var scoreLevelName = scoreLevelDescription.ToLowerInvariant();
            return context.AnalysisResult.ResponseData.description.captions
                .Where(d => context.ScoringEngine.EvaluateScore(d.confidence).NormalisedName == scoreLevelName)
                .Select(i => i.text)
                .ToArray();
        }

        public static string[] GetTags(this ImageAnalysisContext context, string scoreLevelDescription)
        {
            var scoreLevelName = scoreLevelDescription.ToLowerInvariant();
            return context.AnalysisResult.ResponseData.tags
                .Where(d => context.ScoringEngine.EvaluateScore(d.confidence).NormalisedName == scoreLevelName)
                .Select(i => i.name)
                .ToArray();
        }

        public static string[] GetTagsEqualToOrAboveAConfidenceLevel(this ImageAnalysisContext context, string scoreLevelDescription)
        {
            var scoreLevelName = scoreLevelDescription.ToLowerInvariant();
            var lowestScoreLevel = context.ScoringEngine.ScoreLevels.ScoreLevels.FirstOrDefault(s => s.NormalisedName == scoreLevelName);
            if (lowestScoreLevel == null)
            {
                return new string[] { };
            }
            return context.AnalysisResult.ResponseData.tags
                .Where(t => t.confidence >= lowestScoreLevel.LowerBound)
                .Select(t => t.name)
                .ToArray();
        }

    }
}

using Glav.CognitiveServices.FluentApi.Emotion.Domain;
using Glav.CognitiveServices.FluentApi.Emotion.Domain.ApiResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Emotion
{
    public static class EmotionImageRecognitionResponseItemExtensions
    {
        public static IEnumerable<EmotionImageRecognitionResponseItem> GetAngryFaces(this ImageRecognitionAnalysisContext context)
        {
            return FindResultsWithScoreDefinitelyOrPossiblyPositive(context, ImageRecognitionFaceEmotion.Anger);
        }
        public static IEnumerable<EmotionImageRecognitionResponseItem> GetContemptFaces(this ImageRecognitionAnalysisContext context)
        {
            return FindResultsWithScoreDefinitelyOrPossiblyPositive(context, ImageRecognitionFaceEmotion.Contempt);
        }
        public static IEnumerable<EmotionImageRecognitionResponseItem> GetDisgustedFaces(this ImageRecognitionAnalysisContext context)
        {
            return FindResultsWithScoreDefinitelyOrPossiblyPositive(context, ImageRecognitionFaceEmotion.Disgust);
        }
        public static IEnumerable<EmotionImageRecognitionResponseItem> GetFearfulFaces(this ImageRecognitionAnalysisContext context)
        {
            return FindResultsWithScoreDefinitelyOrPossiblyPositive(context, ImageRecognitionFaceEmotion.Fear);
        }
        public static IEnumerable<EmotionImageRecognitionResponseItem> GetHappyFaces(this ImageRecognitionAnalysisContext context)
        {
            return FindResultsWithScoreDefinitelyOrPossiblyPositive(context,ImageRecognitionFaceEmotion.Happiness);
        }
        public static IEnumerable<EmotionImageRecognitionResponseItem> GetNeutralFaces(this ImageRecognitionAnalysisContext context)
        {
            return FindResultsWithScoreDefinitelyOrPossiblyPositive(context, ImageRecognitionFaceEmotion.Neutral);
        }
        public static IEnumerable<EmotionImageRecognitionResponseItem> GetSadFaces(this ImageRecognitionAnalysisContext context)
        {
            return FindResultsWithScoreDefinitelyOrPossiblyPositive(context, ImageRecognitionFaceEmotion.Sadness);
        }
        public static IEnumerable<EmotionImageRecognitionResponseItem> GetSurprisedFaces(this ImageRecognitionAnalysisContext context)
        {
            return FindResultsWithScoreDefinitelyOrPossiblyPositive(context, ImageRecognitionFaceEmotion.Surprise);
        }

        private static IEnumerable<EmotionImageRecognitionResponseItem> FindResultsWithScoreDefinitelyOrPossiblyPositive(ImageRecognitionAnalysisContext context, ImageRecognitionFaceEmotion emotionType)
        {
            var results = new List<EmotionImageRecognitionResponseItem>();
            foreach (var item in context.AnalysisResult.ResponseData.faces)
            {
                var score = context.ScoringEngine.EvaluateScore(GetScoreToEvaluate(item,emotionType));
                if (score.Name == EmotionRangeScoreLevels.DefinitelyPositive || score.Name == EmotionRangeScoreLevels.ProbablyPositive)
                {
                    results.Add(item);
                }
            }
            return results;
        }

        private enum ImageRecognitionFaceEmotion
        {
            Anger,
            Contempt,
            Disgust,
            Fear,
            Happiness,
            Neutral,
            Sadness,
            Surprise

        }
        private static double GetScoreToEvaluate(EmotionImageRecognitionResponseItem item, ImageRecognitionFaceEmotion emotionType )
        {
            switch (emotionType)
            {
                case ImageRecognitionFaceEmotion.Anger:
                    return item.scores.anger;
                case ImageRecognitionFaceEmotion.Contempt:
                    return item.scores.contempt;
                case ImageRecognitionFaceEmotion.Disgust:
                    return item.scores.disgust;
                case ImageRecognitionFaceEmotion.Fear:
                    return item.scores.fear;
                case ImageRecognitionFaceEmotion.Happiness:
                    return item.scores.happiness;
                case ImageRecognitionFaceEmotion.Neutral:
                    return item.scores.neutral;
                case ImageRecognitionFaceEmotion.Sadness:
                    return item.scores.sadness;
                case ImageRecognitionFaceEmotion.Surprise:
                    return item.scores.surprise;
            }

            return 0;
        }
    }
}

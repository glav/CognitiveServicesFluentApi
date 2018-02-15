using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.FluentApi.Emotion.Domain
{
    public class ImageRecognitionAnalysisContext : BaseApiAnalysisContext<EmotionActionData, ImageRecognitionResult>
    {
        public ImageRecognitionAnalysisContext(EmotionActionData actionData, ImageRecognitionResult analysisResult, IScoreEvaluationEngine scoringEngine)
            : base(actionData, analysisResult, scoringEngine)
        {
        }

        public override ApiActionType AnalysisType => ApiActionType.EmotionImageRecognition;
    }
}

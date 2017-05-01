using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.Emotion.Domain
{
    public class ImageRecognitionAnalysisContext : IApiAnalysisContext<EmotionActionData, ImageRecognitionResult>
    {
        public ImageRecognitionAnalysisContext(EmotionActionData actionData, ImageRecognitionResult analysisResult)
        {
            AnalysisInput = actionData;
            AnalysisResult = analysisResult;
        }

        public ApiActionType AnalysisType => ApiActionType.EmotionImageRecognition;

        public EmotionActionData AnalysisInput { get; private set; }

        public ImageRecognitionResult AnalysisResult { get; private set; }
    }
}

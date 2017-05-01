using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Emotion.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Emotion
{
    public class EmotionAnalysisResults : IAnalysisResults
    {
        public EmotionAnalysisResults(AnalysisSettings analysisSettings)
        {
            AnalysisSettings = analysisSettings;
        }
        public AnalysisSettings AnalysisSettings { get; private set; }

        public ImageRecognitionAnalysisContext ImageRecognitionAnalysis { get; private set; }
        public void SetResult(ImageRecognitionAnalysisContext imageRecognitionAnalysis)
        {
            ImageRecognitionAnalysis = imageRecognitionAnalysis;
        }

    }
}

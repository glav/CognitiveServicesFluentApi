using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public class ComputerVisionAnalysisResults : IAnalysisResults
    {
        public ComputerVisionAnalysisResults(CoreAnalysisSettings analysisSettings)
        {
            AnalysisSettings = analysisSettings;
        }
        public CoreAnalysisSettings AnalysisSettings { get; private set; }

        public ImageAnalysisContext ImageAnalysis { get; private set; }
        public void SetResult(ImageAnalysisContext imageAnalysis)
        {
            ImageAnalysis = imageAnalysis;
        }

        //public void AddResult(new ImageAnalysisResult(commsResult))

    }
}

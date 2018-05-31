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
        public void SetImageResultContext(ImageAnalysisContext imageAnalysisCtxt)
        {
            ImageAnalysis = imageAnalysisCtxt ?? throw new ArgumentNullException("ImageAnalysisContext");
        }

        public void AddResult(ImageAnalysisResult result)
        {
            if (ImageAnalysis == null)
            {
                throw new NullReferenceException("Cannot add a result without first setting the result context");
            }
            ImageAnalysis.AnalysisResults.Add(result);
        }

        //public void AddResult(new ImageAnalysisResult(commsResult))

    }
}

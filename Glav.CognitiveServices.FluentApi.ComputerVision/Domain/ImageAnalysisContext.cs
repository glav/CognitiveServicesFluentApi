using Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public class ImageAnalysisContext : IApiAnalysisContext<ImageAnalysisActionData, ImageAnalysisResult>
    {
        public ImageAnalysisContext(ImageAnalysisActionData actionData, ImageAnalysisResult analysisResult )
        {
            AnalysisInput = actionData;
            AnalysisResult = analysisResult;
        }
        public ApiActionType AnalysisType => ApiActionType.ComputerVisionImageAnalysis;

        public ImageAnalysisActionData AnalysisInput { get; private set; }

        public ImageAnalysisResult AnalysisResult { get; private set; }
    }
}

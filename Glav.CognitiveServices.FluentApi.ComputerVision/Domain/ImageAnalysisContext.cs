﻿using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public class ImageAnalysisContext : BaseApiAnalysisContext<ImageAnalysisResult> 
    {
        public ImageAnalysisContext(ApiActionDataCollection actionData, ImageAnalysisResult analysisResult, IScoreEvaluationEngine scoringEngine)
            : base(actionData, analysisResult, scoringEngine)
        {
        }
        public override ApiActionType AnalysisType => ApiActionType.ComputerVisionImageAnalysis;

    }
}

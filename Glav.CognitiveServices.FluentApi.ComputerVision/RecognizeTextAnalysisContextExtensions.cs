using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public static class RecognizeTextAnalysisContextExtensions
    {
        public static string GetInitialErrorMessage(this RecognizeTextAnalysisContext context)
        {
            var message = context.AnalysisResult.ResponseData.error != null ?
                context.AnalysisResult.ResponseData.error.message :
                context.AnalysisResult.ApiCallResult.Data;
            return message;

        }

    }
}

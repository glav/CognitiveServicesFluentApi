using Glav.CognitiveServices.Api.Fluent.TextAnalytic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api
{
    public class ApiAnalysisResults
    {
        public TextAnalyticAnalysisResultSet TextAnalyticAnalysis { get; private set; }

        public static ApiAnalysisResults Create(TextAnalyticAnalysisResultSet textAnalyticAnalysis)
        {
            return new ApiAnalysisResults { TextAnalyticAnalysis = textAnalyticAnalysis };
        }
    }
}

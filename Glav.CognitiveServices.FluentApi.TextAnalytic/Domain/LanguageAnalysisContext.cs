﻿using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses;
using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain
{
    public class LanguageAnalysisContext : BaseApiAnalysisContext<LanguagesResult, ApiErrorResponse, double>
    {
        public LanguageAnalysisContext(ApiActionDataCollection actionData, LanguagesResult analysisResult)
            : base(actionData, analysisResult, new NumericScoreEvaluationEngine(new DefaultScoreLevels()))
        {
        }
        public override ApiActionDefinition AnalysisType { get { return TextAnalyticApiOperations.LanguageAnalysis; } }

        public override IEnumerable<ApiErrorResponse> GetAllErrors()
        {
            return AnalysisResults.SelectMany(e => e.ResponseData?.errors);
        }
    }
}

using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Luis.Domain
{
    public class LuisAppAnalysisContext : BaseApiAnalysisContext<LuisAppAnalysisResult, BaseApiErrorResponse, double>
    {
        public LuisAppAnalysisContext(ApiActionDataCollection actionData) : base(actionData, new NumericScoreEvaluationEngine(new DefaultScoreLevels()))
        {
        }

        public LuisAppAnalysisContext(ApiActionDataCollection actionData, LuisAppAnalysisResult analysisResult) 
            : base(actionData, analysisResult, new NumericScoreEvaluationEngine(new DefaultScoreLevels()))
        {
        }

        public override ApiActionDefinition AnalysisType => LuisAnalysisApiOperations.LuisAnalysis;

        public override IEnumerable<BaseApiErrorResponse> GetAllErrors()
        {
            return AnalysisResults.Select(e => e.ResponseData.error);
        }

    }
}

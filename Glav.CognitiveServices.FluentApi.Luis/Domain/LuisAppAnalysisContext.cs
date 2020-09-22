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
    public class LuisAppAnalysisContext : BaseApiAnalysisContext<LuisAppAnalysisResult, BaseApiErrorResponse>
    {
        public LuisAppAnalysisContext(ApiActionDataCollection actionData, IScoreEvaluationEngine scoringEngine) : base(actionData, scoringEngine)
        {
        }

        public LuisAppAnalysisContext(ApiActionDataCollection actionData, LuisAppAnalysisResult analysisResult, IScoreEvaluationEngine scoringEngine) : base(actionData, analysisResult, scoringEngine)
        {
        }

        public override ApiActionDefinition AnalysisType => LuisAnalysisApiOperations.LuisAnalysis;

        public override IEnumerable<BaseApiErrorResponse> GetAllErrors()
        {
            return AnalysisResults.Select(e => e.ResponseData.error);
        }

    }
}

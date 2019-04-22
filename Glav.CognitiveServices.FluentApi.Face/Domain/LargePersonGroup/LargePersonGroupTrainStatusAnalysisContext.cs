using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using System.Linq;
using Glav.CognitiveServices.FluentApi.Core;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup
{
    public class LargePersonGroupTrainStatusAnalysisContext : BaseApiAnalysisContext<LargePersonGroupTrainStatusResult> 
    {
        public LargePersonGroupTrainStatusAnalysisContext(ApiActionDataCollection actionData, LargePersonGroupTrainStatusResult analysisResult, IScoreEvaluationEngine scoringEngine)
            : base(actionData, analysisResult, scoringEngine)
        {
        }
        public LargePersonGroupTrainStatusAnalysisContext(ApiActionDataCollection actionData, IScoreEvaluationEngine scoringEngine)
            : base(actionData, scoringEngine)
        {
        }
        public override ApiActionDefinition AnalysisType => FaceApiOperations.LargePersonGroupTrainStatus;

        public void UpdateTrainingStatus(LargePersonGroupTrainStatusResult result)
        {
            if (AnalysisResults == null || AnalysisResults.Count == 0)
            {
                throw new CognitiveServicesArgumentException("No results to update");
            }
            this.AnalysisResults.First().ResponseData.TrainingStatus = result.ParsingStrategy.ResponseItemData;
        }

    }
}

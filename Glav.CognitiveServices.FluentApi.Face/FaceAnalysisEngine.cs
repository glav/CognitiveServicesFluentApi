using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Face.Domain;

namespace Glav.CognitiveServices.FluentApi.Face
{
    public sealed class FaceAnalysisEngine : BaseAnalysisEngine<FaceAnalysisResults>
    {
        public FaceAnalysisEngine(CoreAnalysisSettings analysisSettings) : base(analysisSettings)
        {
        }


        public override async Task<FaceAnalysisResults> AnalyseAllAsync()
        {
            var apiResults = new FaceAnalysisResults(AnalysisSettings);
            await AnalyseApiActionAsync(apiResults, ApiActionType.FaceDetection).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, ApiActionType.FaceLargePersonGroups).ConfigureAwait(continueOnCapturedContext: false);
            return apiResults;
        }


        public override async Task AnalyseApiActionAsync(FaceAnalysisResults apiResults, ApiActionType apiAction)
        {
            await base.AnalyseApiActionAsync(apiResults, apiAction, (actionData, commsResult) =>
            {
                switch (apiAction)
                {
                    case ApiActionType.FaceDetection:
                        apiResults.SetResult(new FaceDetectionAnalysisContext(actionData, new FaceDetectionResult(commsResult), apiResults.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
                        break;
                    case ApiActionType.FaceLargePersonGroups:
                        apiResults.SetResult(new LargePersonGroupAnalysisContext(actionData, new LargePersonGroupCreateResult(commsResult), apiResults.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
                        break;
                    default:
                        throw new NotSupportedException($"{apiAction.ToString()} not supported yet");
                }

            }).ConfigureAwait(continueOnCapturedContext: false);

        }
    }
}

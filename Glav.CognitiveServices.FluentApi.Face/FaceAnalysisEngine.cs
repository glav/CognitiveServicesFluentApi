using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup;
using Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson;
using System;
using System.Threading.Tasks;

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
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.FaceDetection).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupCreate).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupGet).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupList).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupDelete).ConfigureAwait(continueOnCapturedContext: false);

            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupPersonCreate).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupPersonGet).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupPersonList).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupPersonDelete).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupPersonFaceAdd).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupPersonFaceGet).ConfigureAwait(continueOnCapturedContext: false);
            return apiResults;
        }


        public override async Task AnalyseApiActionAsync(FaceAnalysisResults apiResults, ApiActionDefinition apiAction)
        {
            await base.AnalyseApiActionAsync(apiAction, (actionData, commsResult) =>
            {
                if (apiAction == FaceApiOperations.FaceDetection)
                {
                    apiResults.SetResult(new FaceDetectionAnalysisContext(actionData, new FaceDetectionResult(commsResult), apiResults.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
                    return;
                }
                if (apiAction == FaceApiOperations.LargePersonGroupCreate)
                {
                    apiResults.SetResult(new LargePersonGroupCreateAnalysisContext(actionData, new LargePersonGroupCreateResult(commsResult), apiResults.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
                    return;
                }
                if (apiAction == FaceApiOperations.LargePersonGroupGet)
                {
                    apiResults.SetResult(new LargePersonGroupGetAnalysisContext(actionData, new LargePersonGroupGetResult(commsResult), apiResults.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
                    return;
                }
                if (apiAction == FaceApiOperations.LargePersonGroupList)
                {
                    apiResults.SetResult(new LargePersonGroupListAnalysisContext(actionData, new LargePersonGroupListResult(commsResult), apiResults.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
                    return;
                }
                if (apiAction == FaceApiOperations.LargePersonGroupDelete)
                {
                    apiResults.SetResult(new LargePersonGroupDeleteAnalysisContext(actionData, new LargePersonGroupDeleteResult(commsResult), apiResults.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
                    return;
                }


                if (apiAction == FaceApiOperations.LargePersonGroupPersonDelete)
                {
                    apiResults.SetResult(new LargePersonGroupPersonDeleteAnalysisContext(actionData, new LargePersonGroupPersonDeleteResult(commsResult), apiResults.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
                    return;
                }
                if (apiAction == FaceApiOperations.LargePersonGroupPersonCreate)
                {
                    apiResults.SetResult(new LargePersonGroupPersonCreateAnalysisContext(actionData, new LargePersonGroupPersonCreateResult(commsResult), apiResults.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
                    return;
                }
                if (apiAction == FaceApiOperations.LargePersonGroupPersonGet)
                {
                    apiResults.SetResult(new LargePersonGroupPersonGetAnalysisContext(actionData, new LargePersonGroupPersonGetResult(commsResult), apiResults.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
                    return;
                }
                if (apiAction == FaceApiOperations.LargePersonGroupPersonList)
                {
                    apiResults.SetResult(new LargePersonGroupPersonListAnalysisContext(actionData, new LargePersonGroupPersonListResult(commsResult), apiResults.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
                    return;
                }
                if (apiAction == FaceApiOperations.LargePersonGroupPersonFaceAdd)
                {
                    apiResults.SetResult(new LargePersonGroupPersonFaceAddAnalysisContext(actionData, new LargePersonGroupPersonFaceAddResult(commsResult), apiResults.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
                    return;
                }
                if (apiAction == FaceApiOperations.LargePersonGroupPersonFaceGet)
                {
                    apiResults.SetResult(new LargePersonGroupPersonFaceGetAnalysisContext(actionData, new LargePersonGroupPersonFaceGetResult(commsResult), apiResults.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
                    return;
                }
                throw new NotSupportedException($"{apiAction.ToString()} not supported yet");
            }).ConfigureAwait(continueOnCapturedContext: false);

        }
    }
}

using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Analysis;
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
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.FaceIdentification).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupCreate).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupGet).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupList).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupPersonCreate).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupPersonFaceAdd).ConfigureAwait(continueOnCapturedContext: false);
            // Important: Need to ensure the 'training' options are after any face additions or creates so training can be chained
            // in one set of operations.
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupTrainStart).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupTrainStatus).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupPersonFaceDelete).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupPersonDelete).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupDelete).ConfigureAwait(continueOnCapturedContext: false);

            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupPersonGet).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupPersonList).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, FaceApiOperations.LargePersonGroupPersonFaceGet).ConfigureAwait(continueOnCapturedContext: false);
            return apiResults;
        }


        public override async Task AnalyseApiActionAsync(FaceAnalysisResults apiResults, ApiActionDefinition apiAction)
        {
            await base.AnalyseApiActionAsync(apiAction, (actionData, commsResult) =>
            {
                if (apiAction == FaceApiOperations.FaceDetection)
                {
                    apiResults.AddFaceDetectionResult(actionData, commsResult);
                    return;
                }
                if (apiAction == FaceApiOperations.FaceIdentification)
                {
                    apiResults.AddFaceIdentificationResult(actionData,commsResult);
                    return;
                }
                if (apiAction == FaceApiOperations.LargePersonGroupCreate)
                {
                    apiResults.AddLargePersonGroupCreateResult(actionData,commsResult);
                    return;
                }
                if (apiAction == FaceApiOperations.LargePersonGroupGet)
                {
                    apiResults.AddLargePersonGroupGetResult(actionData,commsResult);
                    return;
                }
                if (apiAction == FaceApiOperations.LargePersonGroupList)
                {
                    apiResults.AddLargePersonGroupListResult(actionData,commsResult);
                    return;
                }
                if (apiAction == FaceApiOperations.LargePersonGroupDelete)
                {
                    apiResults.AddLargePersonGroupDeleteResult(actionData, commsResult);
                    return;
                }
                if (apiAction == FaceApiOperations.LargePersonGroupTrainStart)
                {
                    apiResults.AddLargePersonGroupTrainStartResult(actionData,commsResult);
                    return;
                }
                if (apiAction == FaceApiOperations.LargePersonGroupTrainStatus)
                {
                    apiResults.SetargePersonGroupTrainStatusResult(actionData,commsResult);
                    return;
                }


                if (apiAction == FaceApiOperations.LargePersonGroupPersonDelete)
                {
                    apiResults.AddLargePersonGroupPersonDeleteResult(actionData, commsResult);
                    return;
                }
                if (apiAction == FaceApiOperations.LargePersonGroupPersonCreate)
                {
                    apiResults.AddLargePersonGroupPersonCreateResult(actionData, commsResult);
                    return;
                }
                if (apiAction == FaceApiOperations.LargePersonGroupPersonGet)
                {
                    apiResults.AddLargePersonGroupPersonGetResult(actionData,commsResult);
                    return;
                }
                if (apiAction == FaceApiOperations.LargePersonGroupPersonList)
                {
                    apiResults.AddLargePersonGroupPersonListResult(actionData,commsResult);
                    return;
                }
                if (apiAction == FaceApiOperations.LargePersonGroupPersonFaceAdd)
                {
                    apiResults.AddLargePersonGroupPersonFaceAddResult(actionData,commsResult);
                    return;
                }
                if (apiAction == FaceApiOperations.LargePersonGroupPersonFaceGet)
                {
                    apiResults.AddLargePersonGroupPersonFaceGetResult(actionData, commsResult);
                    return;
                }
                if (apiAction == FaceApiOperations.LargePersonGroupPersonFaceDelete)
                {
                    apiResults.AddLargePersonGroupPersonFaceDeleteResult(actionData,commsResult);
                    return;
                }
                throw new NotSupportedException($"{apiAction.ToString()} not supported yet");
            }).ConfigureAwait(continueOnCapturedContext: false);

        }
    }
}

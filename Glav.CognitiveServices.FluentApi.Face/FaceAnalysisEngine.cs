using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Analysis;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup;
using Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.FluentApi.Face
{
    public sealed class FaceAnalysisEngine : BaseAnalysisEngine<FaceAnalysisResults>
    {
        private Dictionary<string, Action<FaceAnalysisResults, ApiActionDataCollection, ICommunicationResult>> _resultCollectors = 
                                    new Dictionary<string, Action<FaceAnalysisResults, ApiActionDataCollection, ICommunicationResult>>();

        public FaceAnalysisEngine(CoreAnalysisSettings analysisSettings) : base(analysisSettings)
        {
            SetupResultCollection();
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

        private void SetupResultCollection()
        {
            var resultCollectors = new Dictionary<string, Action<FaceAnalysisResults,ApiActionDataCollection, ICommunicationResult>>();
            _resultCollectors.Add(FaceApiOperations.FaceDetection.Name, 
                        (apiAction, actionData, commsResult) => apiAction.AddFaceDetectionResult(actionData, commsResult));
            _resultCollectors.Add(FaceApiOperations.FaceIdentification.Name,
                        (apiAction, actionData, commsResult) => apiAction.AddFaceIdentificationResult(actionData, commsResult));
            _resultCollectors.Add(FaceApiOperations.LargePersonGroupCreate.Name,
                        (apiAction, actionData, commsResult) => apiAction.AddLargePersonGroupCreateResult(actionData, commsResult));
            _resultCollectors.Add(FaceApiOperations.LargePersonGroupGet.Name,
                        (apiAction, actionData, commsResult) => apiAction.AddLargePersonGroupGetResult(actionData, commsResult));
            _resultCollectors.Add(FaceApiOperations.LargePersonGroupList.Name,
                        (apiAction, actionData, commsResult) => apiAction.AddLargePersonGroupListResult(actionData, commsResult));
            _resultCollectors.Add(FaceApiOperations.LargePersonGroupDelete.Name,
                        (apiAction, actionData, commsResult) => apiAction.AddLargePersonGroupDeleteResult(actionData, commsResult));
            _resultCollectors.Add(FaceApiOperations.LargePersonGroupTrainStart.Name,
                        (apiAction, actionData, commsResult) => apiAction.AddLargePersonGroupTrainStartResult(actionData, commsResult));
            _resultCollectors.Add(FaceApiOperations.LargePersonGroupTrainStatus.Name,
                        (apiAction, actionData, commsResult) => apiAction.SetargePersonGroupTrainStatusResult(actionData, commsResult));
            _resultCollectors.Add(FaceApiOperations.LargePersonGroupPersonDelete.Name,
                        (apiAction, actionData, commsResult) => apiAction.AddLargePersonGroupPersonDeleteResult(actionData, commsResult));
            _resultCollectors.Add(FaceApiOperations.LargePersonGroupPersonCreate.Name,
                        (apiAction, actionData, commsResult) => apiAction.AddLargePersonGroupPersonCreateResult(actionData, commsResult));
            _resultCollectors.Add(FaceApiOperations.LargePersonGroupPersonGet.Name,
                        (apiAction, actionData, commsResult) => apiAction.AddLargePersonGroupPersonGetResult(actionData, commsResult));
            _resultCollectors.Add(FaceApiOperations.LargePersonGroupPersonList.Name,
                        (apiAction, actionData, commsResult) => apiAction.AddLargePersonGroupPersonListResult(actionData, commsResult));
            _resultCollectors.Add(FaceApiOperations.LargePersonGroupPersonFaceAdd.Name,
                        (apiAction, actionData, commsResult) => apiAction.AddLargePersonGroupPersonFaceAddResult(actionData, commsResult));
            _resultCollectors.Add(FaceApiOperations.LargePersonGroupPersonFaceGet.Name,
                        (apiAction, actionData, commsResult) => apiAction.AddLargePersonGroupPersonFaceGetResult(actionData, commsResult));
            _resultCollectors.Add(FaceApiOperations.LargePersonGroupPersonFaceDelete.Name,
                        (apiAction, actionData, commsResult) => apiAction.AddLargePersonGroupPersonFaceDeleteResult(actionData, commsResult));

        }

        public override async Task AnalyseApiActionAsync(FaceAnalysisResults apiResults, ApiActionDefinition apiAction)
        {
            await base.AnalyseApiActionAsync(apiAction, (actionData, commsResult) =>
            {
                if (_resultCollectors.ContainsKey(apiAction.Name))
                {
                    _resultCollectors[apiAction.Name](apiResults, actionData, commsResult);
                    return;
                }

                throw new NotSupportedException($"{apiAction.ToString()} not supported yet");
            }).ConfigureAwait(continueOnCapturedContext: false);

        }
    }
}

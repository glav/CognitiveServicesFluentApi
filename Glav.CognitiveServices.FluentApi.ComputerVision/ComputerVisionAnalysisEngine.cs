using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core.Operations;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public class ComputerVisionAnalysisEngine : BaseAnalysisEngine<ComputerVisionAnalysisResults>
    {
        public ComputerVisionAnalysisEngine(CoreAnalysisSettings analysisSettings) : base(analysisSettings)
        { }

        public override async Task<ComputerVisionAnalysisResults> AnalyseAllAsync()
        {
            var apiResults = new ComputerVisionAnalysisResults(AnalysisSettings);
            await AnalyseApiActionAsync(apiResults, ApiActionType.ComputerVisionImageAnalysis).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, ApiActionType.ComputerVisionOcrAnalysis).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, ApiActionType.ComputerVisionRecognizeText).ConfigureAwait(continueOnCapturedContext: false);
            return apiResults;

        }

        public override async Task AnalyseApiActionAsync(ComputerVisionAnalysisResults apiResults, ApiActionType apiAction)
        {
            InitialiseContextForAction(apiAction, apiResults);

            await base.AnalyseApiActionAsync(apiResults, apiAction, (actionData, commsResult) =>
              {
                  switch (apiAction)
                  {
                      case ApiActionType.ComputerVisionImageAnalysis:
                          apiResults.AddResult(new ImageAnalysisResult(commsResult));
                          break;
                      case ApiActionType.ComputerVisionOcrAnalysis:
                          apiResults.AddResult(new OcrAnalysisResult(commsResult));
                          break;
                      case ApiActionType.ComputerVisionRecognizeText:
                          apiResults.AddResult(new RecognizeTextAnalysisResult(commsResult));
                          break;
                      default:
                          throw new NotSupportedException($"{apiAction.ToString()} not supported yet");
                  }

              }).ConfigureAwait(continueOnCapturedContext: false);
        }

        private void InitialiseContextForAction(ApiActionType apiAction, ComputerVisionAnalysisResults apiResults)
        {
            if (AnalysisSettings.ActionsToPerform.ContainsKey(apiAction) && apiResults.ImageAnalysis == null && apiAction == ApiActionType.ComputerVisionImageAnalysis)
            {
                // Get the collection of actions to perform for an API call
                var actions = AnalysisSettings.ActionsToPerform[apiAction];
                apiResults.SetImageResultContext(new ImageAnalysisContext(actions, AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
            }
            if (AnalysisSettings.ActionsToPerform.ContainsKey(apiAction) && apiResults.OcrAnalysis == null && apiAction == ApiActionType.ComputerVisionOcrAnalysis)
            {
                // Get the collection of actions to perform for an API call
                var actions = AnalysisSettings.ActionsToPerform[apiAction];
                apiResults.SetOcrResultContext(new OcrAnalysisContext(actions, AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
            }
            if (AnalysisSettings.ActionsToPerform.ContainsKey(apiAction) && apiResults.RecognizeTextAnalysis == null && apiAction == ApiActionType.ComputerVisionRecognizeText)
            {
                // Get the collection of actions to perform for an API call
                var actions = AnalysisSettings.ActionsToPerform[apiAction];
                apiResults.SetRecognizeTextResultContext(new RecognizeTextAnalysisContext(actions, AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
            }
        }
    }
}

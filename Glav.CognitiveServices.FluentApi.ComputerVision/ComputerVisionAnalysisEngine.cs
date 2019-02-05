using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public class ComputerVisionAnalysisEngine : BaseAnalysisEngine<ComputerVisionAnalysisResults>
    {
        public ComputerVisionAnalysisEngine(CoreAnalysisSettings analysisSettings) : base(analysisSettings)
        { }

        public override async Task<ComputerVisionAnalysisResults> AnalyseAllAsync()
        {
            var apiResults = new ComputerVisionAnalysisResults(AnalysisSettings);
            await AnalyseApiActionAsync(apiResults, ComputerVisionApiOperations.ImageAnalysis).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, ComputerVisionApiOperations.OcrAnalysis).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, ComputerVisionApiOperations.RecognizeText).ConfigureAwait(continueOnCapturedContext: false);
            return apiResults;

        }

        public override async Task AnalyseApiActionAsync(ComputerVisionAnalysisResults apiResults, ApiActionDefinition apiAction)
        {
            InitialiseContextForAction(apiAction, apiResults);

            await base.AnalyseApiActionAsync(apiAction, (actionData, commsResult) =>
              {
                  if (apiAction == ComputerVisionApiOperations.ImageAnalysis)
                  {
                      apiResults.AddResult(new ImageAnalysisResult(commsResult));
                      return;
                  }
                  if (apiAction == ComputerVisionApiOperations.OcrAnalysis)
                  {
                      apiResults.AddResult(new OcrAnalysisResult(commsResult));
                      return;
                  }
                  if (apiAction == ComputerVisionApiOperations.RecognizeText)
                  {
                      apiResults.AddResult(new RecognizeTextAnalysisResult(commsResult));
                      return;
                  }
                  throw new NotSupportedException($"{apiAction.ToString()} not supported yet");

              }).ConfigureAwait(continueOnCapturedContext: false);
        }

        private void InitialiseContextForAction(ApiActionDefinition apiAction, ComputerVisionAnalysisResults apiResults)
        {
            if (AnalysisSettings.ActionsToPerform.ContainsKey(apiAction.Name) && apiResults.ImageAnalysis == null && apiAction == ComputerVisionApiOperations.ImageAnalysis)
            {
                // Get the collection of actions to perform for an API call
                var actions = AnalysisSettings.ActionsToPerform[apiAction.Name];
                apiResults.SetImageResultContext(new ImageAnalysisContext(actions, AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
            }
            if (AnalysisSettings.ActionsToPerform.ContainsKey(apiAction.Name) && apiResults.OcrAnalysis == null && apiAction == ComputerVisionApiOperations.OcrAnalysis)
            {
                // Get the collection of actions to perform for an API call
                var actions = AnalysisSettings.ActionsToPerform[apiAction.Name];
                apiResults.SetOcrResultContext(new OcrAnalysisContext(actions, AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
            }
            if (AnalysisSettings.ActionsToPerform.ContainsKey(apiAction.Name) && apiResults.RecognizeTextAnalysis == null && apiAction == ComputerVisionApiOperations.RecognizeText)
            {
                // Get the collection of actions to perform for an API call
                var actions = AnalysisSettings.ActionsToPerform[apiAction.Name];
                apiResults.SetRecognizeTextResultContext(new RecognizeTextAnalysisContext(actions, AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
            }
        }
    }
}

using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Analysis;
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
            await base.AnalyseApiActionAsync(apiAction, (actionData, commsResult) =>
              {
                  if (apiAction == ComputerVisionApiOperations.ImageAnalysis)
                  {
                      apiResults.AddImageAnalysisResult(actionData,commsResult);
                      return;
                  }
                  if (apiAction == ComputerVisionApiOperations.OcrAnalysis)
                  {
                      apiResults.AddOcrAnalysisResult(actionData,commsResult);
                      return;
                  }
                  if (apiAction == ComputerVisionApiOperations.RecognizeText)
                  {
                      apiResults.AddRecognizeTextResult(actionData, commsResult);
                      return;
                  }
                  throw new NotSupportedException($"{apiAction.ToString()} not supported yet");

              }).ConfigureAwait(continueOnCapturedContext: false);
        }

    }
}

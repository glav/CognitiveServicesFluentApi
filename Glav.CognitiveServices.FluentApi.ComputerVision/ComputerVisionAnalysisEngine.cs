using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public class ComputerVisionAnalysisEngine : BaseAnalysisEngine<ComputerVisionAnalysisResults, ImageAnalysisActionData>
    {
        public ComputerVisionAnalysisEngine(CoreAnalysisSettings analysisSettings) : base(analysisSettings)
        { }

        public override async Task<ComputerVisionAnalysisResults> AnalyseAllAsync()
        {
            var apiResults = new ComputerVisionAnalysisResults(AnalysisSettings);
            await AnalyseApiActionAsync(apiResults, ApiActionType.ComputerVisionImageAnalysis);
            return apiResults;

        }

        public override async Task AnalyseApiActionAsync(ComputerVisionAnalysisResults apiResults, ApiActionType apiAction)
        {
            await base.AnalyseApiActionAsync(apiResults, apiAction, (actionData, commsResult) =>
              {
                  switch (apiAction)
                  {
                      case ApiActionType.ComputerVisionImageAnalysis:
                          apiResults.SetResult(new ImageAnalysisContext((actionData as ImageAnalysisActionData), new ImageAnalysisResult(commsResult)));
                          break;
                      default:
                          throw new NotSupportedException($"{apiAction.ToString()} not supported yet");
                  }

              });
        }
    }
}

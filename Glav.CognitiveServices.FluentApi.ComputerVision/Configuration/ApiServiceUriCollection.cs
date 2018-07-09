using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Configuration
{
    public class ApiServiceUriCollection : ApiServiceUriCollectionBase
    {
        public ApiServiceUriCollection()
        {
            Services.Add(ApiActionType.ComputerVisionImageAnalysis, new ImageAnalysisServiceConfig());
            Services.Add(ApiActionType.ComputerVisionOcrAnalysis, new OcrAnalysisServiceConfig());
            Services.Add(ApiActionType.ComputerVisionRecognizeText, new RecognizeTextAnalysisServiceConfig());
        }
    }
}

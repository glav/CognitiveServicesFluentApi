using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Configuration
{
    public class ApiServiceUriCollection : ApiServiceUriCollectionBase
    {
        public ApiServiceUriCollection()
        {
            Services.Add(ComputerVisionApiOperations.ImageAnalysis.Name, new ImageAnalysisServiceConfig());
            Services.Add(ComputerVisionApiOperations.OcrAnalysis.Name, new OcrAnalysisServiceConfig());
            Services.Add(ComputerVisionApiOperations.RecognizeText.Name, new RecognizeTextAnalysisServiceConfig());
        }
    }
}

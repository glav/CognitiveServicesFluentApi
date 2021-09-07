using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Configuration
{
    public class ApiServiceUriCollection : ApiServiceUriCollectionBase
    {
        public ApiServiceUriCollection(string apiVersionIdentifier)
        {
            Services.Add(ComputerVisionApiOperations.ImageAnalysis.Name, new ImageAnalysisServiceConfig(apiVersionIdentifier));
            Services.Add(ComputerVisionApiOperations.OcrAnalysis.Name, new OcrAnalysisServiceConfig(apiVersionIdentifier));
            Services.Add(ComputerVisionApiOperations.ReadImage.Name, new ReadImageAnalysisServiceConfig(apiVersionIdentifier));
        }
    }
}

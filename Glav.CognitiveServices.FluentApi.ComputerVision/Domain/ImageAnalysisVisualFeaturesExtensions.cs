using Glav.CognitiveServices.FluentApi.ComputerVision.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Communication;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public static class ImageAnalysisVisualFeaturesExtensions
    {
        public static string ToUrlQueryParameters(this ImageAnalysisVisualFeatures visualFeatures)
        {
            return UrlQueryParameterFromEnumFormatter.ToUrlQueryParameters<ImageAnalysisVisualFeatures>(visualFeatures, ApiConstants.ImageAnalysisVisualFeaturesUrlParameterName);
        }
       
    }
}

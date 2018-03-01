using Glav.CognitiveServices.FluentApi.ComputerVision.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Communication;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public static class ImageAnalysisDetailsExtensions
    {
        public static string ToUrlQueryParameters(this ImageAnalysisDetails details)
        {
            return UrlQueryParameterFromEnumFormatter.ToUrlQueryParameters<ImageAnalysisDetails>(details, ApiConstants.ImageAnalysisDetailsUrlParameterName);
        }

    }
}

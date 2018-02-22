using Glav.CognitiveServices.FluentApi.ComputerVision.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    [Flags]
    public enum ImageAnalysisDetails
    {
        Default = 0,   // Specify no features explicitly and just ask for a default analysis
        Celebrities = 1,// - identifies celebrities if detected in the image.
        Landmarks = 2// - identifies landmarks if detected in the image.    
    }
    public static class ImageAnalysisDetailsExtensions
    {
        public static string ToUrlQueryParameters(this ImageAnalysisDetails details)
        {
            return UrlQueryParameterFromEnumFormatter.ToUrlQueryParameters<ImageAnalysisDetails>(details, ApiConstants.ImageAnalysisDetailsUrlParameterName);
        }

    }
}

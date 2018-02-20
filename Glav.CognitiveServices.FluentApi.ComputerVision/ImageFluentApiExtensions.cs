using Glav.CognitiveServices.FluentApi.ComputerVision.Configuration;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public static class ImageFluentApiExtensions
    {
        public static ImageAnalysisSettings AddImageAnalysis(this ImageAnalysisSettings apiAnalysis, string url, 
                ImageAnalysisVisualFeatures visualFeatures = ImageAnalysisVisualFeatures.Default, 
                ImageAnalysisDetails imageDetails = ImageAnalysisDetails.Default,
                SupportedLanguageType language = SupportedLanguageType.Unspecified)
        {
            apiAnalysis.ActionsToPerform.Add(ApiActionType.ComputerVisionImageAnalysis, new ImageAnalysisActionData(new Uri(url),
                                                                                                visualFeatures, imageDetails,language));
            return apiAnalysis;
        }
    }
}

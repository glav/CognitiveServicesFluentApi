using Glav.CognitiveServices.FluentApi.ComputerVision.Configuration;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.IO;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public static class ImageFluentApiExtensions
    {
        public static ImageAnalysisSettings AddUrlForImageAnalysis(this ImageAnalysisSettings apiAnalysis, string url, 
                ImageAnalysisVisualFeatures visualFeatures = ImageAnalysisVisualFeatures.None, 
                ImageAnalysisDetails imageDetails = ImageAnalysisDetails.None,
                SupportedLanguageType language = SupportedLanguageType.Unspecified)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<ImageAnalysisActionData>(ApiActionType.ComputerVisionImageAnalysis);
            actionData.Add(new Uri(url),visualFeatures, imageDetails,language);
            return apiAnalysis;
        }

        public static ImageAnalysisSettings AddFileForImageAnalysis(this ImageAnalysisSettings apiAnalysis, string filename,
                ImageAnalysisVisualFeatures visualFeatures = ImageAnalysisVisualFeatures.None,
                ImageAnalysisDetails imageDetails = ImageAnalysisDetails.None,
                SupportedLanguageType language = SupportedLanguageType.Unspecified)
        {
            var bytes = File.ReadAllBytes(filename);
            return AddFileForImageAnalysis(apiAnalysis, bytes, visualFeatures, imageDetails, language);
        }

        public static ImageAnalysisSettings AddFileForImageAnalysis(this ImageAnalysisSettings apiAnalysis, byte[] imageData,
        ImageAnalysisVisualFeatures visualFeatures = ImageAnalysisVisualFeatures.None,
        ImageAnalysisDetails imageDetails = ImageAnalysisDetails.None,
        SupportedLanguageType language = SupportedLanguageType.Unspecified)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<ImageAnalysisActionData>(ApiActionType.ComputerVisionImageAnalysis);
            actionData.Add(imageData, visualFeatures, imageDetails, language);
            return apiAnalysis;
        }

        public static BoundingBoxCoordinates GetBoundingBoxCoordinates(this IBoundingBox boundingBoxObject)
        {
            return BoundingBoxCoordinates.Parse(boundingBoxObject.boundingBox);
        }

        public static OcrTextOrientation GetOrientation(this OcrAnalysisResult result)
        {
            return OcrTextrientationExtensions.ParseOrientation(result.ResponseData.orientation);
        }

    }
}

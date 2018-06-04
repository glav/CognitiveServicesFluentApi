﻿using Glav.CognitiveServices.FluentApi.ComputerVision.Configuration;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.IO;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public static class ImageFluentApiExtensions
    {
        public static ImageAnalysisSettings AddImageAnalysis(this ImageAnalysisSettings apiAnalysis, string url, 
                ImageAnalysisVisualFeatures visualFeatures = ImageAnalysisVisualFeatures.Default, 
                ImageAnalysisDetails imageDetails = ImageAnalysisDetails.Default,
                SupportedLanguageType language = SupportedLanguageType.Unspecified)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<ImageAnalysisActionData>(ApiActionType.ComputerVisionImageAnalysis);
            actionData.Add(new Uri(url),visualFeatures, imageDetails,language);
            return apiAnalysis;
        }

        public static ImageAnalysisSettings AddImageAnalysisForFile(this ImageAnalysisSettings apiAnalysis, string filename,
                ImageAnalysisVisualFeatures visualFeatures = ImageAnalysisVisualFeatures.Default,
                ImageAnalysisDetails imageDetails = ImageAnalysisDetails.Default,
                SupportedLanguageType language = SupportedLanguageType.Unspecified)
        {
            var bytes = File.ReadAllBytes(filename);
            return AddImageAnalysisForFile(apiAnalysis, bytes, visualFeatures, imageDetails, language);
        }

        public static ImageAnalysisSettings AddImageAnalysisForFile(this ImageAnalysisSettings apiAnalysis, byte[] imageData,
        ImageAnalysisVisualFeatures visualFeatures = ImageAnalysisVisualFeatures.Default,
        ImageAnalysisDetails imageDetails = ImageAnalysisDetails.Default,
        SupportedLanguageType language = SupportedLanguageType.Unspecified)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<ImageAnalysisActionData>(ApiActionType.ComputerVisionImageAnalysis);
            actionData.Add(imageData, visualFeatures, imageDetails, language);
            return apiAnalysis;
        }

    }
}

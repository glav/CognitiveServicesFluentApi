using Glav.CognitiveServices.FluentApi.ComputerVision.Configuration;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.IO;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public static class OcrFluentApiExtensions
    {
        public static ImageAnalysisSettings AddUrlForImageAnalysis(this ImageAnalysisSettings apiAnalysis, string url, 
                bool detectOrientation,
                SupportedLanguageType language = SupportedLanguageType.Unspecified)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<OcrAnalysisActionData>(ApiActionType.ComputerVisionOcrAnalysis);
            actionData.Add(new Uri(url),detectOrientation,language);
            return apiAnalysis;
        }

        public static ImageAnalysisSettings AddFileForImageAnalysis(this ImageAnalysisSettings apiAnalysis, string filename,
                bool detectOrientation,
                SupportedLanguageType language = SupportedLanguageType.Unspecified)
        {
            var bytes = File.ReadAllBytes(filename);
            return AddFileForImageAnalysis(apiAnalysis, bytes, detectOrientation, language);
        }

        public static ImageAnalysisSettings AddFileForImageAnalysis(this ImageAnalysisSettings apiAnalysis, byte[] imageData,
                bool detectOrientation,
                SupportedLanguageType language = SupportedLanguageType.Unspecified)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<OcrAnalysisActionData>(ApiActionType.ComputerVisionOcrAnalysis);
            actionData.Add(imageData,detectOrientation, language);
            return apiAnalysis;
        }

    }
}

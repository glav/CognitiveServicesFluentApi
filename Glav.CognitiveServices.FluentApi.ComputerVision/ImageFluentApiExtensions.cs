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
        public static ImageAnalysisSettings AddUrlForOcrAnalysis(this ImageAnalysisSettings apiAnalysis, string url, 
                bool detectOrientation,
                SupportedLanguageType language = SupportedLanguageType.Unspecified)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<OcrAnalysisActionData>(ComputerVisionApiOperations.OcrAnalysis);
            actionData.Add(new Uri(url),detectOrientation,language);
            return apiAnalysis;
        }

        public static ImageAnalysisSettings AddFileForOcrAnalysis(this ImageAnalysisSettings apiAnalysis, string filename,
                bool detectOrientation,
                SupportedLanguageType language = SupportedLanguageType.Unspecified)
        {
            var bytes = File.ReadAllBytes(filename);
            return AddFileForOcrAnalysis(apiAnalysis, bytes, detectOrientation, language);
        }

        public static ImageAnalysisSettings AddFileForOcrAnalysis(this ImageAnalysisSettings apiAnalysis, byte[] imageData,
                bool detectOrientation,
                SupportedLanguageType language = SupportedLanguageType.Unspecified)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<OcrAnalysisActionData>(ComputerVisionApiOperations.OcrAnalysis);
            actionData.Add(imageData,detectOrientation, language);
            return apiAnalysis;
        }

    }
}

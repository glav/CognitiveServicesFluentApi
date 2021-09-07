using Glav.CognitiveServices.FluentApi.ComputerVision.Configuration;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.IO;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public static class ReadImageFluentApiExtensions
    {
        public static ImageAnalysisSettings AddUrlForReadImageAnalysis(this ImageAnalysisSettings apiAnalysis, string url,
                SupportedLanguageType language)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<ReadImageAnalysisActionData>(ComputerVisionApiOperations.ReadImage);
            actionData.Add(new Uri(url),language);
            return apiAnalysis;
        }

        public static ImageAnalysisSettings AddFileForReadImageAnalysis(this ImageAnalysisSettings apiAnalysis, string filename,
                SupportedLanguageType language)
        {
            var bytes = File.ReadAllBytes(filename);
            return AddFileForReadImageAnalysis(apiAnalysis, bytes, language);
        }

        public static ImageAnalysisSettings AddFileForReadImageAnalysis(this ImageAnalysisSettings apiAnalysis, byte[] imageData,
                SupportedLanguageType language)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<ReadImageAnalysisActionData>(ComputerVisionApiOperations.ReadImage);
            actionData.Add(imageData,language);
            return apiAnalysis;
        }

    }
}

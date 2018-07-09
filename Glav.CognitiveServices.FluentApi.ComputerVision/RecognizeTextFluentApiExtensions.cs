using Glav.CognitiveServices.FluentApi.ComputerVision.Configuration;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.IO;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public static class RecognizeTextFluentApiExtensions
    {
        public static ImageAnalysisSettings AddUrlForRecognizeTextAnalysis(this ImageAnalysisSettings apiAnalysis, string url,
                RecognizeTextMode mode)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<RecognizeTextAnalysisActionData>(ApiActionType.ComputerVisionRecognizeText);
            actionData.Add(new Uri(url),mode);
            return apiAnalysis;
        }

        public static ImageAnalysisSettings AddFileForRecognizeTextAnalysis(this ImageAnalysisSettings apiAnalysis, string filename,
                RecognizeTextMode mode)
        {
            var bytes = File.ReadAllBytes(filename);
            return AddFileForRecognizeTextAnalysis(apiAnalysis, bytes, mode);
        }

        public static ImageAnalysisSettings AddFileForRecognizeTextAnalysis(this ImageAnalysisSettings apiAnalysis, byte[] imageData,
                RecognizeTextMode mode)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<RecognizeTextAnalysisActionData>(ApiActionType.ComputerVisionRecognizeText);
            actionData.Add(imageData,mode);
            return apiAnalysis;
        }

    }
}

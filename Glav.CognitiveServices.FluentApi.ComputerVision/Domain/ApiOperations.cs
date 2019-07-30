using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public static class ComputerVisionApiOperations
    {
        public const string Category = "ComputerVision";
        static ComputerVisionApiOperations()
        {
            ImageAnalysis = new ImageAnalysisApiOperation();
            OcrAnalysis = new OcrAnalysisApiOperation();
            RecognizeText = new RecognizeTextApiOperation();
        }
        public static ImageAnalysisApiOperation ImageAnalysis { get; }
        public static OcrAnalysisApiOperation OcrAnalysis { get; }
        public static RecognizeTextApiOperation RecognizeText { get; }

    }

    

    public class ImageAnalysisApiOperation : ApiActionDefinition
    {
        public ImageAnalysisApiOperation() : base(HttpMethod.Post, ComputerVisionApiOperations.Category)
        {
        }
    }
    public class OcrAnalysisApiOperation : ApiActionDefinition
    {
        public OcrAnalysisApiOperation() : base(HttpMethod.Post, ComputerVisionApiOperations.Category)
        {
        }
    }
    public class RecognizeTextApiOperation : ApiActionDefinition
    {
        public RecognizeTextApiOperation() : base(HttpMethod.Post, ComputerVisionApiOperations.Category)
        {
        }
    }
}

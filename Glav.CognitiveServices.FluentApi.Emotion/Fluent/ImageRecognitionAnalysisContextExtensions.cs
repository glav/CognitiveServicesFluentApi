using Glav.CognitiveServices.FluentApi.Emotion.Domain;
using Glav.CognitiveServices.FluentApi.Emotion.Domain.ApiResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Emotion.Fluent
{
    public static class ImageRecognitionAnalysisContextExtensions
    {
        public static IEnumerable<EmotionImageRecognitionResponseItem> GetFacesRecognised(this ImageRecognitionAnalysisContext imageRecognitionContext)
        {
            if (!imageRecognitionContext.AnalysisResult.ActionSubmittedSuccessfully)
            {
                return new List<EmotionImageRecognitionResponseItem>();
            }
            return imageRecognitionContext.AnalysisResult.ResponseData.faces;
        }
    }
}

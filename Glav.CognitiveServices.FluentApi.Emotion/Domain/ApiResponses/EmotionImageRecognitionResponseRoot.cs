using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Emotion.Domain.ApiResponses
{
    public class EmotionImageRecognitionResponseRoot : IActionResponseRoot
    {
        public EmotionImageRecognitionResponseItem[] faces { get; set; }

        public ApiErrorResponse error { get; set; }
    }

}

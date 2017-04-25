using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Emotion.Domain.ApiResponses
{
    public class EmotionImageRecognitionResponse
    {
        public FaceRectangleResponse faceRectangle { get; set; }
        public ScoresResponse scores { get; set; }
    }

    public class FaceRectangleResponse
    {
        public double left { get; set; }
        public double top { get; set; }
        public double width { get; set; }
        public double height { get; set; }
    }

    public class ScoresResponse
    {
        public double anger { get; set; }
        public double  contempt { get; set; }
        public double disgust { get; set; }
        public double fear { get; set; }
        public double happiness { get; set; }
        public double neutral { get; set; }
        public double sadness { get; set; }
        public double surprise { get; set; }
    }
}

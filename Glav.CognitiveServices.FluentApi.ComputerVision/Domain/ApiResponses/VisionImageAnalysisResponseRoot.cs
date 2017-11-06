using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses
{
    public class VisionImageAnalysisResponseRoot
    {
        public string requestId { get; set; }
        public CategoriesResponseCollection categories { get; set; }
        public AdultResponseItem adult { get; set; }
        public NameConfidenceResponseItem[] tags { get; set; }
        public DescriptionResponseItem description { get; set; }
        public MetadataResponseItem metadata { get; set; }
        public FaceResponseItem[] faces { get; set; }
        public ColorResponseItem color { get; set; }
        public ImageTypeResponseItem imageType { get; set; }
    }


    public class AdultResponseItem
    {
        public bool isAdultContent { get; set; }
        public bool isRacyContent { get; set; }
        public double adultScore { get; set; }
        public double racyScore { get; set; }
    }

    public class DescriptionCaptionResponseItem
    {
        public string text { get; set; }
        public double confidence { get; set; }
    }

    public class MetadataResponseItem
    {
        public double width { get; set; }
        public double height { get; set; }
        public string format { get; set; }
    }

    public class FaceResponseItem
    {
        public int age { get; set; }
        public string gender { get; set; }
        public FaceRectangleResponseItem faceRectangle { get; set; }
    }

    public class ColorResponseItem
    {
        public string dominantColorForeground { get; set; }
        public string dominantColorBackground { get; set; }
        public string[] dominantColors { get; set; }
        public string accentColor { get; set; }
        public bool isBWImg { get; set; }
    }

    public class ImageTypeResponseItem
    {
        public int clipArtType { get; set; }
        public int lineDrawingType { get; set; }
    }

}

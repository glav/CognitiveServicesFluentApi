using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses
{
    public class VisionImageAnalysisResponseRoot
    {
        public string requestId { get; set; }
        public AdultResponseItem adult { get; set; }
        public NameConfidenceResponseItem[] tags { get; set; }
        public DescriptionResponseItem description { get; set; }

    }


    public class AdultResponseItem
    {
        public bool isAdultContent { get; set; }
        public bool isRacyContent { get; set; }
        public double adultScore { get; set; }
        public double racyScore { get; set; }
    }

    public class DescriptionResponseItem
    {
        public string[] tags { get; set; }
        public DescriptionCaptionResponseItem[] captions { get; set; }
    }

    public class DescriptionCaptionResponseItem
    {
        public string text { get; set; }
        public double confidence { get; set; }
    }

}

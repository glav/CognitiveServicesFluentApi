namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses
{
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

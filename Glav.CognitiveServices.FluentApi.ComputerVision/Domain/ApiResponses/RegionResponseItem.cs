namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses
{
    public class RegionResponseItem
    {
        public string boundingBox { get; set; }
        public LineResponseItem[] lines { get; set; }

    }

}

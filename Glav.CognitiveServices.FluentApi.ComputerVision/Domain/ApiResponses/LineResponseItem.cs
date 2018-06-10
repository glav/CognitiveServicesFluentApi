namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses
{
    public class LineResponseItem
    {
        public string boundingBox { get; set; }
        public WordResponseItem[] words { get; set; }
    }

}

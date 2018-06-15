namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses
{
    public class WordResponseItem : IBoundingBox
    {
        public string boundingBox { get; set; }

        public string text { get; set; }

    }

}

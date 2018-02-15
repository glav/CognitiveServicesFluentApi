namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses
{
    public class AdultResponseItem
    {
        public bool isAdultContent { get; set; }
        public bool isRacyContent { get; set; }
        public double adultScore { get; set; }
        public double racyScore { get; set; }
    }

}

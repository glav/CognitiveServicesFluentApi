using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses
{
    public class VisionOcrAnalysisResponseRoot : IActionResponseRoot
    {
        public string orientation { get; set; }
        public double textAngle { get; set; }
        public string language { get; set; }
        public RegionResponseItem[] regions { get; set; }

        public RequestIdErrorResponse error { get; set; }
    }

}

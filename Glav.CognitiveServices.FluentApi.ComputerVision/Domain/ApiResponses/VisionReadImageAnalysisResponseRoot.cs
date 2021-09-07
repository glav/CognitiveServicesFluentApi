using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses
{
    public class VisionReadImageAnalysisResponseRoot : IActionResponseRoot
    {
        public string status { get; set; }
        public AnalyzeResultItem analyzeResult { get; set; }
        // std error response
        public RequestIdErrorResponse error { get; set; }
    }

    public class AnalyzeResultItem
    {
        public string version { get; set; }
        public ReadImageResponseItem[] readResults { get; set; }
    }

    public class ReadImageResponseItem
    {
        public long page { get; set; }
         public string language { get; set; }
        public double angle { get; set; }
        public long width { get; set; }
        public long height { get; set; }
        public string unit { get; set; }

        public ReadImageLineResponseItem[] lines { get; set; }
    }

    public class ReadImageLineResponseItem
    {
        public int[] boundingBox { get; set; }

        public string text { get; set; }
        public ReadImageWordResponseItem[] words { get; set; }
    }

    public class ReadImageWordResponseItem
    {
        public int[] boundingBox { get; set; }

        public string text { get; set; }
        public double confidence { get; set; }
    }
}

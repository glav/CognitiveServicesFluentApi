using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses
{
    public class VisionRecognizeTextAnalysisResponseRoot : IActionResponseRoot
    {
        public string status { get; set; }
        public RecognitionResultItem recognitionResult { get; set; }
        // std error response
        public ApiErrorResponse error { get; set; }
    }

    public class RecognitionResultItem
    {
        public RecognizeTextLineResponseItem[] lines { get; set; }
    }

    public class RecognizeTextLineResponseItem
    {
        public int[] boundingBox { get; set; }

        public string text { get; set; }
        public RecognizeTextWordResponseItem[] words { get; set; }
    }

    public class RecognizeTextWordResponseItem
    {
        public int[] boundingBox { get; set; }

        public string text { get; set; }
    }
}

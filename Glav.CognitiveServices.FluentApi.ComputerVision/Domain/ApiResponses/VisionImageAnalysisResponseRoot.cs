using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses
{
    public class VisionImageAnalysisResponseRoot : IActionResponseRoot
    {
        public string requestId { get; set; }
        public CategoriesResponseItem[] categories { get; set; }
        public AdultResponseItem adult { get; set; }
        public NameConfidenceResponseItem[] tags { get; set; }
        public DescriptionResponseItem description { get; set; }
        public MetadataResponseItem metadata { get; set; }
        public FaceResponseItem[] faces { get; set; }
        public ColorResponseItem color { get; set; }
        public ImageTypeResponseItem imageType { get; set; }
        public ApiErrorResponse error { get; set; }
    }

}

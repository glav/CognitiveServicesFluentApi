namespace Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses
{
    public class FaceIdentifyResponseItem
    {
        public string faceId { get; set; }
        public FaceCandidate[] candidates { get; set; }
    }

    public class FaceCandidate
    {
        public string personId { get; set; }
        public double confidence { get; set; }
    }

}

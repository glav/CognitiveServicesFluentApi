namespace Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses
{
    public class FaceDetectResponseItem
    {
        public string faceId { get; set; }
        public FaceAttributesResponseItem faceAttributes { get; set; }

        public FaceLandmarksResponseItem faceLandmarks { get; set; }
        public FaceRectangleResponseItem faceRectangle { get; set; }
    }

}

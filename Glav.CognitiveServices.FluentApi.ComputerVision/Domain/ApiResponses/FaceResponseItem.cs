namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses
{
    public class FaceResponseItem
    {
        public int age { get; set; }
        public string gender { get; set; }
        public FaceRectangleResponseItem faceRectangle { get; set; }
    }

}

namespace Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses
{
    public class FaceAttributesResponseItem
    {
        public AccessoryResponseItem[] accessories { get; set; }
        public double age { get; set; }
        public BlurResponseItem blur { get; set; }
        public FaceEmotionResponseItem emotion { get; set; }
        public ExposureResponseItem exposure { get; set; }
        public FacialHairResponseItem facialHair { get; set; }
        public string gender { get; set; }
        public string glasses { get; set; }
        public HairResponseItem hair {get;set;}
        public HeadPoseResponseItem headPose { get; set; }
        public MakeupResponseItem makeup { get; set; }
        public NoiseResponseItem noise { get; set; }
        public OcclusionResponseItem occlusion { get; set; }
        public double smile { get; set; }
    }

}

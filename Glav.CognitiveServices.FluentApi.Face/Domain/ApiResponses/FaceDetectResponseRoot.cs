using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses
{
    public class FaceDetectResponseRoot : IActionResponseRoot
    {
        public ApiErrorResponse error { get; set; }
        public FaceDetectResponseItem[] detectedFaces { get; set; }
    }

    public class FaceDetectResponseItem
    {
        public string faceId { get; set; }
        public FaceAttributesResponseItem faceAttributes { get; set; }

        public FaceLandmarksResponseItem faceLandmarks { get; set; }
        public FaceRectangleResponseItem faceRectangle { get; set; }
    }

    public class FaceAttributesResponseItem
    {
        public AccessoryResponseItem[] accessories { get; set; }
        public int age { get; set; }
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

    public class FaceLandmarksResponseItem
    {
        public CoordinateResponseItem eyeLeftBottom { get; set; }

        public CoordinateResponseItem eyeLeftInner { get; set; }
        public CoordinateResponseItem eyeLeftOuter { get; set; }
        public CoordinateResponseItem eyeLeftTop { get; set; }
        public CoordinateResponseItem eyeRightBottom { get; set; }
        public CoordinateResponseItem eyeRightInner { get; set; }
        public CoordinateResponseItem eyeRightOuter { get; set; }
        public CoordinateResponseItem eyeRightTop { get; set; }
        public CoordinateResponseItem eyebrowLeftInner { get; set; }
        public CoordinateResponseItem eyebrowLeftOuter { get; set; }
        public CoordinateResponseItem eyebrowRightInner { get; set; }
        public CoordinateResponseItem eyebrowRightOuter { get; set; }
        public CoordinateResponseItem mouthLeft { get; set; }
        public CoordinateResponseItem mouthRight { get; set; }
        public CoordinateResponseItem noseLeftAlarOutTip { get; set; }
        public CoordinateResponseItem noseLeftAlarTop { get; set; }
        public CoordinateResponseItem noseRightAlarOutTip { get; set; }
        public CoordinateResponseItem noseRightAlarTop { get; set; }
        public CoordinateResponseItem noseRootLeft { get; set; }
        public CoordinateResponseItem noseRootRight { get; set; }
        public CoordinateResponseItem noseTip { get; set; }
        public CoordinateResponseItem pupilLeft { get; set; }
        public CoordinateResponseItem pupilRight { get; set; }
        public CoordinateResponseItem underLipBottom { get; set; }
        public CoordinateResponseItem underLipTop { get; set; }
        public CoordinateResponseItem upperLipBottom { get; set; }
        public CoordinateResponseItem upperLipTop { get; set; }
    }

    public class FaceRectangleResponseItem
    {
        public double left { get; set; }
        public double top { get; set; }
        public double width { get; set; }
        public double height { get; set; }
    }

    public class FaceEmotionResponseItem
    {
        public double anger { get; set; }
        public double contempt { get; set; }
        public double disgust { get; set; }
        public double fear { get; set; }
        public double happiness { get; set; }
        public double neutral { get; set; }
        public double sadness { get; set; }
        public double surprise { get; set; }
    }

    public class AccessoryResponseItem
    {
        public double confidence { get; set; }
        public string type { get; set; }
    }
    public class BlurResponseItem
    {
        public string blurLevel { get; set; }
        public double value { get; set; }
    }
    public class CoordinateResponseItem
    {
        public double x { get; set; }
        public double y { get; set; }
    }
    public class ExposureResponseItem
    {
        public string exposureLevel { get; set; }
        public double value { get; set; }
    }
    public class FacialHairResponseItem
    {
        public double beard { get; set; }
        public double moustache { get; set; }
        public double sideburns { get; set; }
    }
    public class HairResponseItem
    {
        public double bald { get; set; }
        public HairColorResponseItem[] hairColor { get; set; }
        public bool invisible { get; set; }
    }
    public class HairColorResponseItem
    {
        public string color { get; set; }
        public double confidence { get; set; }
    }
    public class HeadPoseResponseItem
    {
        public double pitch { get; set; }
        public double roll { get; set; }
        public double yaw { get; set; }
    }
    public class MakeupResponseItem
    {
        public bool eyeMakeup { get; set; }
        public bool lipMakeup { get; set; }
    }
    public class NoiseResponseItem
    {
        public string noiseLevel { get; set; }
        public double value { get; set; }
    }

    public class OcclusionResponseItem
    {
        public bool eyeOccluded { get; set; }
        public bool foreheadOccluded { get; set; }
        public bool mouthOccluded { get; set; }
    }

}

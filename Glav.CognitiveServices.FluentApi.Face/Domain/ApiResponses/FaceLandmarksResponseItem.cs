namespace Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses
{
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

}

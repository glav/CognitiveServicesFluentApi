using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    [Flags]
    public enum FaceDetectionAttributes
    {
        None = 0,
        Age = 1,
        Gender = 2,
        HeadPose = 4,
        Smile = 8,
        FacialHair = 16,
        Glasses = 32,
        Emotion = 64
    }
}

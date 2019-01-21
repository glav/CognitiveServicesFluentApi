using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    [Flags]
    public enum FaceDetectionAttributes
    {
        None = 0,
        Age = 1 << 0,
        Gender = 1 << 1,
        HeadPose = 1 << 2,
        Smile = 1 << 3,
        FacialHair = 1 << 4,
        Glasses = 1 << 5,
        Emotion = 1 << 6,
        Hair = 1 << 7,
        MakeUp = 1 << 8,
        Occlusion = 1 << 9,
        Accessories = 1 << 10,
        Blur = 1 << 11,
        Exposure = 1 << 12,
        Noise = 1 << 13
    }
}

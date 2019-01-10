using Glav.CognitiveServices.FluentApi.Core;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public enum BlurLevel
    {
        Undefined,
        High,
        Low,
        Medium
    }

    public static class BlurLevelExtensions
    {
        public static BlurLevel ToBlurLevel(this string blurLevelValue)
        {
            return blurLevelValue.ToEnumType<BlurLevel>();
        }
    }

}

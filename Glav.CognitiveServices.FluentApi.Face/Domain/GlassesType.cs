using Glav.CognitiveServices.FluentApi.Core;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public enum GlassesType
    {
        NoGlasses,
        ReadingGlasses,
        Sunglasses,
        SwimmingGoggles
    }

    public static class GlassTypeExtensions
    {
        public static GlassesType ToGlassesType(this string glassesValue)
        {
            return glassesValue.ToEnumType<GlassesType>();
        }
    }

}

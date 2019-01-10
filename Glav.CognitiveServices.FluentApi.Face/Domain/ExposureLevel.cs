using Glav.CognitiveServices.FluentApi.Core;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public enum ExposureLevel
    {
        Undefined,
        GoodExposure,
        OverExposure,
        UnderExposure
    }

    public static class ExposeLevelExtensions
    {
        public static ExposureLevel ToExposureLevel(this string exposureLevelValue)
        {
            return exposureLevelValue.ToEnumType<ExposureLevel>();
        }
    }

}

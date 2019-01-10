using Glav.CognitiveServices.FluentApi.Core;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public enum NoiseLevel
    {
        Undefined,
        High,
        Low,
        Medium
    }

    public static class NoiseLevelExtensions
    {
        public static NoiseLevel ToNoiseLevel(this string noiseLevelValue)
        {
            return noiseLevelValue.ToEnumType<NoiseLevel>();
        }
    }

}

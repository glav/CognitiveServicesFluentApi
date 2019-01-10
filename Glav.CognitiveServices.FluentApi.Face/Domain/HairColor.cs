using Glav.CognitiveServices.FluentApi.Core;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public enum HairColor
    {
        Unknown,
        Black,
        Blond,
        Brown,
        Gray,
        Other,
        Red,
        White
    }

    public static class HairColorExtensions
    {
        public static HairColor ToHairColor(this string hairColorValue)
        {
            return hairColorValue.ToEnumType<HairColor>();
        }
    }

}

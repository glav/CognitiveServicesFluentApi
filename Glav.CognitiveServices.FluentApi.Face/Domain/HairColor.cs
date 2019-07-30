using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Extensions;

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

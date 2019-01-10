﻿using Glav.CognitiveServices.FluentApi.Core;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public enum GenderType
    {
        Genderless,
        Male,
        Female
    }

    public static class GenderTypeExtensions
    {
        public static GenderType ToGenderType(this string genderValue)
        {
            return genderValue.ToEnumType<GenderType>();
        }
    }

}

using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core
{
    public sealed class SupportedLanguageItem
    {
        public SupportedLanguageItem(SupportedLanguageType languageType, string code, IEnumerable<ApiActionType> apiSupport)
        {
            LanguageType = languageType;
            Code = code;
            ApiSupport = apiSupport;
        }

        public SupportedLanguageType LanguageType { get; private set; }
        public string Code { get; private set; }
        public IEnumerable<ApiActionType> ApiSupport { get; }
    }

    public enum SupportedLanguageType
    {
        Unspecified,
        English,
        Spanish,
        French,
        Portuguese,
        German,
        Japanese,
        SimplifiedChinese,
        ChineseTraditional,
        Czech,
        Danish,
        Dutch,
        Finnish,
        Greek,
        Hungarian,
        Italian,
        Korean,
        Norwegian,
        Polish,
        Russian,
        Swedish,
        Turkish,
        Arabic,
        Romanian,
        SerbianCyrillic,
        SerbianLatin,
        Slovak

    }
}

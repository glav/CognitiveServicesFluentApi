using Glav.CognitiveServices.Api.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glav.CognitiveServices.Api
{
    public sealed class SupportedLanguageItem
    {
        private IEnumerable<ApiActionType> _apiSupport;
        public SupportedLanguageItem(SupportedLanguageType languageType, string code, IEnumerable<ApiActionType> apiSupport)
        {
            LanguageType = languageType;
            Code = code;
            _apiSupport = apiSupport;
        }

        public SupportedLanguageType LanguageType { get; private set; }
        public string Code { get; private set; }
        public IEnumerable<ApiActionType> ApiSupport { get { return _apiSupport.ToArray(); } }
    }

    public static class LanguageListBuilder
    {
        private static List<SupportedLanguageItem> _languageList = new List<SupportedLanguageItem>();
        static LanguageListBuilder()
        {
            BuildSupportedLanguagesList();
        }
        public static void BuildSupportedLanguagesList()
        {
            _languageList.Add(new SupportedLanguageItem(SupportedLanguageType.English, "en", new ApiActionType[] { ApiActionType.TextAnalyticsSentiment, ApiActionType.TextAnalyticsKeyphrases }));
            _languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Spanish, "es", new ApiActionType[] { ApiActionType.TextAnalyticsSentiment, ApiActionType.TextAnalyticsKeyphrases }));
            _languageList.Add(new SupportedLanguageItem(SupportedLanguageType.French, "fr", new ApiActionType[] { ApiActionType.TextAnalyticsSentiment}));
            _languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Portuguese, "pt", new ApiActionType[] { ApiActionType.TextAnalyticsSentiment}));
            _languageList.Add(new SupportedLanguageItem(SupportedLanguageType.German, "de", new ApiActionType[] { ApiActionType.TextAnalyticsKeyphrases }));
            _languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Japanese, "ja", new ApiActionType[] { ApiActionType.TextAnalyticsKeyphrases }));
        }

        public static string ToCode(this SupportedLanguageType languageType)
        {
            var item = _languageList.FirstOrDefault(l => l.LanguageType == languageType);
            if (item == null)
            {
                return _languageList.First(l => l.LanguageType == SupportedLanguageType.English).Code;
            }
            return item.Code;
        }
    }

    public enum SupportedLanguageType
    {
        English,
        Spanish,
        French,
        Portuguese,
        German,
        Japanese
    }
}

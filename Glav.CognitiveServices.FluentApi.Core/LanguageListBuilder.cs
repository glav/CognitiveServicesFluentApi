using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System.Collections.Generic;

namespace Glav.CognitiveServices.FluentApi.Core
{
    public static class LanguageListBuilder
    {
        private static List<SupportedLanguageItem> _languageList = new List<SupportedLanguageItem>();
        static LanguageListBuilder()
        {
            BuildSupportedLanguagesList();
        }
        public static void BuildSupportedLanguagesList()
        {
            _languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Unspecified, string.Empty, new ApiActionType[] { ApiActionType.TextAnalyticsKeyphrases }));
            _languageList.Add(new SupportedLanguageItem(SupportedLanguageType.English, "en", new ApiActionType[] { ApiActionType.TextAnalyticsSentiment, ApiActionType.TextAnalyticsKeyphrases, ApiActionType.ComputerVisionImageAnalysis }));
            _languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Spanish, "es", new ApiActionType[] { ApiActionType.TextAnalyticsSentiment, ApiActionType.TextAnalyticsKeyphrases }));
            _languageList.Add(new SupportedLanguageItem(SupportedLanguageType.French, "fr", new ApiActionType[] { ApiActionType.TextAnalyticsSentiment}));
            _languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Portuguese, "pt", new ApiActionType[] { ApiActionType.TextAnalyticsSentiment}));
            _languageList.Add(new SupportedLanguageItem(SupportedLanguageType.German, "de", new ApiActionType[] { ApiActionType.TextAnalyticsKeyphrases }));
            _languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Japanese, "ja", new ApiActionType[] { ApiActionType.TextAnalyticsKeyphrases }));
            _languageList.Add(new SupportedLanguageItem(SupportedLanguageType.SimplifiedChinese, "zh", new ApiActionType[] { ApiActionType.ComputerVisionImageAnalysis }));
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

        public static string ToUrlQueryParameter(this SupportedLanguageType languageType)
        {
            var code = languageType.ToCode();
            return code == string.Empty ? string.Empty : $"{ApiConstants.LanguageUrlParameterName}={code}";
        }

    }
}

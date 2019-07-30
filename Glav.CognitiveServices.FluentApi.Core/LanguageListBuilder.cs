using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.Core
{
    public static class LanguageListBuilder
    {
        private static object _lockObject = new object();
        private static List<SupportedLanguageItem> _languageList = new List<SupportedLanguageItem>();
        static LanguageListBuilder()
        {
        }

        public static void AddSupport(ILanguageApiSupportItem languageSupport)
        {
            lock (_lockObject)
            {
                AddSupport(languageSupport.GetLanguagesForApis());
            }
        }

        private static void AddSupport(SupportedLanguageItem item)
        {
            var existingItem = _languageList.FirstOrDefault(i => i.LanguageType == item.LanguageType);
            if (existingItem == null)
            {
                _languageList.Add(item);
            } else
            {
                existingItem.ApiSupport.ToList().AddRange(item.ApiSupport);
            }
        }
        private static void AddSupport(IEnumerable<SupportedLanguageItem> items)
        {
            foreach (var item in items)
            {
                AddSupport(item);
            }
        }
        private static void BuildSupportedLanguagesList()
        {
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Unspecified, string.Empty, 
            //                    new ApiActionDefinition[] {
            //                        ApiOperations.TextAnalyticsKeyphrases,
            //                        ApiActionType.ComputerVisionImageAnalysis,
            //                        ApiActionType.ComputerVisionOcrAnalysis}));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.English, "en",
            //                    new ApiActionType[] {
            //                        ApiActionType.TextAnalyticsSentiment,
            //                        ApiActionType.TextAnalyticsKeyphrases,
            //                        ApiActionType.ComputerVisionImageAnalysis,
            //                        ApiActionType.ComputerVisionOcrAnalysis}));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Spanish, "es",
            //                    new ApiActionType[] {
            //                        ApiActionType.TextAnalyticsSentiment,
            //                        ApiActionType.TextAnalyticsKeyphrases,
            //                        ApiActionType.ComputerVisionOcrAnalysis}));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.French, "fr", 
            //                    new ApiActionType[] {
            //                        ApiActionType.TextAnalyticsSentiment,
            //                        ApiActionType.ComputerVisionOcrAnalysis}));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Portuguese, "pt", 
            //                    new ApiActionType[] {
            //                        ApiActionType.TextAnalyticsSentiment,
            //                        ApiActionType.ComputerVisionOcrAnalysis}));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.German, "de", 
            //                    new ApiActionType[] {
            //                        ApiActionType.TextAnalyticsKeyphrases,
            //                        ApiActionType.ComputerVisionOcrAnalysis}));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Japanese, "ja", 
            //                    new ApiActionType[] {
            //                        ApiActionType.TextAnalyticsKeyphrases,
            //                        ApiActionType.ComputerVisionOcrAnalysis}));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.SimplifiedChinese, "zh",
            //                    new ApiActionType[] {
            //                        ApiActionType.ComputerVisionImageAnalysis,
            //                        ApiActionType.ComputerVisionOcrAnalysis}));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.ChineseTraditional, "zh-Hant",
            //                    new ApiActionType[] {
            //                        ApiActionType.ComputerVisionOcrAnalysis }));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Czech, "cs",
            //                    new ApiActionType[] {
            //                        ApiActionType.ComputerVisionOcrAnalysis }));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Danish, "da",
            //                    new ApiActionType[] {
            //                        ApiActionType.ComputerVisionOcrAnalysis }));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Dutch, "nl",
            //                    new ApiActionType[] {
            //                        ApiActionType.ComputerVisionOcrAnalysis }));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Finnish, "fi",
            //                    new ApiActionType[] {
            //                        ApiActionType.ComputerVisionOcrAnalysis }));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Greek, "gr",
            //                    new ApiActionType[] {
            //                        ApiActionType.ComputerVisionOcrAnalysis }));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Hungarian, "hr",
            //                    new ApiActionType[] {
            //                        ApiActionType.ComputerVisionOcrAnalysis }));

            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Italian, "it",
            //                    new ApiActionType[] {
            //                        ApiActionType.ComputerVisionOcrAnalysis}));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Korean, "ko",
            //                    new ApiActionType[] {
            //                        ApiActionType.ComputerVisionOcrAnalysis }));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Norwegian, "nb",
            //                    new ApiActionType[] {
            //                        ApiActionType.ComputerVisionOcrAnalysis }));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Polish, "pl",
            //                    new ApiActionType[] {
            //                        ApiActionType.ComputerVisionOcrAnalysis }));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Russian, "ru",
            //                    new ApiActionType[] {
            //                        ApiActionType.ComputerVisionOcrAnalysis}));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Swedish, "sv",
            //                    new ApiActionType[] {
            //                        ApiActionType.ComputerVisionOcrAnalysis}));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Turkish, "tr",
            //                    new ApiActionType[] {
            //                        ApiActionType.ComputerVisionOcrAnalysis }));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Arabic, "ar",
            //                    new ApiActionType[] {
            //                        ApiActionType.ComputerVisionOcrAnalysis }));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.SerbianCyrillic, "sr-Cyrl",
            //                    new ApiActionType[] {
            //                        ApiActionType.ComputerVisionOcrAnalysis }));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.SerbianLatin, "sr-Latn",
            //                    new ApiActionType[] {
            //                        ApiActionType.ComputerVisionOcrAnalysis }));
            //_languageList.Add(new SupportedLanguageItem(SupportedLanguageType.Slovak, "sk",
            //                    new ApiActionType[] {
            //                        ApiActionType.ComputerVisionOcrAnalysis }));
        }

        public static SupportedLanguageItem[] GetAllSupportedLanguages()
        {
            return _languageList.ToArray();
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

    public interface ILanguageApiSupportItem
    {
        IEnumerable<SupportedLanguageItem> GetLanguagesForApis();
    }
}

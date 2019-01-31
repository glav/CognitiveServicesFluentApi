using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System.Collections.Generic;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Configuration
{
    public class SupportedLanguages : ILanguageApiSupportItem
    {
        public static void Setup()
        {
            LanguageListBuilder.AddSupport(new SupportedLanguages());
        }

        public IEnumerable<SupportedLanguageItem> GetLanguagesForApis()
        {
            var items = new List<SupportedLanguageItem>();
            items.Add(new SupportedLanguageItem(SupportedLanguageType.Unspecified, string.Empty,
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.ImageAnalysis,
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.English, "en",
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.ImageAnalysis,
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.Spanish, "es",
                                new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.French, "fr",
                                new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.Portuguese, "pt",
                                new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.German, "de",
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.Japanese, "ja",
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));

            items.Add(new SupportedLanguageItem(SupportedLanguageType.SimplifiedChinese, "zh",
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.ImageAnalysis,
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.ChineseTraditional, "zh-Hant",
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.Czech, "cs",
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.Danish, "da",
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.Dutch, "nl",
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.Finnish, "fi",
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.Greek, "gr",
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.Hungarian, "hr",
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));

            items.Add(new SupportedLanguageItem(SupportedLanguageType.Italian, "it",
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.Korean, "ko",
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.Norwegian, "nb",
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.Polish, "pl",
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.Russian, "ru",
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.Swedish, "sv",
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.Turkish, "tr",
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.Arabic, "ar",
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.SerbianCyrillic, "sr-Cyrl",
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.SerbianLatin, "sr-Latn",
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.Slovak, "sk",
                            new ApiActionDefinition[] {
                                ComputerVisionApiOperations.OcrAnalysis
                            }));
            return items;


        }
    }
}

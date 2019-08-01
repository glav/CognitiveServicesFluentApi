using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;
using System.Collections.Generic;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
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
                                TextAnalyticApiOperations.KeyPhraseAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.English, "en",
                            new ApiActionDefinition[] {
                                TextAnalyticApiOperations.SentimentAnalysis,
                                TextAnalyticApiOperations.KeyPhraseAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.Spanish, "es",
                                new ApiActionDefinition[] {
                                TextAnalyticApiOperations.SentimentAnalysis,
                                TextAnalyticApiOperations.KeyPhraseAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.French, "fr",
                                new ApiActionDefinition[] {
                                TextAnalyticApiOperations.SentimentAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.Portuguese, "pt",
                                new ApiActionDefinition[] {
                                TextAnalyticApiOperations.SentimentAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.German, "de",
                            new ApiActionDefinition[] {
                                TextAnalyticApiOperations.SentimentAnalysis
                            }));
            items.Add(new SupportedLanguageItem(SupportedLanguageType.Japanese, "ja",
                            new ApiActionDefinition[] {
                                TextAnalyticApiOperations.SentimentAnalysis
                            }));

            return items;

        }
    }
}

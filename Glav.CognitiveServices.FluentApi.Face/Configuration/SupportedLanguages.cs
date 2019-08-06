using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using System.Collections.Generic;

namespace Glav.CognitiveServices.FluentApi.Face.Configuration
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
                                FaceApiOperations.FaceDetection, FaceApiOperations.FaceIdentification
                            }));
            return items;
        }
    }
}

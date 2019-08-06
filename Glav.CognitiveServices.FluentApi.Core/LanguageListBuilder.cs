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

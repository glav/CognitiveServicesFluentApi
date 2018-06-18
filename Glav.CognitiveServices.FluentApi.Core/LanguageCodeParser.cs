using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core
{
    public static class LanguageCodeParser
    {
        public static SupportedLanguageItem Parse(string code)
        {
            var list = LanguageListBuilder.GetAllSupportedLanguages();
            return list.FirstOrDefault(l => l.Code == code.ToLowerInvariant());
        }
    }
}

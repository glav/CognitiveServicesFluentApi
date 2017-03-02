using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent
{
    public enum SupportedLanguage
    {
        English
    }

    public static class SupportLanguageExtensions
    {
        private static readonly string[] _languageCodes = new string[]
            {
                "en"
            };

        public static string ToLanguageCode(this SupportedLanguage supportedLanguage)
        {
            return _languageCodes[(int)supportedLanguage];
        }
    }
}

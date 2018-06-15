﻿using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core
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

    public enum SupportedLanguageType
    {
        Unspecified,
        English,
        Spanish,
        French,
        Portuguese,
        German,
        Japanese,
        SimplifiedChinese
    }
}

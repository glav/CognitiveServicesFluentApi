using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic
{
    public static class ConfigurationBuilderExtensions
    {
        public static TextAnalyticAnalysisSettings WithTextAnalyticAnalysisActions(this CoreAnalysisSettings analysisSettings)
        {
            return new TextAnalyticAnalysisSettings(analysisSettings);
        }

    }
}

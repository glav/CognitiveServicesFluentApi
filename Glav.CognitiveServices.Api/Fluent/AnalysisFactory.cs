using Glav.CognitiveServices.Api.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent
{
    public sealed class AnalysisFactory
    {
        public AnalysisFactory(ApiAnalysisSettings apiAnalysisSettings)
        {
            AnalysisSettings = apiAnalysisSettings;
        }

        public ApiAnalysisSettings AnalysisSettings { get; private set; }

        public AnalysisEngine CreateAnalysisEngine()
        {
            var engine = new AnalysisEngine(AnalysisSettings);
            return engine;
        }

    }
}

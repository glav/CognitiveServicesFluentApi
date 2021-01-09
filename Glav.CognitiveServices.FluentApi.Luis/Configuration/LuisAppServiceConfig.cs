﻿using System;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Luis.Configuration;
using Glav.CognitiveServices.FluentApi.Luis.Domain;

namespace Glav.CognitiveServices.FluentApi.Luis.Configuration
{
    public class LuisAppServiceConfig : ApiServiceUriFragment
    {
        public override string Template => ApiConstants.LUIS_API_CATEGORY_PREFIX + "{0}/apps";
        public override string Version => ApiConstants.DEFAULT_LUIS_VERSION;

        public override ApiActionDefinition ApiAction => LuisAnalysisApiOperations.LuisAnalysis;
    }
}

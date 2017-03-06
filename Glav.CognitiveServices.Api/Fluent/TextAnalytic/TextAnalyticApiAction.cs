using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.Api.Configuration;
using Glav.CognitiveServices.Api.Fluent.Contracts;
using Glav.CognitiveServices.Api.Fluent;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic
{
    public class TextAnalyticApiAction : ApiAction
    {
        public TextAnalyticApiAction(ApiActionType apiType, TextAnalyticActionData actionData) : base(apiType, actionData)
        {
        }
    }
}

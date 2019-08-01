using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.Parsing;
using System;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain
{
    public sealed class LanguagesResult : BaseApiResponseWithStrategy<LanguagesResultResponseRoot, LanguagesResultResponseRoot, ApiErrorResponse>
    {
        public LanguagesResult(ICommunicationResult apiResult)
            : base(apiResult, new TextAnalyticParsingStrategy<LanguagesResultResponseRoot, LanguagesResultResponseItem>())
        {
            ParseResponseData();
            if (!ActionSubmittedSuccessfully)
            {
                ResponseData = new LanguagesResultResponseRoot { errors = new ApiErrorResponse[] { ParsingStrategy.ResponseError } };
                return;
            }
            ResponseData = ParsingStrategy.ResponseData;
        }
    }
 }

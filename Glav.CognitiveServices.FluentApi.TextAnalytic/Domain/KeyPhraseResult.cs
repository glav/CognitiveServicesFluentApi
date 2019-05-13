using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.Parsing;
using System;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain
{
    public sealed class KeyPhraseResult : BaseApiResponseWithStrategy<KeyPhraseResultResponseRoot, KeyPhraseResultResponseRoot,ApiErrorResponse>
    {
        public KeyPhraseResult(ICommunicationResult apiResult) 
            : base(apiResult, new TextAnalyticParsingStrategy<KeyPhraseResultResponseRoot, KeyPhraseResultResponseItem>())
        {
            ParseResponseData();
            if (!ActionSubmittedSuccessfully)
            {
                ResponseData = new KeyPhraseResultResponseRoot { errors = new ApiErrorResponse[] { ParsingStrategy.ResponseError } };
                return;
            }
            ResponseData = ParsingStrategy.ResponseData;
        }
    }
}

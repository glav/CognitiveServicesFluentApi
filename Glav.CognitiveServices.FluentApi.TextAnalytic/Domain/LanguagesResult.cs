using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses;
using System;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain
{
    public sealed class LanguagesResult : BaseApiResponse<LanguagesResultResponseRoot>
    {
        public LanguagesResult(ICommunicationResult apiCallResult) : base(apiCallResult)
        {
            AddResultToCollection();
        }

        private void AddResultToCollection()
        {
            if (ApiCallResult == null)
            {
                ResponseData = new LanguagesResultResponseRoot { errors = new ApiErrorResponse[] { new ApiErrorResponse { id = 1, message = StandardResponseCodes.NoDataReturnedMessage } } };
                ActionSubmittedSuccessfully = false;
                return;
            }

            try
            {
                ResponseData = Newtonsoft.Json.JsonConvert.DeserializeObject<LanguagesResultResponseRoot>(ApiCallResult.Data);
                if (ResponseData == null || ResponseData.documents == null)
                {
                    var errors = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiErrorResponse>(ApiCallResult.Data);
                    if (errors != null)
                    {
                        ResponseData = new LanguagesResultResponseRoot { errors = new ApiErrorResponse[] { errors } };
                    }
                    ActionSubmittedSuccessfully = false;
                    return;
                }
                ActionSubmittedSuccessfully = true;
            } catch (Exception ex)
            {
                ResponseData = new LanguagesResultResponseRoot { errors = new ApiErrorResponse[] { new ApiErrorResponse { id = 1, message = $"Error parsing results: {ex.Message}" } } };
                ActionSubmittedSuccessfully = false;
            }
        }

    }


}

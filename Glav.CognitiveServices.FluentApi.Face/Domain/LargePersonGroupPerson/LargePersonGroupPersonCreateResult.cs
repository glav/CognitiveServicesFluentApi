using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public class LargePersonGroupPersonCreateResult : BaseResponseResult<LargePersonGroupPersonCreateResponseRoot>
    {
        public LargePersonGroupPersonCreateResult(ICommunicationResult apiCallResult) : base(apiCallResult)
        {
            ParseResponseData();
        }

        private void ParseResponseData()
        {
            if (ApiCallResult == null)
            {
                ResponseData = new LargePersonGroupPersonCreateResponseRoot
                {
                    error = new BaseApiErrorResponse { code = StandardResponseCodes.NoDataReturned, message = StandardResponseCodes.NoDataReturnedMessage }
                };
                ActionSubmittedSuccessfully = false;
                return;
            }

            try
            {
                if ((int)ApiCallResult.StatusCode >= 400)
                {
                    ResponseData = Newtonsoft.Json.JsonConvert.DeserializeObject<LargePersonGroupPersonCreateResponseRoot>(ApiCallResult.Data);
                    ActionSubmittedSuccessfully = false;
                    return;
                }

                var responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<LargePersonGroupPersonCreateResponseRoot>(ApiCallResult.Data);

                ResponseData = responseData;
                ActionSubmittedSuccessfully = true;
            }
            catch (Exception ex)
            {
                ResponseData = new LargePersonGroupPersonCreateResponseRoot
                {
                    error = new BaseApiErrorResponse { code = StandardResponseCodes.ServerError, message = $"Error parsing results: {ex.Message}" }
                };
                ActionSubmittedSuccessfully = false;
            }
        }

    }
}

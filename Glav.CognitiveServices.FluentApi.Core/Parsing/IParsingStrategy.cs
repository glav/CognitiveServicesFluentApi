using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;

namespace Glav.CognitiveServices.FluentApi.Core.Parsing
{
    public interface IParsingStrategy<TResponseRoot, TResponseItem, TError> 
        where TResponseRoot : IActionResponseWithError,  new()
        where TResponseItem : class, new()
        where TError : BaseApiErrorResponse
    {
        bool ActionSubmittedSuccessfully { get; }
        TResponseRoot ResponseRootData { get; }
        TResponseItem ResponseItemData { get; }

 
    }

    public class CallReturnsDataParsingStrategy<TResponseRoot, TResponseItem, TError> : IParsingStrategy<TResponseRoot, TResponseItem, TError> 
        where TResponseRoot : IActionResponseWithError, new()
        where TResponseItem : class, new()
        where TError : BaseApiErrorResponse

    {
        private List<BaseApiErrorResponse> _errors = new List<BaseApiErrorResponse>();

        public bool ActionSubmittedSuccessfully { get; private set; }

        public TResponseRoot ResponseRootData { get; private set; }

        public TResponseItem ResponseItemData { get; private set; }

     
        public void ParseApiCall(ICommunicationResult apiCallResult)
        {
            if (apiCallResult == null)
            {
                ResponseRootData = new TResponseRoot
                {
                    error = new BaseApiErrorResponse { code = StandardResponseCodes.NoDataReturned, message = StandardResponseCodes.NoDataReturnedMessage }
                };
                ActionSubmittedSuccessfully = false;
                return;
            }

            try
            {
                if ((int)apiCallResult.StatusCode >= 400)
                {
                    var errorResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<TError>(apiCallResult.Data);
                    ResponseRootData = new TResponseRoot { error = errorResponse };
                    ActionSubmittedSuccessfully = false;
                    return;
                }

                ResponseItemData = Newtonsoft.Json.JsonConvert.DeserializeObject<TResponseItem>(apiCallResult.Data);
                if (ResponseItemData == null)
                {
                    var apiError = Newtonsoft.Json.JsonConvert.DeserializeObject<TError>(apiCallResult.Data);
                    if (apiError != null)
                    {
                        ResponseRootData = new TResponseRoot { error = apiError };
                    }
                    ActionSubmittedSuccessfully = false;
                    return;
                }
                ActionSubmittedSuccessfully = true;
            }
            catch (Exception ex)
            {
                ResponseRootData = new TResponseRoot
                {
                    error = new BaseApiErrorResponse { code = StandardResponseCodes.ServerError, message = $"Error parsing results: {ex.Message}" }
                };
                ActionSubmittedSuccessfully = false;
            }
        }
    }

    public class CallReturnsNoDataParsingStrategy<TResponseRoot, TResponseItem, TError> : IParsingStrategy<TResponseRoot, TResponseItem, TError>
       where TResponseRoot : IActionResponseWithError, new()
       where TResponseItem : class, new()
       where TError : BaseApiErrorResponse

    {
        private List<BaseApiErrorResponse> _errors = new List<BaseApiErrorResponse>();

        public bool ActionSubmittedSuccessfully { get; private set; }

        public TResponseRoot ResponseRootData { get; private set; }

        public TResponseItem ResponseItemData { get; private set; }


        public void ParseApiCall(ICommunicationResult apiCallResult)
        {
            if (apiCallResult == null)
            {
                ResponseRootData = new TResponseRoot
                {
                    error = new BaseApiErrorResponse { code = StandardResponseCodes.NoDataReturned, message = StandardResponseCodes.NoDataReturnedMessage }
                };
                ActionSubmittedSuccessfully = false;
                return;
            }

            try
            {
                if ((int)apiCallResult.StatusCode >= 400)
                {
                    var errorResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<TError>(apiCallResult.Data);
                    ResponseRootData = new TResponseRoot { error = errorResponse };
                    ActionSubmittedSuccessfully = false;
                    return;
                }

                ActionSubmittedSuccessfully = true;
            }
            catch (Exception ex)
            {
                ResponseRootData = new TResponseRoot
                {
                    error = new BaseApiErrorResponse { code = StandardResponseCodes.ServerError, message = $"Error parsing results: {ex.Message}" }
                };
                ActionSubmittedSuccessfully = false;
            }
        }
    }
}

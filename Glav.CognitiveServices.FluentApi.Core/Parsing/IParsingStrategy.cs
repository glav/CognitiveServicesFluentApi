using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;

namespace Glav.CognitiveServices.FluentApi.Core.Parsing
{
    public interface IParsingStrategy<TResponseRoot, TResponseItem> 
        where TResponseRoot : IActionResponseRootWithError,  new()
        where TResponseItem : class
    {
        bool ActionSubmittedSuccessfully { get; }
        TResponseRoot ResponseRootData { get; }
        TResponseItem ResponseItemData { get; }
        void ParseApiCall(ICommunicationResult apiCallResult);
    }

    public class CallReturnsDataParsingStrategy<TResponseRoot, TResponseItem> : IParsingStrategy<TResponseRoot, TResponseItem> 
        where TResponseRoot : IActionResponseRootWithError, new()
        where TResponseItem : class
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
                    var errorResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseApiErrorResponse>(apiCallResult.Data);
                    ResponseRootData = new TResponseRoot { error = errorResponse };
                    ActionSubmittedSuccessfully = false;
                    return;
                }

                ResponseItemData = Newtonsoft.Json.JsonConvert.DeserializeObject<TResponseItem>(apiCallResult.Data);
                if (ResponseItemData == null)
                {
                    var apiError = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseApiErrorResponse>(apiCallResult.Data);
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

    public class CallReturnsNoDataParsingStrategy<TResponseRoot> : IParsingStrategy<TResponseRoot, TResponseRoot>
       where TResponseRoot : class,IActionResponseRootWithError, new()
      // where TResponseItem : class, new()
    {
        private List<BaseApiErrorResponse> _errors = new List<BaseApiErrorResponse>();

        public bool ActionSubmittedSuccessfully { get; private set; }

        public TResponseRoot ResponseRootData { get; private set; }

        public TResponseRoot ResponseItemData { get; private set; }


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
                    var errorResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseApiErrorResponse>(apiCallResult.Data);
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

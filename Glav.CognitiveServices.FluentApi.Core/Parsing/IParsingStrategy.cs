using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;

namespace Glav.CognitiveServices.FluentApi.Core.Parsing
{
    public interface IParsingStrategy<TResponseRoot, TResponseItem> 
        where TResponseRoot : IActionResponseRoot,  new()
        where TResponseItem : class
    {
        bool ActionSubmittedSuccessfully { get; }
        TResponseRoot ResponseRootData { get; }
        TResponseItem ResponseItemData { get; }
        void ParseApiCall(ICommunicationResult apiCallResult);
    }

    public abstract class BaseParsingStrategy<TResponseRoot, TResponseItem> : IParsingStrategy<TResponseRoot, TResponseItem>
        where TResponseRoot : IActionResponseRoot, new()
        where TResponseItem : class
    {
        public bool ActionSubmittedSuccessfully { get; protected set; }

        public TResponseRoot ResponseRootData { get; protected set; }

        public TResponseItem ResponseItemData { get; protected set; }

        public abstract void ParseApiCall(ICommunicationResult apiCallResult);
        protected void SetError(string code, string message)
        {
            ResponseRootData = new TResponseRoot();
            var errResponse = ResponseItemData as IActionResponseRootWithError;
            if (errResponse != null)
            {
                errResponse.error = new BaseApiErrorResponse { code = code, message = message };
            }
        }

        protected void SetError(BaseApiErrorResponse error)
        {
            ResponseRootData = new TResponseRoot();
            var errResponse = ResponseItemData as IActionResponseRootWithError;
            if (errResponse != null)
            {
                errResponse.error = error;
            }
        }
    }
    public class CallReturnsDataParsingStrategy<TResponseRoot, TResponseItem> : BaseParsingStrategy<TResponseRoot, TResponseItem> 
        where TResponseRoot : IActionResponseRoot, new()
        where TResponseItem : class
    {


     
        public override void ParseApiCall(ICommunicationResult apiCallResult)
        {
            if (apiCallResult == null)
            {
                SetError(StandardResponseCodes.NoDataReturned, StandardResponseCodes.NoDataReturnedMessage);
                ActionSubmittedSuccessfully = false;
                return;
            }

            try
            {
                ActionSubmittedSuccessfully = false;

                if ((int)apiCallResult.StatusCode >= 400)
                {
                    var errorResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseApiErrorResponse>(apiCallResult.Data);
                    SetError(errorResponse);
                    return;
                }

                if (apiCallResult.StatusCode == System.Net.HttpStatusCode.Accepted && apiCallResult.OperationLocationUri != null)
                {
                    ActionSubmittedSuccessfully = true;
                    return;
                }

                if (apiCallResult.StatusCode == System.Net.HttpStatusCode.Accepted && apiCallResult.OperationLocationUri == null)
                {
                    SetError(StandardResponseCodes.OperationAcceptedButNoOperationLocationUri, StandardResponseCodes.OperationAcceptedButNoOperationLocationUriMessage);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(apiCallResult.Data))
                {
                    ResponseItemData = Newtonsoft.Json.JsonConvert.DeserializeObject<TResponseItem>(apiCallResult.Data);
                    if (ResponseItemData == null)
                    {
                        var apiError = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseApiErrorResponse>(apiCallResult.Data);
                        SetError(apiError);
                        return;
                    }
                }
                ActionSubmittedSuccessfully = true;
            }
            catch (Exception ex)
            {
                SetError(StandardResponseCodes.ServerError, $"Error parsing results: {ex.Message}");
                ActionSubmittedSuccessfully = false;
            }
        }
    }
}

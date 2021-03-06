﻿using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System.Collections.Generic;
using Glav.CognitiveServices.FluentApi.Core.Communication;

namespace Glav.CognitiveServices.FluentApi.Core.Parsing
{
    public abstract class BaseApiResponse<TResponseData> 
        : IApiRequestResult<TResponseData> where TResponseData : IActionResponseRoot
    {
        protected BaseApiResponse(ICommunicationResult apiCallResult)
        {
            ApiCallResult = apiCallResult;
        }
        public TResponseData ResponseData { get; protected set; }

        public ICommunicationResult ApiCallResult { get; protected set; }
        public bool ActionSubmittedSuccessfully { get; protected set; }
    }
}

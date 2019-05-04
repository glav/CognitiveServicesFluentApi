using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core
{
    public static class StandardResponseCodes
    {
        public const string NoDataReturned = "NoData";
        public const string NoDataReturnedMessage = "No data returned.";
        public const string ServerError = "ServerError";
        public const string OperationAcceptedButNoOperationLocationUri = "AcceptedNoLocationUriReturned";
        public const string OperationAcceptedButNoOperationLocationUriMessage = "The operation was accepted but did not return an operation Uri";
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic.Responses
{
    internal static class OperationStatusResponseMessages
    {
        public const string StatusBadRequest = "BadRequest";
        public const string StatusFailed = "Failed";
        public const string StatusFinished = "Finished";
        public const string StatusSubmitted = "Submitted";
    }

    internal static class OperationStatusMessagesExtensions
    {
        private static Dictionary<string, OperationStateType> _mappedStateTypes = new Dictionary<string, OperationStateType>();

        static OperationStatusMessagesExtensions()
        {
            _mappedStateTypes.Add(OperationStatusResponseMessages.StatusBadRequest, OperationStateType.BadRequest);
            _mappedStateTypes.Add(OperationStatusResponseMessages.StatusFailed, OperationStateType.NotStarted);
            _mappedStateTypes.Add(OperationStatusResponseMessages.StatusFinished, OperationStateType.CompletedSuccessfully);
            _mappedStateTypes.Add(OperationStatusResponseMessages.StatusSubmitted, OperationStateType.Submitted);
        }
        public static OperationStateType ToOperationStatus(this string statusMessage)
        {
            if (string.IsNullOrWhiteSpace(statusMessage))
            {
                return OperationStateType.BadRequest;
            }

            var normaliedMsg = statusMessage.ToLowerInvariant();
            if (_mappedStateTypes.ContainsKey(normaliedMsg))
            {
                return _mappedStateTypes[normaliedMsg];
            }

            throw new ArgumentException($"status of [{statusMessage}] not supported.");
        }
    }
}

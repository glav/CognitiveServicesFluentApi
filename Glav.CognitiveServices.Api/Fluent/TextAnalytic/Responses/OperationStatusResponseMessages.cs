using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic.Responses
{
    internal static class OperationStatusResponseMessages
    {
        public const string StatusBadRequest = "badrequest";
        public const string StatusFailed = "failed";
        public const string StatusFinished = "finished";
        public const string StatusSubmitted = "submitted";
        public const string StatusNotStarted = "notstarted";
        public const string StatusRunning = "running";
    }

    internal static class OperationStatusMessagesExtensions
    {
        private static Dictionary<string, OperationStateType> _mappedStateTypes = new Dictionary<string, OperationStateType>();

        static OperationStatusMessagesExtensions()
        {
            _mappedStateTypes.Add(OperationStatusResponseMessages.StatusBadRequest, OperationStateType.BadRequest);
            _mappedStateTypes.Add(OperationStatusResponseMessages.StatusFailed, OperationStateType.Failed);
            _mappedStateTypes.Add(OperationStatusResponseMessages.StatusFinished, OperationStateType.CompletedSuccessfully);
            _mappedStateTypes.Add(OperationStatusResponseMessages.StatusSubmitted, OperationStateType.Submitted);
            _mappedStateTypes.Add(OperationStatusResponseMessages.StatusNotStarted, OperationStateType.NotStarted);
            _mappedStateTypes.Add(OperationStatusResponseMessages.StatusRunning, OperationStateType.Running);
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

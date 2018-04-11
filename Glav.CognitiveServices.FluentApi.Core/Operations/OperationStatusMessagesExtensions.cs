using System.Collections.Generic;

namespace Glav.CognitiveServices.FluentApi.Core.Operations
{
    internal static class OperationStatusMessagesExtensions
    {
        private static Dictionary<string, OperationStateType> _mappedStateTypes = new Dictionary<string, OperationStateType>();

        static OperationStatusMessagesExtensions()
        {
            _mappedStateTypes.Add(OperationStatusResponseMessages.StatusBadRequest, OperationStateType.BadRequest);
            _mappedStateTypes.Add(OperationStatusResponseMessages.StatusFailed, OperationStateType.Failed);
            _mappedStateTypes.Add(OperationStatusResponseMessages.StatusSucceeded, OperationStateType.CompletedSuccessfully);
            _mappedStateTypes.Add(OperationStatusResponseMessages.StatusSubmitted, OperationStateType.Submitted);
            _mappedStateTypes.Add(OperationStatusResponseMessages.StatusNotStarted, OperationStateType.NotStarted);
            _mappedStateTypes.Add(OperationStatusResponseMessages.StatusRunning, OperationStateType.Running);
            _mappedStateTypes.Add(OperationStatusResponseMessages.StatusUploading, OperationStateType.Uploaded);
        }
        public static OperationStateType ToOperationStatus(this string statusMessage)
        {
            if (string.IsNullOrWhiteSpace(statusMessage))
            {
                return OperationStateType.BadRequest;
            }

            var normalisedMsg = statusMessage.ToLowerInvariant();
            if (_mappedStateTypes.ContainsKey(normalisedMsg))
            {
                return _mappedStateTypes[normalisedMsg];
            }

            throw new CognitiveServicesArgumentException($"status of [{statusMessage}] not supported.");
        }
    }
}

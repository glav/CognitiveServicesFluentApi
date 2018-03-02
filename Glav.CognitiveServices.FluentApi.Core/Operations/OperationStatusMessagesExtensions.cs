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

            throw new CognitiveServicesArgumentException($"status of [{statusMessage}] not supported.");
        }
    }
}

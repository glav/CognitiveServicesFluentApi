using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.Core.Communication
{
    public interface ICommunicationEngine
    {
        Task<ICommunicationResult> CallServiceAsync(ApiActionType apiActionType, string payload, string urlQueryParameters = null, bool isBinaryPayload = false);
        Task<ICommunicationResult> CallServiceAsync(string uri, ApiActionCategory apiCategory, bool isBinaryPayload);
    }
}
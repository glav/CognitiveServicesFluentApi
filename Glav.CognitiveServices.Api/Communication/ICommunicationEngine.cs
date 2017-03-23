using System.Threading.Tasks;
using Glav.CognitiveServices.Api.Configuration;

namespace Glav.CognitiveServices.Api.Communication
{
    public interface ICommunicationEngine
    {
        Task<CommunicationResult> CallServiceAsync(ApiActionType apiActionType, string payload);
        Task<CommunicationResult> CallServiceAsync(string uri);
    }
}
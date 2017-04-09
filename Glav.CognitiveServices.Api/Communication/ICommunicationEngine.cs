using System.Threading.Tasks;
using Glav.CognitiveServices.Api.Configuration;

namespace Glav.CognitiveServices.Api.Communication
{
    public interface ICommunicationEngine
    {
        Task<ICommunicationResult> CallServiceAsync(ApiActionType apiActionType, string payload);
        Task<ICommunicationResult> CallServiceAsync(string uri);
    }
}
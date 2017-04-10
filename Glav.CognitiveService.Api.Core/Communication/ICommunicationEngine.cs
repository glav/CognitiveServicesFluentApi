using System.Threading.Tasks;
using Glav.CognitiveServices.Api.Core.Configuration;

namespace Glav.CognitiveServices.Api.Core.Communication
{
    public interface ICommunicationEngine
    {
        Task<ICommunicationResult> CallServiceAsync(ApiActionType apiActionType, string payload);
        Task<ICommunicationResult> CallServiceAsync(string uri);
    }
}
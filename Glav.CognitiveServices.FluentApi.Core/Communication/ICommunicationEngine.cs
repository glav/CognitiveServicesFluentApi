using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.Core.Communication
{
    public interface ICommunicationEngine
    {
        Task<ICommunicationResult> CallServiceAsync(ApiActionDefinition apiActionType, string payload, string urlQueryParameters = null);
        Task<ICommunicationResult> CallServiceAsync(ApiActionDefinition apiActionType, byte[] payload, string urlQueryParameters = null);
        Task<ICommunicationResult> ServiceGetAsync(string uri, string category);
    }
}
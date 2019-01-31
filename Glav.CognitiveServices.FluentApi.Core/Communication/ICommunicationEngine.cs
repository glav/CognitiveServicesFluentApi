using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.Core.Communication
{
    public interface ICommunicationEngine
    {
        Task<ICommunicationResult> CallServiceAsync(ApiActionDefinition apiActionType, string payload, string urlQueryParameters = null);
        Task<ICommunicationResult> CallServiceAsync(ApiActionDefinition apiActionType, byte[] payload, string urlQueryParameters = null);
        //Task<ICommunicationResult> ServicePostAsync(ApiActionType apiActionType, string payload, string urlQueryParameters = null);
        //Task<ICommunicationResult> ServicePostAsync(ApiActionType apiActionType, byte[] payload, string urlQueryParameters = null);
        //Task<ICommunicationResult> ServicePutAsync(ApiActionType apiActionType, string payload, string urlQueryParameters = null);
        //Task<ICommunicationResult> ServicePutAsync(ApiActionType apiActionType, byte[] payload, string urlQueryParameters = null);
        //Task<ICommunicationResult> ServiceGetAsync(string uri, ApiActionCategory apiCategory);
        Task<ICommunicationResult> ServiceGetAsync(string uri, string category);
    }
}
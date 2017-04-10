using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.Core.Communication
{
    public interface ICommunicationEngine
    {
        Task<ICommunicationResult> CallServiceAsync(ApiActionType apiActionType, string payload);
        Task<ICommunicationResult> CallServiceAsync(string uri);
    }
}
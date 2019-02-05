using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.Core.Communication
{
    public interface ICommunicationEngine
    {
        Task<ICommunicationResult> CallServiceAsync(IActionDataItem actionItem);
        Task<ICommunicationResult> CallBatchServiceAsync(ApiActionDataCollection actionItemCollection);
        Task<ICommunicationResult> ServiceGetAsync(string uri, string category);
    }
}
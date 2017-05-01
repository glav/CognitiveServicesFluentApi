using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core;

namespace Glav.CognitiveServices.FluentApi.Core.Contracts
{
    public interface IAnalysisEngine<T> where T : IAnalysisResults
    {
        AnalysisSettings AnalysisSettings { get; }

        Task<T> AnalyseAllAsync();
    }
}
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain
{
    public class LanguageAnalysisContext : IApiAnalysisContext<TextAnalyticActionData, LanguagesResult>
    {
        public LanguageAnalysisContext(TextAnalyticActionData actionData, LanguagesResult analysisResult)
        {
            AnalysisInput = actionData;
            AnalysisResult = analysisResult;
        }
        public ApiActionType AnalysisType { get { return ApiActionType.TextAnalyticsLanguages; } }

        public TextAnalyticActionData AnalysisInput { get; private set; }

        public LanguagesResult AnalysisResult { get; private set; }
}
}

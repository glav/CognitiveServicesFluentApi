using Glav.CognitiveServices.FluentApi.TextAnalytic.Fluent.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Fluent.TextAnalytic
{
    public class TopicAnalysisContext : IApiAnalysisContext<TextAnalyticTopicActionData, TopicResult>
    {
        public TopicAnalysisContext(TextAnalyticTopicActionData actionData, TopicResult analysisResult)
        {
            AnalysisInput = actionData;
            AnalysisResult = analysisResult;
        }
        public ApiActionType AnalysisType { get { return ApiActionType.TextAnalyticsTopics; } }

        public TextAnalyticTopicActionData AnalysisInput { get; private set; }

        public TopicResult AnalysisResult { get; private set; }
}
}

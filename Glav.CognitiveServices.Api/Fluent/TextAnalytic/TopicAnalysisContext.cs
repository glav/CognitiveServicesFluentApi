using Glav.CognitiveServices.Api.Fluent.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.Api.Configuration;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic
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

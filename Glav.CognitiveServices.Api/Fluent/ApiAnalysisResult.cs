using Glav.CognitiveServices.Api.Fluent.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent
{
    public class ApiAnalysisResult : IAPIAnalysisResult
    {
        private readonly IApiAnalysisResultData _actionResult;

        public ApiAnalysisResult(long id, IApiAction actionPerformed, IApiAnalysisResultData actionResult)
        {
            Id = id;
            ActionPerformed = ActionPerformed;
            _actionResult = actionResult;
        }
        public long Id { get; private set; }
        public IApiAction ActionPerformed { get; private set; }

        public T ActionResult<T>() where T : class, IApiAnalysisResultData
        {
            return _actionResult as T;
        }
    }
}

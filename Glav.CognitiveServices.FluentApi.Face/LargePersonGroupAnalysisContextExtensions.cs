using Glav.CognitiveServices.FluentApi.Face.Domain;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Face
{
    public static class LargePersonGroupAnalysisContextExtensions
    {
        public static LargePersonGroupGetResponseItem GetResult(this LargePersonGroupGetAnalysisContext context)
        {
            return context.AnalysisResult.ResponseData?.LargePersonGroup;
        }

        public static IEnumerable<LargePersonGroupGetResponseItem> GetResults(this LargePersonGroupListAnalysisContext context)
        {
            return context.AnalysisResult.ResponseData?.LargePersonGroups?.AsEnumerable();
        }

    }
}

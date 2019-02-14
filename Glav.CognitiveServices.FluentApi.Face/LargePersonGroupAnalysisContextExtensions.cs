using Glav.CognitiveServices.FluentApi.Face.Domain;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup;
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
            return context.AnalysisResults.SelectMany(r => r.ResponseData?.LargePersonGroups)?.AsEnumerable();
        }

        public static bool IsSuccessfull(this LargePersonGroupCreateAnalysisContext context)
        {
            return context.AnalysisResults.Any(r => !r.ActionSubmittedSuccessfully || !r.ApiCallResult.Successfull);
        }
        public static bool IsSuccessfull(this LargePersonGroupDeleteAnalysisContext context)
        {
            return context.AnalysisResults.All(r => r.ActionSubmittedSuccessfully && r.ApiCallResult.Successfull);
        }

    }
}

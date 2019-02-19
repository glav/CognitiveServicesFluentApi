using Glav.CognitiveServices.FluentApi.Face.Domain;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup;
using Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Face
{
    public static class LargePersonGroupPersonAnalysisContextExtensions
    {
        public static LargePersonGroupPersonGetResponseItem GetResult(this LargePersonGroupPersonGetAnalysisContext context)
        {
            return context.AnalysisResult.ResponseData?.LargePersonGroupPerson;
        }

        public static IEnumerable<LargePersonGroupPersonGetResponseItem> GetResults(this LargePersonGroupPersonListAnalysisContext context)
        {
            return context.AnalysisResults.SelectMany(r => r.ResponseData?.LargePersonGroupPersons)?.AsEnumerable();
        }

        public static bool IsSuccessfull(this LargePersonGroupPersonCreateAnalysisContext context)
        {
            return context.AnalysisResults.All(r => r.ActionSubmittedSuccessfully && r.ApiCallResult.Successfull);
        }
        public static bool IsSuccessfull(this LargePersonGroupPersonDeleteAnalysisContext context)
        {
            return context.AnalysisResults.All(r => r.ActionSubmittedSuccessfully && r.ApiCallResult.Successfull);
        }

    }
}

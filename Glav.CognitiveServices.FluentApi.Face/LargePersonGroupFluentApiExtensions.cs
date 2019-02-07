using System.Threading.Tasks;
using System;
using Glav.CognitiveServices.FluentApi.Face.Configuration;
using System.IO;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.Face
{
    public static class LargePersonGroupFluentApiExtensions
    {
        public static FaceAnalysisSettings CreateLargePersonGroup(this FaceAnalysisSettings apiAnalysis, string groupId, string name, string userData = null)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<LargePersonGroupActionData>(FaceApiOperations.LargePersonGroupCreate);
            actionData.AddPersonGroupCreate(groupId, name, userData);
            return apiAnalysis;
        }

        public static FaceAnalysisSettings GetLargePersonGroup(this FaceAnalysisSettings apiAnalysis, string groupId)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<LargePersonGroupActionData>(FaceApiOperations.LargePersonGroupGet);
            actionData.AddPersonGroupGet(groupId);
            return apiAnalysis;
        }
    }
}

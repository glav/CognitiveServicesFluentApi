using Glav.CognitiveServices.FluentApi.Face.Configuration;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup;
using Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson;

namespace Glav.CognitiveServices.FluentApi.Face
{
    public static class LargePersonGroupPersonFluentApiExtensions
    {
        public static FaceAnalysisSettings CreateLargePersonGroupPerson(this FaceAnalysisSettings apiAnalysis, string groupId, string name, string userData = null)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<LargePersonGroupPersonActionData>(FaceApiOperations.LargePersonGroupPersonCreate);
            actionData.AddPersonGroupPersonCreate(groupId, name, userData);
            return apiAnalysis;
        }

        public static FaceAnalysisSettings GetLargePersonGroupPerson(this FaceAnalysisSettings apiAnalysis, string groupId, string personId)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<LargePersonGroupPersonActionData>(FaceApiOperations.LargePersonGroupPersonGet);
            actionData.AddPersonGroupPersonGet(groupId, personId);
            return apiAnalysis;
        }

        public static FaceAnalysisSettings ListLargePersonGroupPersons(this FaceAnalysisSettings apiAnalysis, string groupId, string start = null, int top=1000)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<LargePersonGroupPersonActionData>(FaceApiOperations.LargePersonGroupPersonList);
            actionData.AddPersonGroupPersonList(groupId,start,top);
            return apiAnalysis;
        }
        public static FaceAnalysisSettings DeleteLargePersonGroupPerson(this FaceAnalysisSettings apiAnalysis, string groupId)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<LargePersonGroupPersonActionData>(FaceApiOperations.LargePersonGroupPersonDelete);
            actionData.AddPersonGroupPersonDelete(groupId);
            return apiAnalysis;
        }
    }
}

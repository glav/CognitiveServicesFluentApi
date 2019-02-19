using Glav.CognitiveServices.FluentApi.Face.Configuration;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup;

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

        public static FaceAnalysisSettings ListLargePersonGroups(this FaceAnalysisSettings apiAnalysis, string start = null, int top=1000)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<LargePersonGroupActionData>(FaceApiOperations.LargePersonGroupList);
            actionData.AddPersonGroupList(start,top);
            return apiAnalysis;
        }
        public static FaceAnalysisSettings DeleteLargePersonGroup(this FaceAnalysisSettings apiAnalysis, string groupId)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<LargePersonGroupActionData>(FaceApiOperations.LargePersonGroupDelete);
            actionData.AddPersonGroupDelete(groupId);
            return apiAnalysis;
        }
    }
}

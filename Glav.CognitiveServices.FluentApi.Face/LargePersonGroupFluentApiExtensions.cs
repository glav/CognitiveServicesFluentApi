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
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<LargePersonGroupActionData>(ApiActionType.FaceLargePersonGroups);
            actionData.Add(groupId, name, userData);
            return apiAnalysis;
        }
    }
}

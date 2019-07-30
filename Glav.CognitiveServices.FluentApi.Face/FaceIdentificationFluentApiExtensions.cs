using System.Threading.Tasks;
using System;
using Glav.CognitiveServices.FluentApi.Face.Configuration;
using System.IO;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.Face
{
    public static class FaceIdentificationFluentApiExtensions
    {
        public static FaceAnalysisSettings IdentifyFaces(this FaceAnalysisSettings apiAnalysis, string personGroupId,string[] faceIds)
        {
            var action = apiAnalysis.GetOrCreateActionDataInstance<FaceIdentificationActionData>(FaceApiOperations.FaceIdentification);
            action.Add(personGroupId, faceIds);
            return apiAnalysis;
        }
        public static FaceAnalysisSettings IdentifyFaces(this FaceAnalysisSettings apiAnalysis, string personGroupId, string[] faceIds, float confidenceThreshold,int maxNumOfCandidatesReturned = 10 )
        {
            var action = apiAnalysis.GetOrCreateActionDataInstance<FaceIdentificationActionData>(FaceApiOperations.FaceIdentification);
            action.Add(personGroupId, faceIds,maxNumOfCandidatesReturned, confidenceThreshold);
            return apiAnalysis;
        }

        public static FaceAnalysisSettings IdentifyFace(this FaceAnalysisSettings apiAnalysis, string personGroupId, string faceId)
        {
            return IdentifyFaces(apiAnalysis, personGroupId, new string[] { faceId });
        }
    }
}

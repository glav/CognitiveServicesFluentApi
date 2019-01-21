using Glav.CognitiveServices.FluentApi.Face.Domain;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Face
{
    public static class FaceDetectionAnalysisContextExtensions
    {
        public static FaceDetectResponseItem GetResult(this FaceDetectionAnalysisContext context, string faceId)
        {
            return context.AnalysisResult.ResponseData.detectedFaces.FirstOrDefault(a => a.faceId == faceId);
        }

        public static IEnumerable<FaceDetectResponseItem> GetResults(this FaceDetectionAnalysisContext context)
        {
            return context.AnalysisResult.ResponseData.detectedFaces.AsEnumerable();
        }

        public static bool IsGender(this FaceDetectResponseItem responseItem, GenderType gender)
        {
            return responseItem.faceAttributes?.gender.ToGenderType() == gender;
        }
    }
}

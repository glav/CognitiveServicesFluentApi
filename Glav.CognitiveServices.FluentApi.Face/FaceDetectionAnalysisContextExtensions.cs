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

        public static bool IsGlassesType(this FaceDetectResponseItem responseItem, GlassesType glasses)
        {
            return responseItem.faceAttributes?.glasses.ToGlassesType() == glasses;
        }

        public static bool HasEyeMakeup(this FaceDetectResponseItem responseItem)
        {
            return responseItem.faceAttributes != null && responseItem.faceAttributes.makeup.eyeMakeup;
        }

        public static bool HasLipMakeup(this FaceDetectResponseItem responseItem)
        {
            return responseItem.faceAttributes != null && responseItem.faceAttributes.makeup.lipMakeup;
        }

        public static bool IsNoiseLevel(this FaceDetectResponseItem responseItem, NoiseLevel level)
        {
            return responseItem.faceAttributes.noise?.noiseLevel.ToNoiseLevel() == level;
        }
        public static bool IsExposureLevel(this FaceDetectResponseItem responseItem, ExposureLevel level)
        {
            return responseItem.faceAttributes.exposure?.exposureLevel.ToExposureLevel() == level;
        }
        public static bool IsBlurLevel(this FaceDetectResponseItem responseItem, BlurLevel level)
        {
            return responseItem.faceAttributes.blur?.blurLevel.ToBlurLevel() == level;
        }
    }
}

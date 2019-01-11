using System.Threading.Tasks;
using System;
using Glav.CognitiveServices.FluentApi.Face.Configuration;
using System.IO;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.Face
{
    public static class FaceDetectionFluentApiExtensions
    {
        public static async Task<FaceAnalysisResults> AnalyseAllAsync(this FaceAnalysisSettings apiAnalysisSettings)
        {
            var engine = new FaceAnalysisEngine(apiAnalysisSettings);
            return await engine.AnalyseAllAsync().ConfigureAwait(continueOnCapturedContext: false);
        }

        public static FaceAnalysisSettings AddUrlForFaceDetection(this FaceAnalysisSettings apiAnalysis, string url, FaceDetectionAttributes returnedAttributes,
                bool? returnFaceLandmarks = null,
                bool? returnFaceId = null)
        {
            return apiAnalysis.AddUriForFaceDetection(new Uri(url),returnedAttributes,returnFaceLandmarks,returnFaceId);
        }
        public static FaceAnalysisSettings AddUriForFaceDetection(this FaceAnalysisSettings apiAnalysis, Uri uri, FaceDetectionAttributes returnedAttributes,
                bool? returnFaceLandmarks = null,
                bool? returnFaceId = null)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<FaceDetectionActionData>(ApiActionType.FaceDetection);
            actionData.Add(uri, returnedAttributes, returnFaceLandmarks, returnFaceId);
            return apiAnalysis;
        }

        public static FaceAnalysisSettings AddFileForFaceDetection(this FaceAnalysisSettings apiAnalysis, byte[] imageData, FaceDetectionAttributes returnedAttributes,
                bool? returnFaceLandmarks = null,
                bool? returnFaceId = null)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<FaceDetectionActionData>(ApiActionType.FaceDetection);
            actionData.Add(imageData, returnedAttributes, returnFaceLandmarks, returnFaceId);
            return apiAnalysis;
        }
        public static FaceAnalysisSettings AddFileForFaceDetection(this FaceAnalysisSettings apiAnalysis, string filename, FaceDetectionAttributes returnedAttributes,
                bool? returnFaceLandmarks = null,
                bool? returnFaceId = null)
        {
            var bytes = File.ReadAllBytes(filename);
            return AddFileForFaceDetection(apiAnalysis, bytes, returnedAttributes, returnFaceLandmarks, returnFaceId);
        }

    }
}

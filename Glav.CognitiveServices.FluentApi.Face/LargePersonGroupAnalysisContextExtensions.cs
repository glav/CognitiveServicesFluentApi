using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Face.Configuration;
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
            return context.AnalysisResults.All(r => r.ActionSubmittedSuccessfully && r.ApiCallResult.Successfull);
        }
        public static bool IsSuccessfull(this LargePersonGroupDeleteAnalysisContext context)
        {
            return context.AnalysisResults.All(r => r.ActionSubmittedSuccessfully && r.ApiCallResult.Successfull);
        }

        public static LargePersonGroupTrainStatusResponseItem GetTrainingStatus(this LargePersonGroupTrainStatusAnalysisContext context)
        {
            return context?.AnalysisResult?.ResponseData?.TrainingStatus;
        }

        public static LargePersonGroupTrainStatusResponseItem GetTrainingStatus(this FaceAnalysisResults context)
        {
            return context?.LargePersonGroupTrainStatusAnalysis?.AnalysisResult?.ResponseData?.TrainingStatus;
        }

        public static bool IsTrainingComplete(this LargePersonGroupTrainStatusResponseItem apiResponse)
        {
            if (apiResponse == null)
            {
                throw new CognitiveServicesException("Training status is NULL");
            }
            return apiResponse.status == ApiConstants.LargePersonGroupTrainStatusSucceeded
               || apiResponse.status == ApiConstants.LargePersonGroupTrainStatusFailed;

        }
        public static bool IsTrainingSuccessful(this LargePersonGroupTrainStatusResponseItem apiResponse)
        {
            if (apiResponse == null)
            {
                throw new CognitiveServicesException("Training status is NULL");
            }
            return apiResponse.status == ApiConstants.LargePersonGroupTrainStatusSucceeded;
        }

        public static bool IsTrainingComplete(this FaceAnalysisResults context)
        {
            var trainStatus = context.GetTrainingStatus();
            return trainStatus.IsTrainingComplete();
        }

        public static bool IsTrainingSuccessful(this FaceAnalysisResults context)
        {
            var status = context.GetTrainingStatus();
            return status.IsTrainingComplete() && status.IsTrainingSuccessful();
        }


    }
}

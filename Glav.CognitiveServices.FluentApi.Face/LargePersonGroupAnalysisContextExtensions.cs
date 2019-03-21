using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Operations;
using Glav.CognitiveServices.FluentApi.Face.Configuration;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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


        public static async Task WaitForTrainingToCompleteAsync(this FaceAnalysisResults results, CancellationToken cancelToken,
                int timeoutInMilliseconds = OperationStatusQueryEngine.DefaultOperationStateQueryTimeoutInMilliseconds,
            int queryDelayInMilliseconds = OperationStatusQueryEngine.DefaultOperationStateQueryDelayInMilliseconds)
        {
            if (results.IsTrainingComplete())
            {
                return;
            }
            var logger = results.AnalysisSettings.ConfigurationSettings.DiagnosticLogger;
            const string logTopic = "FaceTraining";
            logger.LogInfo("Waiting for training to complete...", logTopic);

            var actionCollection = results.AnalysisSettings.ActionsToPerform.First(a => a.Key == FaceApiOperations.LargePersonGroupTrainStart.Name).Value;
            var groupIds = actionCollection
                    .GetAllItems()
                    .Cast<LargePersonGroupTrainStatusActionDataItem>()
                    .Select(s => s.GroupId)
                    .ToList();

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {
                while (true)
                {
                    if (cancelToken.IsCancellationRequested)
                    {
                        logger.LogWarning("Querying face training status was cancelled", logTopic);
                        return;
                    }

                    var settings = results.AnalysisSettings.WithFaceAnalysisActions();
                    groupIds.ForEach(grpId =>
                    {
                        settings.CheckTrainingStatusLargePersonGroup(grpId);
                    });
                    var checkResult = await settings.AnalyseAllAsync();
                    var isComplete = checkResult.LargePersonGroupTrainStatusAnalysis.
                        AnalysisResults.All(r => r.ResponseData.TrainingStatus.IsTrainingComplete());
                    if (isComplete)
                    {
                        logger.LogInfo($"Querying for face training status completed in {stopWatch.ElapsedMilliseconds} milliseconds.", logTopic);
                        return;
                    }

                    await System.Threading.Tasks.Task.Delay(queryDelayInMilliseconds);

                    if (stopWatch.ElapsedMilliseconds > timeoutInMilliseconds)
                    {
                        logger.LogWarning($"Querying for face training status timed out." +
                            $" Operation took {stopWatch.ElapsedMilliseconds} which was greater than threshold {timeoutInMilliseconds} milliseconds.", logTopic);

                        return;
                    }
                }
            }
            finally
            {
                stopWatch.Stop();
            }
        }


    }
}

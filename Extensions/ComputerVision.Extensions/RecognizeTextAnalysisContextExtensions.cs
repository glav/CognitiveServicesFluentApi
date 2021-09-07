using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public static class ReadImageAnalysisContextExtensions
    {
        public static string GetInitialErrorMessage(this ReadImageAnalysisContext context)
        {
            var message = context.AnalysisResult.ResponseData.error != null ?
                context.AnalysisResult.ResponseData.error.message :
                context.AnalysisResult.ApiCallResult.Data;
            return message;

        }

    }
}

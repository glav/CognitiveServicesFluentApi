using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses
{
    public class LargePersonGroupCreateResponseRoot : IActionResponseRootWithError
    {
        public BaseApiErrorResponse error { get; set; }
    }

    public class LargePersonGroupTrainStartResponseRoot : IActionResponseRoot
    {
        public BaseApiErrorResponse error { get; set; }
    }

    
    public class LargePersonGroupTrainStatusResponseRoot : IActionResponseRoot
    {
        public BaseApiErrorResponse error { get; set; }
        public LargePersonGroupTrainStatusResponseItem TrainingStatus {get;set;}
    }


    public class LargePersonGroupDeleteResponseRoot : IActionResponseRootWithError
    {
        public BaseApiErrorResponse error { get; set; }
    }

    public class LargePersonGroupGetResponseRoot : LargePersonGroupCreateResponseRoot
    {
        public LargePersonGroupGetResponseItem LargePersonGroup { get; set; }
    }

    public class LargePersonGroupListResponseRoot : LargePersonGroupCreateResponseRoot
    {
        public LargePersonGroupGetResponseItem[] LargePersonGroups { get; set; }
    }

    public class LargePersonGroupGetResponseItem
    {
        public string name { get; set; }
        public string userData { get; set; }
        public string largePersonGroupId { get; set; }
    }

    public class LargePersonGroupTrainStatusResponseItem
    {
        public string status { get; set; }
        public string createdDateTime { get; set; }
        public string lastActionDateTime { get; set; }
        public string lastSuccessfulTrainingDateTime { get; set; }
        public string message { get; set; }
    }

}

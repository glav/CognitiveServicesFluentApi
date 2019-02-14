using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses
{
    public class LargePersonGroupCreateResponseRoot : IActionResponseRoot
    {
        public ApiErrorResponse error { get; set; }
    }

    public class LargePersonGroupDeleteResponseRoot : IActionResponseRoot
    {
        public ApiErrorResponse error { get; set; }
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

}

using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses
{
    public class LargePersonGroupPersonCreateResponseRoot : IActionResponseRootWithError
    {
        public string personId { get; set; }
        public BaseApiErrorResponse error { get; set; }
    }

    public class LargePersonGroupPersonDeleteResponseRoot : IActionResponseRootWithError
    {
        public BaseApiErrorResponse error { get; set; }
    }

    public class LargePersonGroupPersonGetResponseRoot : IActionResponseRootWithError
    {
        public LargePersonGroupPersonGetResponseItem LargePersonGroupPerson { get; set; }
        public BaseApiErrorResponse error { get; set; }
    }

    public class LargePersonGroupPersonListResponseRoot : IActionResponseRootWithError
    {
        public LargePersonGroupPersonGetResponseItem[] LargePersonGroupPersons { get; set; }
        public BaseApiErrorResponse error { get; set; }
    }

    public class LargePersonGroupPersonGetResponseItem
    {
        public string personId { get; set; }
        public string name { get; set; }
        public string userData { get; set; }
        public string[] persistedFaceIds { get; set; }
    }

}

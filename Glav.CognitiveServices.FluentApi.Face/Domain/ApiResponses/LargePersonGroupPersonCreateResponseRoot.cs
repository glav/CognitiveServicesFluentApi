using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses
{
    public class LargePersonGroupPersonCreateResponseRoot : IActionResponseRoot
    {
        public string personId { get; set; }
        public BaseApiErrorResponse error { get; set; }
    }

    public class LargePersonGroupPersonDeleteResponseRoot : IActionResponseRoot
    {
        public BaseApiErrorResponse error { get; set; }
    }

    public class LargePersonGroupPersonGetResponseRoot : IActionResponseRoot
    {
        public LargePersonGroupPersonGetResponseItem LargePersonGroupPerson { get; set; }
        public BaseApiErrorResponse error { get; set; }
    }

    public class LargePersonGroupPersonListResponseRoot : IActionResponseRoot
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

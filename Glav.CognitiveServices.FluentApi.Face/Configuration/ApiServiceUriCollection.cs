using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Face.Domain;

namespace Glav.CognitiveServices.FluentApi.Face.Configuration
{
    public class ApiServiceUriCollection : ApiServiceUriCollectionBase
    {
        public ApiServiceUriCollection()
        {
            Services.Add(FaceApiOperations.FaceDetection.Name, new FaceDetectionServiceConfig());
            Services.Add(FaceApiOperations.LargePersonGroupCreate.Name, new LargePersonGroupServiceConfig());
            Services.Add(FaceApiOperations.LargePersonGroupGet.Name, new LargePersonGroupServiceConfig());
        }
    }
}

using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Face.Domain;

namespace Glav.CognitiveServices.FluentApi.Face.Configuration
{
    public class ApiServiceUriCollection : ApiServiceUriCollectionBase
    {
        public ApiServiceUriCollection(string apiVersionIdentifier)
        {
            Services.Add(FaceApiOperations.FaceDetection.Name, new FaceDetectionServiceConfig(apiVersionIdentifier));
            Services.Add(FaceApiOperations.FaceIdentification.Name, new FaceIdentificationServiceConfig(apiVersionIdentifier));
            Services.Add(FaceApiOperations.LargePersonGroupCreate.Name, new LargePersonGroupCreateServiceConfig(apiVersionIdentifier));
            Services.Add(FaceApiOperations.LargePersonGroupGet.Name, new LargePersonGroupGetServiceConfig(apiVersionIdentifier));
            Services.Add(FaceApiOperations.LargePersonGroupList.Name, new LargePersonGroupListServiceConfig(apiVersionIdentifier));
            Services.Add(FaceApiOperations.LargePersonGroupDelete.Name, new LargePersonGroupDeleteServiceConfig(apiVersionIdentifier));
            Services.Add(FaceApiOperations.LargePersonGroupPersonCreate.Name, new LargePersonGroupPersonCreateServiceConfig(apiVersionIdentifier));
            Services.Add(FaceApiOperations.LargePersonGroupPersonGet.Name, new LargePersonGroupPersonGetServiceConfig(apiVersionIdentifier));
            Services.Add(FaceApiOperations.LargePersonGroupPersonList.Name, new LargePersonGroupPersonListServiceConfig(apiVersionIdentifier));
            Services.Add(FaceApiOperations.LargePersonGroupPersonDelete.Name, new LargePersonGroupPersonDeleteServiceConfig(apiVersionIdentifier));
            Services.Add(FaceApiOperations.LargePersonGroupPersonFaceAdd.Name, new LargePersonGroupPersonFaceAddServiceConfig(apiVersionIdentifier));
            Services.Add(FaceApiOperations.LargePersonGroupPersonFaceDelete.Name, new LargePersonGroupPersonFaceDeleteServiceConfig(apiVersionIdentifier));
            Services.Add(FaceApiOperations.LargePersonGroupPersonFaceGet.Name, new LargePersonGroupPersonFaceGetServiceConfig(apiVersionIdentifier));
            Services.Add(FaceApiOperations.LargePersonGroupTrainStart.Name, new LargePersonGroupTrainStartServiceConfig(apiVersionIdentifier));
            Services.Add(FaceApiOperations.LargePersonGroupTrainStatus.Name, new LargePersonGroupTrainStatusServiceConfig(apiVersionIdentifier));
        }
    }
}

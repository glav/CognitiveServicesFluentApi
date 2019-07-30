using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Face.Domain;

namespace Glav.CognitiveServices.FluentApi.Face.Configuration
{
    public class ApiServiceUriCollection : ApiServiceUriCollectionBase
    {
        public ApiServiceUriCollection()
        {
            Services.Add(FaceApiOperations.FaceDetection.Name, new FaceDetectionServiceConfig());
            Services.Add(FaceApiOperations.FaceIdentification.Name, new FaceIdentificationServiceConfig());
            Services.Add(FaceApiOperations.LargePersonGroupCreate.Name, new LargePersonGroupCreateServiceConfig());
            Services.Add(FaceApiOperations.LargePersonGroupGet.Name, new LargePersonGroupGetServiceConfig());
            Services.Add(FaceApiOperations.LargePersonGroupList.Name, new LargePersonGroupListServiceConfig());
            Services.Add(FaceApiOperations.LargePersonGroupDelete.Name, new LargePersonGroupDeleteServiceConfig());
            Services.Add(FaceApiOperations.LargePersonGroupPersonCreate.Name, new LargePersonGroupPersonCreateServiceConfig());
            Services.Add(FaceApiOperations.LargePersonGroupPersonGet.Name, new LargePersonGroupPersonGetServiceConfig());
            Services.Add(FaceApiOperations.LargePersonGroupPersonList.Name, new LargePersonGroupPersonListServiceConfig());
            Services.Add(FaceApiOperations.LargePersonGroupPersonDelete.Name, new LargePersonGroupPersonDeleteServiceConfig());
            Services.Add(FaceApiOperations.LargePersonGroupPersonFaceAdd.Name, new LargePersonGroupPersonFaceAddServiceConfig());
            Services.Add(FaceApiOperations.LargePersonGroupPersonFaceDelete.Name, new LargePersonGroupPersonFaceDeleteServiceConfig());
            Services.Add(FaceApiOperations.LargePersonGroupPersonFaceGet.Name, new LargePersonGroupPersonFaceGetServiceConfig());
            Services.Add(FaceApiOperations.LargePersonGroupTrainStart.Name, new LargePersonGroupTrainStartServiceConfig());
            Services.Add(FaceApiOperations.LargePersonGroupTrainStatus.Name, new LargePersonGroupTrainStatusServiceConfig());
        }
    }
}

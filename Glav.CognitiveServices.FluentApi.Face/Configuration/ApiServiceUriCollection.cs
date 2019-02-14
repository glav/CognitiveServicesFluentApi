﻿using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Face.Domain;

namespace Glav.CognitiveServices.FluentApi.Face.Configuration
{
    public class ApiServiceUriCollection : ApiServiceUriCollectionBase
    {
        public ApiServiceUriCollection()
        {
            Services.Add(FaceApiOperations.FaceDetection.Name, new FaceDetectionServiceConfig());
            Services.Add(FaceApiOperations.LargePersonGroupCreate.Name, new LargePersonGroupCreateServiceConfig());
            Services.Add(FaceApiOperations.LargePersonGroupGet.Name, new LargePersonGroupGetServiceConfig());
            Services.Add(FaceApiOperations.LargePersonGroupList.Name, new LargePersonGroupListServiceConfig());
            Services.Add(FaceApiOperations.LargePersonGroupDelete.Name, new LargePersonGroupDeleteServiceConfig());
        }
    }
}

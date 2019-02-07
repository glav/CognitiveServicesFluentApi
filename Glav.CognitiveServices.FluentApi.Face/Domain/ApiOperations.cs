using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public static class FaceApiOperations
    {
        public const string Category = "Face";
        static FaceApiOperations()
        {
            FaceDetection = new FaceDetectionApiOperation();
            LargePersonGroupCreate = new LargePersonGroupCreateApiOperation();
            LargePersonGroupGet = new LargePersonGroupGetApiOperation();
            LargePersonGroupList = new LargePersonGroupListApiOperation();
        }
        public static FaceDetectionApiOperation FaceDetection { get; }
        public static LargePersonGroupCreateApiOperation LargePersonGroupCreate { get; }
        public static LargePersonGroupGetApiOperation LargePersonGroupGet { get; }
        public static LargePersonGroupListApiOperation LargePersonGroupList { get; }

    }

    

    public class FaceDetectionApiOperation : ApiActionDefinition
    {
        public FaceDetectionApiOperation() : base(HttpMethod.Post, FaceApiOperations.Category)
        {
        }
    }
    public class LargePersonGroupGetApiOperation : ApiActionDefinition
    {
        public LargePersonGroupGetApiOperation() : base(HttpMethod.Get, FaceApiOperations.Category)
        {
        }
    }
    public class LargePersonGroupCreateApiOperation : ApiActionDefinition
    {
        public LargePersonGroupCreateApiOperation() : base(HttpMethod.Put, FaceApiOperations.Category)
        {
        }
    }
    public class LargePersonGroupListApiOperation : ApiActionDefinition
    {
        public LargePersonGroupListApiOperation() : base(HttpMethod.Get, FaceApiOperations.Category)
        {
        }
    }
}

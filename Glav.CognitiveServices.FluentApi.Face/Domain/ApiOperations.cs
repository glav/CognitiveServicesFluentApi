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
            LargePersonGroupDelete = new LargePersonGroupDeleteApiOperation();
            LargePersonGroupTrainStart = new LargePersonGroupTrainStartApiOperation();
            LargePersonGroupTrainStatus = new LargePersonGroupTrainStatusApiOperation();
            LargePersonGroupPersonCreate = new LargePersonGroupPersonCreateApiOperation();
            LargePersonGroupPersonGet = new LargePersonGroupPersonGetApiOperation();
            LargePersonGroupPersonList = new LargePersonGroupPersonListApiOperation();
            LargePersonGroupPersonDelete = new LargePersonGroupPersonDeleteApiOperation();
            LargePersonGroupPersonFaceAdd = new LargePersonGroupPersonFaceAddApiOperation();
            LargePersonGroupPersonFaceGet = new LargePersonGroupPersonFaceGetApiOperation();
            LargePersonGroupPersonFaceDelete = new LargePersonGroupPersonFaceDeleteApiOperation();
        }
        public static FaceDetectionApiOperation FaceDetection { get; }
        public static LargePersonGroupCreateApiOperation LargePersonGroupCreate { get; }
        public static LargePersonGroupGetApiOperation LargePersonGroupGet { get; }
        public static LargePersonGroupListApiOperation LargePersonGroupList { get; }
        public static LargePersonGroupDeleteApiOperation LargePersonGroupDelete { get; }
        public static LargePersonGroupTrainStartApiOperation LargePersonGroupTrainStart { get; }
        public static LargePersonGroupTrainStatusApiOperation LargePersonGroupTrainStatus { get; }
        public static LargePersonGroupPersonCreateApiOperation LargePersonGroupPersonCreate { get; }
        public static LargePersonGroupPersonGetApiOperation LargePersonGroupPersonGet { get; }
        public static LargePersonGroupPersonListApiOperation LargePersonGroupPersonList { get; }
        public static LargePersonGroupPersonDeleteApiOperation LargePersonGroupPersonDelete { get; }
        public static LargePersonGroupPersonFaceAddApiOperation LargePersonGroupPersonFaceAdd { get; }
        public static LargePersonGroupPersonFaceGetApiOperation LargePersonGroupPersonFaceGet { get; }
        public static LargePersonGroupPersonFaceDeleteApiOperation LargePersonGroupPersonFaceDelete { get; }

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

    public class LargePersonGroupDeleteApiOperation : ApiActionDefinition
    {
        public LargePersonGroupDeleteApiOperation() : base(HttpMethod.Delete, FaceApiOperations.Category)
        {
        }
    }

    // Large Person group person operations
    public class LargePersonGroupPersonGetApiOperation : ApiActionDefinition
    {
        public LargePersonGroupPersonGetApiOperation() : base(HttpMethod.Get, FaceApiOperations.Category)
        {
        }
    }

    public class LargePersonGroupPersonCreateApiOperation : ApiActionDefinition
    {
        public LargePersonGroupPersonCreateApiOperation() : base(HttpMethod.Post, FaceApiOperations.Category)
        {
        }
    }
    public class LargePersonGroupPersonListApiOperation : ApiActionDefinition
    {
        public LargePersonGroupPersonListApiOperation() : base(HttpMethod.Get, FaceApiOperations.Category)
        {
        }
    }
    public class LargePersonGroupPersonDeleteApiOperation : ApiActionDefinition
    {
        public LargePersonGroupPersonDeleteApiOperation() : base(HttpMethod.Delete, FaceApiOperations.Category)
        {
        }
    }
    public class LargePersonGroupPersonFaceAddApiOperation : ApiActionDefinition
    {
        public LargePersonGroupPersonFaceAddApiOperation() : base(HttpMethod.Post, FaceApiOperations.Category)
        {
        }
    }

    public class LargePersonGroupPersonFaceGetApiOperation : ApiActionDefinition
    {
        public LargePersonGroupPersonFaceGetApiOperation() : base(HttpMethod.Get, FaceApiOperations.Category)
        {
        }
    }

    public class LargePersonGroupPersonFaceDeleteApiOperation : ApiActionDefinition
    {
        public LargePersonGroupPersonFaceDeleteApiOperation() : base(HttpMethod.Delete, FaceApiOperations.Category)
        {
        }
    }

    public class LargePersonGroupTrainStartApiOperation : ApiActionDefinition
    {
        public LargePersonGroupTrainStartApiOperation() : base(HttpMethod.Post, FaceApiOperations.Category)
        {
        }
    }

    public class LargePersonGroupTrainStatusApiOperation : ApiActionDefinition
    {
        public LargePersonGroupTrainStatusApiOperation() : base(HttpMethod.Get, FaceApiOperations.Category)
        {
        }
    }


}

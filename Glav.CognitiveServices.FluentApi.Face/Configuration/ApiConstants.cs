using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Face.Configuration
{
    public static class ApiConstants
    {
        public const string FACE_VERSION = "v1.0";
        public const string FaceDetectionFaceAttributesUrlParameterName = "returnFaceAttributes";
        public const string FaceDetectionFaceIdUrlParameterName = "returnFaceId";
        public const string FaceDetectionFaceLandmarksUrlParameterName = "returnFaceLandmarks";
        public const string LargePersonGroupStartParameterName = "start";
        public const string LargePersonGroupTopParameterName = "top";
        public const string LargePersonGroupUserDataParameterName = "userData";
        public const string LargePersonGroupTargetFaceParameterName = "targetFace";

        public const string LargePersonGroupTrainStatusSucceeded = "succeeded";
        public const string LargePersonGroupTrainStatusFailed = "failed";
        public const string LargePersonGroupTrainStatusRunning = "running";
        public const string LargePersonGroupTrainStatusNotStarted = "notstarted";

    }
}

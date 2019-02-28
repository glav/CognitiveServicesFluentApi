using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup;
using Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson;

namespace Glav.CognitiveServices.FluentApi.Face
{
    public class FaceAnalysisResults : IAnalysisResults
    {
        public FaceAnalysisResults(CoreAnalysisSettings analysisSettings)
        {
            AnalysisSettings = analysisSettings;
        }
        public CoreAnalysisSettings AnalysisSettings { get; private set;}

        public FaceDetectionAnalysisContext FaceDetectionAnalysis { get; private set; }
        public LargePersonGroupCreateAnalysisContext LargePersonGroupCreateAnalysis { get; private set; }
        public LargePersonGroupGetAnalysisContext LargePersonGroupGetAnalysis { get; private set; }
        public LargePersonGroupListAnalysisContext LargePersonGroupListAnalysis { get; private set; }
        public LargePersonGroupDeleteAnalysisContext LargePersonGroupDeleteAnalysis { get; private set; }

        public LargePersonGroupPersonCreateAnalysisContext LargePersonGroupPersonCreateAnalysis { get; private set; }
        public LargePersonGroupPersonGetAnalysisContext LargePersonGroupPersonGetAnalysis { get; private set; }
        public LargePersonGroupPersonListAnalysisContext LargePersonGroupPersonListAnalysis { get; private set; }
        public LargePersonGroupPersonDeleteAnalysisContext LargePersonGroupPersonDeleteAnalysis { get; private set; }
        public LargePersonGroupPersonFaceAddAnalysisContext LargePersonGroupPersonFaceAddAnalysis { get; private set; }
        public LargePersonGroupPersonFaceGetAnalysisContext LargePersonGroupPersonFaceGetAnalysis { get; private set; }

        public void SetResult(FaceDetectionAnalysisContext faceDetectionAnalysis)
        {
            FaceDetectionAnalysis = faceDetectionAnalysis;
        }
        public void SetResult(LargePersonGroupCreateAnalysisContext largePersonGroupCreateAnalysis)
        {
            LargePersonGroupCreateAnalysis = largePersonGroupCreateAnalysis;
        }

        public void SetResult(LargePersonGroupGetAnalysisContext largePersonGroupGetAnalysis)
        {
            LargePersonGroupGetAnalysis = largePersonGroupGetAnalysis;
        }
        public void SetResult(LargePersonGroupListAnalysisContext largePersonGroupListAnalysis)
        {
            LargePersonGroupListAnalysis = largePersonGroupListAnalysis;
        }
        public void SetResult(LargePersonGroupDeleteAnalysisContext largePersonGroupDeleteAnalysis)
        {
            LargePersonGroupDeleteAnalysis = largePersonGroupDeleteAnalysis;
        }

        public void SetResult(LargePersonGroupPersonDeleteAnalysisContext largePersonGroupPersonDeleteAnalysis)
        {
            LargePersonGroupPersonDeleteAnalysis = largePersonGroupPersonDeleteAnalysis;
        }
        public void SetResult(LargePersonGroupPersonCreateAnalysisContext largePersonGroupPersonCreateAnalysis)
        {
            LargePersonGroupPersonCreateAnalysis = largePersonGroupPersonCreateAnalysis;
        }
        public void SetResult(LargePersonGroupPersonGetAnalysisContext largePersonGroupPersonGetAnalysis)
        {
            LargePersonGroupPersonGetAnalysis = largePersonGroupPersonGetAnalysis;
        }
        public void SetResult(LargePersonGroupPersonListAnalysisContext largePersonGroupPersonListAnalysis)
        {
            LargePersonGroupPersonListAnalysis = largePersonGroupPersonListAnalysis;
        }
        public void SetResult(LargePersonGroupPersonFaceAddAnalysisContext largePersonGroupPersonFaceAddAnalysis)
        {
            LargePersonGroupPersonFaceAddAnalysis = largePersonGroupPersonFaceAddAnalysis;
        }

        public void SetResult(LargePersonGroupPersonFaceGetAnalysisContext largePersonGroupPersonFaceGetAnalysis)
        {
            LargePersonGroupPersonFaceGetAnalysis = largePersonGroupPersonFaceGetAnalysis;
        }
    }
}

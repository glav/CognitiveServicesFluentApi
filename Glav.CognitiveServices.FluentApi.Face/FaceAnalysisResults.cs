using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup;

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

    }
}

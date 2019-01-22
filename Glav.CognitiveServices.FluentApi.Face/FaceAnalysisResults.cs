using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Face.Domain;

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
        public LargePersonGroupAnalysisContext LargePersonGroupAnalysis { get; private set; }
        public void SetResult(FaceDetectionAnalysisContext faceDetectionAnalysis)
        {
            FaceDetectionAnalysis = faceDetectionAnalysis;
        }
        public void SetResult(LargePersonGroupAnalysisContext largePersonGroupAnalysis)
        {
            LargePersonGroupAnalysis = largePersonGroupAnalysis;
        }

    }
}

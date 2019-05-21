using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
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
        public FaceIdentificationAnalysisContext FaceIdentificationAnalysis { get; private set; }
        public LargePersonGroupCreateAnalysisContext LargePersonGroupCreateAnalysis { get; private set; }
        public LargePersonGroupGetAnalysisContext LargePersonGroupGetAnalysis { get; private set; }
        public LargePersonGroupListAnalysisContext LargePersonGroupListAnalysis { get; private set; }
        public LargePersonGroupDeleteAnalysisContext LargePersonGroupDeleteAnalysis { get; private set; }
        public LargePersonGroupTrainStartAnalysisContext LargePersonGroupTrainStartAnalysis { get; private set; }
        public LargePersonGroupTrainStatusAnalysisContext LargePersonGroupTrainStatusAnalysis { get; private set; }

        public LargePersonGroupPersonCreateAnalysisContext LargePersonGroupPersonCreateAnalysis { get; private set; }
        public LargePersonGroupPersonGetAnalysisContext LargePersonGroupPersonGetAnalysis { get; private set; }
        public LargePersonGroupPersonListAnalysisContext LargePersonGroupPersonListAnalysis { get; private set; }
        public LargePersonGroupPersonDeleteAnalysisContext LargePersonGroupPersonDeleteAnalysis { get; private set; }
        public LargePersonGroupPersonFaceAddAnalysisContext LargePersonGroupPersonFaceAddAnalysis { get; private set; }
        public LargePersonGroupPersonFaceGetAnalysisContext LargePersonGroupPersonFaceGetAnalysis { get; private set; }
        public LargePersonGroupPersonFaceDeleteAnalysisContext LargePersonGroupPersonFaceDeleteAnalysis { get; private set; }

        public void AddFaceDetectionResult(ApiActionDataCollection actionData, ICommunicationResult commsResult)
        {
            if (FaceDetectionAnalysis == null)
            {
                FaceDetectionAnalysis = new FaceDetectionAnalysisContext(actionData, new FaceDetectionResult(commsResult), AnalysisSettings.ConfigurationSettings.GlobalScoringEngine);
                return;
            }
            FaceDetectionAnalysis.AnalysisResults.Add(new FaceDetectionResult(commsResult));
        }
        public void AddFaceIdentificationResult(ApiActionDataCollection actionData, ICommunicationResult commsResult)
        {
            if (FaceIdentificationAnalysis == null)
            {
                FaceIdentificationAnalysis = new FaceIdentificationAnalysisContext(actionData, new FaceIdentificationResult(commsResult), AnalysisSettings.ConfigurationSettings.GlobalScoringEngine);
                return;
            }
            FaceIdentificationAnalysis.AnalysisResults.Add(new FaceIdentificationResult(commsResult));
        }

        public void AddLargePersonGroupCreateResult(ApiActionDataCollection actionData, ICommunicationResult commsResult)
        {
            if (LargePersonGroupCreateAnalysis == null)
            {
                LargePersonGroupCreateAnalysis = new LargePersonGroupCreateAnalysisContext(actionData, new LargePersonGroupCreateResult(commsResult), AnalysisSettings.ConfigurationSettings.GlobalScoringEngine);
                return;
            }
            LargePersonGroupCreateAnalysis.AnalysisResults.Add(new LargePersonGroupCreateResult(commsResult));
        }

        public void AddLargePersonGroupGetResult(ApiActionDataCollection actionData, ICommunicationResult commsResult)
        {
            if (LargePersonGroupGetAnalysis == null)
            {
                LargePersonGroupGetAnalysis = new LargePersonGroupGetAnalysisContext(actionData, new LargePersonGroupGetResult(commsResult), AnalysisSettings.ConfigurationSettings.GlobalScoringEngine);
                return;
            }
            LargePersonGroupGetAnalysis.AnalysisResults.Add(new LargePersonGroupGetResult(commsResult));
        }
        public void AddLargePersonGroupListResult(ApiActionDataCollection actionData, ICommunicationResult commsResult)
        {
            if (LargePersonGroupListAnalysis == null)
            {
                LargePersonGroupListAnalysis = new LargePersonGroupListAnalysisContext(actionData, new LargePersonGroupListResult(commsResult), AnalysisSettings.ConfigurationSettings.GlobalScoringEngine);
                return;
            }
            LargePersonGroupListAnalysis.AnalysisResults.Add(new LargePersonGroupListResult(commsResult));
        }
        public void AddLargePersonGroupDeleteResult(ApiActionDataCollection actionData, ICommunicationResult commsResult)
        {
            if (LargePersonGroupDeleteAnalysis == null)
            {
                LargePersonGroupDeleteAnalysis = new LargePersonGroupDeleteAnalysisContext(actionData, new LargePersonGroupDeleteResult(commsResult), AnalysisSettings.ConfigurationSettings.GlobalScoringEngine); 
                return;
            }
            LargePersonGroupDeleteAnalysis.AnalysisResults.Add(new LargePersonGroupDeleteResult(commsResult));
        }
        public void AddLargePersonGroupTrainStartResult(ApiActionDataCollection actionData, ICommunicationResult commsResult)
        {
            LargePersonGroupTrainStartAnalysis = new LargePersonGroupTrainStartAnalysisContext(actionData,new LargePersonGroupTrainStartResult(commsResult), AnalysisSettings.ConfigurationSettings.GlobalScoringEngine);
        }
        public void SetargePersonGroupTrainStatusResult(ApiActionDataCollection actionData, ICommunicationResult commsResult)
        {
            LargePersonGroupTrainStatusAnalysis = new LargePersonGroupTrainStatusAnalysisContext(actionData,new LargePersonGroupTrainStatusResult(commsResult),AnalysisSettings.ConfigurationSettings.GlobalScoringEngine);
        }

        public void AddLargePersonGroupPersonDeleteResult(ApiActionDataCollection actionData, ICommunicationResult commsResult)
        {
            if (LargePersonGroupPersonDeleteAnalysis == null)
            {
                LargePersonGroupPersonDeleteAnalysis = new LargePersonGroupPersonDeleteAnalysisContext(actionData, new LargePersonGroupPersonDeleteResult(commsResult), AnalysisSettings.ConfigurationSettings.GlobalScoringEngine);
                return;
            }
            LargePersonGroupPersonDeleteAnalysis.AnalysisResults.Add(new LargePersonGroupPersonDeleteResult(commsResult));
        }
        public void AddLargePersonGroupPersonCreateResult(ApiActionDataCollection actionData, ICommunicationResult commsResult)
        {
            if (LargePersonGroupPersonCreateAnalysis == null)
            {
                LargePersonGroupPersonCreateAnalysis = new LargePersonGroupPersonCreateAnalysisContext(actionData, new LargePersonGroupPersonCreateResult(commsResult), AnalysisSettings.ConfigurationSettings.GlobalScoringEngine);
                return;
            }
            LargePersonGroupPersonCreateAnalysis.AnalysisResults.Add(new LargePersonGroupPersonCreateResult(commsResult));
        }
        public void AddLargePersonGroupPersonGetResult(ApiActionDataCollection actionData, ICommunicationResult commsResult)
        {
            if (LargePersonGroupPersonGetAnalysis == null)
            {
                LargePersonGroupPersonGetAnalysis = new LargePersonGroupPersonGetAnalysisContext(actionData, new LargePersonGroupPersonGetResult(commsResult), AnalysisSettings.ConfigurationSettings.GlobalScoringEngine);
                return;
            }
            LargePersonGroupPersonGetAnalysis.AnalysisResults.Add(new LargePersonGroupPersonGetResult(commsResult));
        }
        public void AddLargePersonGroupPersonListResult(ApiActionDataCollection actionData, ICommunicationResult commsResult)
        {
            if (LargePersonGroupPersonListAnalysis == null)
            {
                LargePersonGroupPersonListAnalysis = new LargePersonGroupPersonListAnalysisContext(actionData, new LargePersonGroupPersonListResult(commsResult), AnalysisSettings.ConfigurationSettings.GlobalScoringEngine);
                return;
            }
            LargePersonGroupPersonListAnalysis.AnalysisResults.Add(new LargePersonGroupPersonListResult(commsResult));
        }
        public void AddLargePersonGroupPersonFaceAddResult(ApiActionDataCollection actionData, ICommunicationResult commsResult)
        {
            if (LargePersonGroupPersonFaceAddAnalysis == null)
            {
                LargePersonGroupPersonFaceAddAnalysis = new LargePersonGroupPersonFaceAddAnalysisContext(actionData, new LargePersonGroupPersonFaceAddResult(commsResult), AnalysisSettings.ConfigurationSettings.GlobalScoringEngine);
                return;
            }
            LargePersonGroupPersonFaceAddAnalysis.AnalysisResults.Add(new LargePersonGroupPersonFaceAddResult(commsResult));
        }

        public void AddLargePersonGroupPersonFaceGetResult(ApiActionDataCollection actionData, ICommunicationResult commsResult)
        {
            if (LargePersonGroupPersonFaceGetAnalysis == null)
            {
                LargePersonGroupPersonFaceGetAnalysis = new LargePersonGroupPersonFaceGetAnalysisContext(actionData, new LargePersonGroupPersonFaceGetResult(commsResult), AnalysisSettings.ConfigurationSettings.GlobalScoringEngine);
                return;
            }
            LargePersonGroupPersonFaceGetAnalysis.AnalysisResults.Add(new LargePersonGroupPersonFaceGetResult(commsResult));
        }
        public void AddLargePersonGroupPersonFaceDeleteResult(ApiActionDataCollection actionData, ICommunicationResult commsResult)
        {
            if (LargePersonGroupPersonFaceDeleteAnalysis == null)
            {
                LargePersonGroupPersonFaceDeleteAnalysis = new LargePersonGroupPersonFaceDeleteAnalysisContext(actionData, new LargePersonGroupPersonFaceDeleteResult(commsResult), AnalysisSettings.ConfigurationSettings.GlobalScoringEngine);
                return;
            }
            LargePersonGroupPersonFaceDeleteAnalysis.AnalysisResults.Add(new LargePersonGroupPersonFaceDeleteResult(commsResult));
        }
    }
}

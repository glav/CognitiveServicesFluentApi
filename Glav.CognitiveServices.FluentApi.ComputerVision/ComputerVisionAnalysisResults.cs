using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public class ComputerVisionAnalysisResults : IAnalysisResults
    {
        public ComputerVisionAnalysisResults(CoreAnalysisSettings analysisSettings)
        {
            AnalysisSettings = analysisSettings;
        }
        public CoreAnalysisSettings AnalysisSettings { get; private set; }

        public ImageAnalysisContext ImageAnalysis { get; private set; }
        public OcrAnalysisContext OcrAnalysis { get; private set; }
        public RecognizeTextAnalysisContext RecognizeTextAnalysis { get; private set; }

        public void SetImageResultContext(ImageAnalysisContext imageAnalysisCtxt)
        {
            ImageAnalysis = imageAnalysisCtxt ?? throw new ArgumentNullException("imageAnalysisCtxt");
        }
        public void SetOcrResultContext(OcrAnalysisContext ocrAnalysisCtxt)
        {
            OcrAnalysis = ocrAnalysisCtxt ?? throw new ArgumentNullException("ocrAnalysisCtxt");
        }

        public void SetRecognizeTextResultContext(RecognizeTextAnalysisContext recognizeTxtCtxt)
        {
            RecognizeTextAnalysis = recognizeTxtCtxt ?? throw new ArgumentNullException("recognizeTxtCtxt");

        }

        public void AddImageAnalysisResult(ApiActionDataCollection actionData, ICommunicationResult commsResult)
        {
            if (ImageAnalysis == null)
            {
                ImageAnalysis = new ImageAnalysisContext(actionData, new ImageAnalysisResult(commsResult), AnalysisSettings.ConfigurationSettings.GlobalScoringEngine);
                return;
            }
            ImageAnalysis.AnalysisResults.Add(new ImageAnalysisResult(commsResult));

        }

        public void AddOcrAnalysisResult(ApiActionDataCollection actionData, ICommunicationResult commsResult)
        {
            if (OcrAnalysis == null)
            {
                OcrAnalysis = new OcrAnalysisContext(actionData, new OcrAnalysisResult(commsResult), AnalysisSettings.ConfigurationSettings.GlobalScoringEngine);
                return;
            }
            OcrAnalysis.AnalysisResults.Add(new OcrAnalysisResult(commsResult));
        }

        public void AddRecognizeTextResult(ApiActionDataCollection actionData, ICommunicationResult commsResult)
        {
            if (RecognizeTextAnalysis == null)
            {
                RecognizeTextAnalysis = new RecognizeTextAnalysisContext(actionData, new RecognizeTextAnalysisResult(commsResult), AnalysisSettings.ConfigurationSettings.GlobalScoringEngine);
                return;
            }
            RecognizeTextAnalysis.AnalysisResults.Add(new RecognizeTextAnalysisResult(commsResult));
        }
    }
}

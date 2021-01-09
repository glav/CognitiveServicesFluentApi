using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Configuration
{
    public class OcrAnalysisServiceConfig : ApiServiceUriFragment
    {
        public override string Template => "vision/{0}/ocr";

        public override string Version => ApiConstants.DEFAULT_ComputerVisionVersion;

        public override ApiActionDefinition ApiAction => ComputerVisionApiOperations.OcrAnalysis;
    }
}

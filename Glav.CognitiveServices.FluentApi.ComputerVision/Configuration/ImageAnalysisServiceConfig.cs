using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Configuration
{
    public class ImageAnalysisServiceConfig : ApiServiceUriFragment
    {
        public ImageAnalysisServiceConfig(string apiVersionIdentifier) : base(apiVersionIdentifier) { }
        public override string Template => "vision/{0}/analyze";

        public override ApiActionDefinition ApiAction => ComputerVisionApiOperations.ImageAnalysis;
    }
}

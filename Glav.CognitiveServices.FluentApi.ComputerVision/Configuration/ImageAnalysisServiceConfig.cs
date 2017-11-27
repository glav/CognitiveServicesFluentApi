using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Configuration
{
    public class ImageAnalysisServiceConfig : ApiServiceUriFragment
    {
        public override string Template => "vision/{0}/analyze";

        public override string Version => "v1.0";

        public override ApiActionCategory ApiCategory => ApiActionCategory.ComputerVision;
    }
}

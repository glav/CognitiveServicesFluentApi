using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public class ImageAnalysisActionData : IApiActionData
    {
        public string url { get; set; }
    }
}

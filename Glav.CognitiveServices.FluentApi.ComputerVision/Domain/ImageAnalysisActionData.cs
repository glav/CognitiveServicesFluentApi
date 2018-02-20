using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public class ImageAnalysisActionData : IApiActionData
    {
        public ImageAnalysisActionData(Uri imageUri, 
                ImageAnalysisVisualFeatures visualFeatures, 
                ImageAnalysisDetails imageDetails, 
                SupportedLanguageType language)
        {
            ImageUriToAnalyse = imageUri ?? throw new ArgumentNullException("ImageUri is required");
            VisualFeatures = visualFeatures;
        }

        public Uri ImageUriToAnalyse { get; private set; }
        public ImageAnalysisVisualFeatures VisualFeatures { get; private set; }
        public ImageAnalysisDetails ImageDetails { get; private set; }
        public SupportedLanguageType Language { get; private set; }

        public override string ToString()
        {
            return string.Format("{{\"url\":\"{0}\"}}", ImageUriToAnalyse.AbsoluteUri);
        }
    }
}

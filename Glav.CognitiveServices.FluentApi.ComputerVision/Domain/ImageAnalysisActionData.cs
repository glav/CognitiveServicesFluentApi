using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public class ImageAnalysisActionData : ApiActionDataCollection
    {
        public override bool SupportsBatchingMultipleItems => false;

        public void Add(Uri imageUri,
                ImageAnalysisVisualFeatures visualFeatures,
                ImageAnalysisDetails imageDetails, SupportedLanguageType language = SupportedLanguageType.English)
        {
            ItemList.Add(new ImageAnalysisActionDataItem(ItemList.Count+1, imageUri, visualFeatures, imageDetails,language));
        }
    }

    public class ImageAnalysisActionDataItem : IActionDataItem
    {
        public ImageAnalysisActionDataItem(long id,Uri imageUri, 
                ImageAnalysisVisualFeatures visualFeatures, 
                ImageAnalysisDetails imageDetails, 
                SupportedLanguageType language)
        {
            Id = id;
            ImageUriToAnalyse = imageUri ?? throw new ArgumentNullException("ImageUri is required");
            VisualFeatures = visualFeatures;
            ImageDetails = imageDetails;
            Language = language;
        }

        public Uri ImageUriToAnalyse { get; private set; }
        public ImageAnalysisVisualFeatures VisualFeatures { get; private set; }
        public ImageAnalysisDetails ImageDetails { get; private set; }
        public SupportedLanguageType Language { get; private set; }

        public ApiActionType ApiType => ApiActionType.ComputerVisionImageAnalysis;

        public long Id { get; private set; }

        public override string ToString()
        {
            return string.Format("{{\"url\":\"{0}\"}}", ImageUriToAnalyse.AbsoluteUri);
        }

        public string ToUrlQueryParameters()
        {
            var url = new StringBuilder();
            var visualFeaturesUrlParameters = VisualFeatures.ToUrlQueryParameters();
            var detailsUrlparams = ImageDetails.ToUrlQueryParameters();
            var languageUrlParams = Language.ToUrlQueryParameter();

            if (!string.IsNullOrWhiteSpace(visualFeaturesUrlParameters))
            {
                url.AppendFormat("{0}", visualFeaturesUrlParameters);
            }
            if (!string.IsNullOrWhiteSpace(detailsUrlparams))
            {
                url.AppendFormat("{0}{1}", url.Length > 0 ? "&" : string.Empty, detailsUrlparams);
            }
            if (!string.IsNullOrWhiteSpace(languageUrlParams))
            {
                url.AppendFormat("{0}{1}", url.Length > 0 ? "&" : string.Empty, languageUrlParams);
            }
            return url.ToString();
        }
    }
}

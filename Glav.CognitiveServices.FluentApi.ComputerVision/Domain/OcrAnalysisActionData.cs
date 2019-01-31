using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public class OcrAnalysisActionData : ApiActionDataCollection
    {
        public override bool SupportsBatchingMultipleItems => false;

        public void Add(Uri imageUri,
                bool detectOrientation, SupportedLanguageType language = SupportedLanguageType.English)
        {
            ItemList.Add(new OcrAnalysisActionDataItem(ItemList.Count+1, imageUri, detectOrientation,language));
        }

        public void Add(byte[] imageData,
                bool detectOrientation, SupportedLanguageType language = SupportedLanguageType.English)
        {
            ItemList.Add(new OcrAnalysisActionDataItem(ItemList.Count + 1, imageData, detectOrientation, language));
        }

    }

    public class OcrAnalysisActionDataItem : IActionDataItem
    {
        public OcrAnalysisActionDataItem(long id,Uri imageUri,
                bool detectOrientation, 
                SupportedLanguageType language)
        {
            Id = id;
            ImageUriToAnalyse = imageUri ?? throw new ArgumentNullException("ImageUri is required");
            Language = language;
        }

        public OcrAnalysisActionDataItem(long id, byte[] imageData,
                bool detectOrientation,
                SupportedLanguageType language)
        {
            Id = id;
            ImageDataToAnalyse = imageData ?? throw new ArgumentNullException("ImageData is required");
            Language = language;
        }

        public bool IsBinaryData => ImageUriToAnalyse == null && ImageDataToAnalyse != null;

        public byte[] ImageDataToAnalyse { get; private set; }
        public Uri ImageUriToAnalyse { get; private set; }
        public bool DetectOrientation{ get; private set; }
        public SupportedLanguageType Language { get; private set; }

        public ApiActionDefinition ApiType => ComputerVisionApiOperations.OcrAnalysis;

        public long Id { get; private set; }

        public byte[] ToBinary()
        {
            return ImageDataToAnalyse;
        }

        public override string ToString()
        {
            if (ImageUriToAnalyse == null)
            {
                return Convert.ToBase64String(ImageDataToAnalyse);
            }
            return string.Format("{{\"url\":\"{0}\"}}", ImageUriToAnalyse.AbsoluteUri);
        }

        public string ToUrlQueryParameters()
        {
            var url = new StringBuilder();
            var languageUrlParams = Language.ToUrlQueryParameter();

            if (!string.IsNullOrWhiteSpace(languageUrlParams))
            {
                url.AppendFormat("{0}{1}", url.Length > 0 ? "&" : "?", languageUrlParams);
            }
            if (DetectOrientation)
            {
                url.AppendFormat("{0}{1}=true", url.Length > 0 ? "&" : "?", Glav.CognitiveServices.FluentApi.ComputerVision.Configuration.ApiConstants.DetectOrientation);
            }
            return url.ToString();
        }
    }
}

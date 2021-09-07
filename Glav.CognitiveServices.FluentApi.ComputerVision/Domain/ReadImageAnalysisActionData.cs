using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public class ReadImageAnalysisActionData : ApiActionDataCollection
    {
        public override bool SupportsBatchingMultipleItems => false;

        public void Add(Uri imageUri,SupportedLanguageType language)
        {
            ItemList.Add(new ReadimageAnalysisActionDataItem(ItemList.Count+1, imageUri, language));
        }

        public void Add(byte[] imageData, SupportedLanguageType language)
        {
            ItemList.Add(new ReadimageAnalysisActionDataItem(ItemList.Count + 1, imageData, language));
        }

    }

    public class ReadimageAnalysisActionDataItem : IActionDataItem
    {
        public ReadimageAnalysisActionDataItem(long id,Uri imageUri,
                SupportedLanguageType language)
        {
            Id = id;
            ImageUriToAnalyse = imageUri ?? throw new ArgumentNullException("imageUri");
            Language = language;
        }

        public ReadimageAnalysisActionDataItem(long id, byte[] imageData,
                SupportedLanguageType language)
        {
            Id = id;
            ImageDataToAnalyse = imageData ?? throw new ArgumentNullException("imageData");
            Language = language;
        }

        public bool IsBinaryData => ImageUriToAnalyse == null && ImageDataToAnalyse != null;

        public byte[] ImageDataToAnalyse { get; private set; }
        public Uri ImageUriToAnalyse { get; private set; }

        public ApiActionDefinition ApiDefintition => ComputerVisionApiOperations.ReadImage;

        public SupportedLanguageType Language { get; private set; }
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
            return Language.ToUrlQueryParameter();
        }
        public string ToEndUriFragment()
        {
            return null;
        }

    }
}

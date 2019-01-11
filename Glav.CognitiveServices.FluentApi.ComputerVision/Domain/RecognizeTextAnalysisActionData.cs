using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public class RecognizeTextAnalysisActionData : ApiActionDataCollection
    {
        public override bool SupportsBatchingMultipleItems => false;

        public void Add(Uri imageUri,RecognizeTextMode mode)
        {
            ItemList.Add(new RecognizeTextAnalysisActionDataItem(ItemList.Count+1, imageUri, mode));
        }

        public void Add(byte[] imageData, RecognizeTextMode mode)
        {
            ItemList.Add(new RecognizeTextAnalysisActionDataItem(ItemList.Count + 1, imageData, mode));
        }

    }

    public class RecognizeTextAnalysisActionDataItem : IActionDataItem
    {
        public RecognizeTextAnalysisActionDataItem(long id,Uri imageUri,
                RecognizeTextMode mode)
        {
            Id = id;
            ImageUriToAnalyse = imageUri ?? throw new ArgumentNullException("ImageUri is required");
            Mode = mode;
        }

        public RecognizeTextAnalysisActionDataItem(long id, byte[] imageData,
                RecognizeTextMode mode)
        {
            Id = id;
            ImageDataToAnalyse = imageData ?? throw new ArgumentNullException("ImageData is required");
            Mode = mode;
        }

        public bool IsBinaryData => ImageUriToAnalyse == null && ImageDataToAnalyse != null;

        public byte[] ImageDataToAnalyse { get; private set; }
        public Uri ImageUriToAnalyse { get; private set; }

        public ApiActionType ApiType => ApiActionType.ComputerVisionRecognizeText;

        public RecognizeTextMode Mode { get; private set; }
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
            return $"mode={Mode.ToUrlQueryArgument()}";
        }
    }
}

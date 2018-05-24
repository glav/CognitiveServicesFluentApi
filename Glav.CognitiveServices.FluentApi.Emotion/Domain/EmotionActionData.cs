using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Emotion.Domain
{
    public class EmotionActionData : ApiActionDataCollection
    {
        public override bool SupportsBatchingMultipleItems => false;

        public void Add(Uri imageUri)
        {
            ItemList.Add(new EmotionActionDataItem(ItemList.Count + 1,imageUri));
        }

        public override string ToUrlQueryParameters()
        {
            return null;
        }
    }

    public class EmotionActionDataItem : IActionDataItem
    {
        public ApiActionType ApiType => ApiActionType.EmotionImageRecognition;

        public EmotionActionDataItem(long id, Uri imageUri)
        {
            Id = id;
            ImageUriToAnalyse = imageUri ?? throw new ArgumentNullException("ImageUri is required");
        }

        public Uri ImageUriToAnalyse { get; private set; }

        public long Id { get; private set; }

        public override string ToString()
        {
            return string.Format("{{\"url\":\"{0}\"}}", ImageUriToAnalyse.AbsoluteUri);
        }

    }
}

﻿using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Emotion.Domain
{
    public class EmotionActionData : ApiActionDataCollection<EmotionActionDataItem>, IApiActionDataCollection
    {
        public bool SupportsBatchingMultipleItems => false;

        public void Add(Uri imageUri)
        {
            ItemList.Add(new EmotionActionDataItem(imageUri));
        }

        public string ToUrlQueryParameters()
        {
            return null;
        }
    }

    public class EmotionActionDataItem : IActionDataItem
    {
        public ApiActionType ApiType => ApiActionType.EmotionImageRecognition;

        public EmotionActionDataItem(Uri imageUri)
        {
            ImageUriToAnalyse = imageUri ?? throw new ArgumentNullException("ImageUri is required");
        }

        public Uri ImageUriToAnalyse { get; private set; }

        public override string ToString()
        {
            return string.Format("{{\"url\":\"{0}\"}}", ImageUriToAnalyse.AbsoluteUri);
        }

    }
}

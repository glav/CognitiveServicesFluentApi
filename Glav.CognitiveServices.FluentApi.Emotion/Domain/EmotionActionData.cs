using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Emotion.Domain
{
    public class EmotionActionData : IApiActionData
    {
        public EmotionActionData(Uri imageUri)
        {
            ImageUriToAnalyse = imageUri ?? throw new ArgumentNullException("ImageUri is required");
        }

        public Uri ImageUriToAnalyse {get; private set;}

        public override string ToString()
        {
            return string.Format("{{\"url\":\"{0}\"}}", ImageUriToAnalyse.AbsoluteUri);
        }
    }
}

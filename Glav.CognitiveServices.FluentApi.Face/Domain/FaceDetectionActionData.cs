using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using System;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public class FaceDetectionActionData : ApiActionDataCollection
    {
        public override bool SupportsBatchingMultipleItems => false;

        public void Add(Uri imageUri,
                FaceDetectionAttributes returnedAttributes,
                bool? returnFaceLandmarks = null,
                bool? returnFaceId = null)
        {
            ItemList.Add(new FaceDetectionActionDataItem(ItemList.Count+1, imageUri, returnedAttributes, returnFaceLandmarks,returnFaceId));
        }

        public void Add(byte[] imageData,
                FaceDetectionAttributes returnedAttributes,
                bool? returnFaceLandmarks = null,
                bool? returnFaceId = null)
        {
            ItemList.Add(new FaceDetectionActionDataItem(ItemList.Count + 1, imageData, returnedAttributes, returnFaceLandmarks, returnFaceId));
        }

    }

    public class FaceDetectionActionDataItem : IActionDataItem
    {
        public FaceDetectionActionDataItem(long id,Uri imageUri,
                FaceDetectionAttributes returnedAttributes,
                bool? returnFaceLandmarks = null,
                bool? returnFaceId = null)
        {
            Id = id;
            ImageUriToAnalyse = imageUri ?? throw new ArgumentNullException("imageUri");
            ReturnedAttributes = returnedAttributes;
            ReturnFaceId = returnFaceId;
            ReturnFaceLandmarks = returnFaceLandmarks;
        }

        public FaceDetectionActionDataItem(long id, byte[] imageData,
                FaceDetectionAttributes returnedAttributes,
                bool? returnFaceLandmarks = null,
                bool? returnFaceId = null)
        {
            Id = id;
            ImageDataToAnalyse = imageData ?? throw new ArgumentNullException("imageData");
            ReturnedAttributes = returnedAttributes;
            ReturnFaceId = returnFaceId;
            ReturnFaceLandmarks = returnFaceLandmarks;
        }

        public bool IsBinaryData => ImageUriToAnalyse == null && ImageDataToAnalyse != null;

        public byte[] ImageDataToAnalyse { get; private set; }
        public Uri ImageUriToAnalyse { get; private set; }
        public FaceDetectionAttributes ReturnedAttributes { get; private set; }
        public bool? ReturnFaceId { get; private set; }
        public bool? ReturnFaceLandmarks { get; private set; }

        public ApiActionDefinition ApiType => FaceApiOperations.FaceDetection;

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
            var facialAttributes = UrlQueryParameterFromEnumFormatter.ToUrlQueryParameters<FaceDetectionAttributes>(ReturnedAttributes, 
                        Configuration.ApiConstants.FaceDetectionFaceAttributesUrlParameterName);

            if (!string.IsNullOrWhiteSpace(facialAttributes))
            {
                url.AppendFormat("{0}", facialAttributes);
            }
            if (ReturnFaceId.HasValue)
            {
                url.AppendFormat("{0}{1}", url.Length > 0 ? "&" : string.Empty, $"{Configuration.ApiConstants.FaceDetectionFaceIdUrlParameterName}={ReturnFaceId.ToString()}");
            }
            if (ReturnFaceLandmarks.HasValue)
            {
                url.AppendFormat("{0}{1}", url.Length > 0 ? "&" : string.Empty, $"{Configuration.ApiConstants.FaceDetectionFaceLandmarksUrlParameterName}={ReturnFaceLandmarks.ToString()}");
            }
            return url.ToString();
        }
    }
}

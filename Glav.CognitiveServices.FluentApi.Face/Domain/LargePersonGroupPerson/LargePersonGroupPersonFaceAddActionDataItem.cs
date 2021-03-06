﻿using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using System;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public class LargePersonGroupPersonFaceAddActionDataItem : LargePersonGroupPersonFaceActionDataItem
    {
        public LargePersonGroupPersonFaceAddActionDataItem(long id, string groupId, string personId, Uri imageUri,
               string userData = null, FaceRectangle targetFace = null)
           : base(id, FaceApiOperations.LargePersonGroupPersonFaceAdd, groupId, personId,null)
        {
            TargetFace = targetFace;
            ImageUri = imageUri;
        }

        public FaceRectangle TargetFace { get; private set; }
        public Uri ImageUri { get; private set; }

        public override string ToUrlQueryParameters()
        {
            var url = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(UserData))
            {
                url.AppendFormat("{0}{1}", url.Length > 0 ? "&" : string.Empty, $"{Configuration.ApiConstants.LargePersonGroupUserDataParameterName}={UserData}");
            }
            if (TargetFace != null)
            {
                url.AppendFormat("{0}{1}", url.Length > 0 ? "&" : string.Empty, $"{Configuration.ApiConstants.LargePersonGroupTargetFaceParameterName}={TargetFace.ToString()}");
            }
            return url.ToString();

        }

        public override string ToString()
        {
            return string.Format("{{\"url\":\"{0}\"}}", ImageUri.AbsoluteUri);
        }
    }
}

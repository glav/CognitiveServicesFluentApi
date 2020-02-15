using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using System;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public class FaceIdentificationActionData : ApiActionDataCollection
    {
        public override bool SupportsBatchingMultipleItems => false;

        public void Add(string personGroupId,
                string[] faceIds)
        {
            ItemList.Add(new FaceIdentificationActionDataItem(ItemList.Count+1, personGroupId, faceIds));
        }

        public void Add(string personGroupId,
                       string[] faceIds,
                       int maxCandidatesReturned,
                       float confidenceThreshold)
        {
            ItemList.Add(new FaceIdentificationActionDataItem(ItemList.Count + 1, personGroupId, faceIds,maxCandidatesReturned,confidenceThreshold));
        }
    }

    public class FaceIdentificationActionDataItem : IActionDataItem
    {
        public FaceIdentificationActionDataItem(long id,string personGroupId,
                string[] faceIds,
                int maxCandidatesReturned,
                float confidenceThreshold)
        {
            Id = id;
            LargePersonGroupId = personGroupId;
            FaceIds = faceIds;
            MaxNumOfCandidatesReturned = maxCandidatesReturned >= 0 && maxCandidatesReturned <= 100 ? maxCandidatesReturned : 0;
            ConfidenceThreshold = confidenceThreshold >= 0 && confidenceThreshold <= 1 ? confidenceThreshold : 0;
        }

        public FaceIdentificationActionDataItem(long id, string personGroupId,
                string[] faceIds)
        {
            Id = id;
            LargePersonGroupId = personGroupId;
            FaceIds = faceIds;
        }

        public bool IsBinaryData => false;

        public string LargePersonGroupId { get; private set; }
        public string[] FaceIds { get; private set; }
        public int MaxNumOfCandidatesReturned { get; private set; }
        public float ConfidenceThreshold { get; private set; }

        public ApiActionDefinition ApiDefintition => FaceApiOperations.FaceIdentification;

        public long Id { get; private set; }

        public byte[] ToBinary()
        {
            return Array.Empty<byte>();
        }
        public string ToEndUriFragment()
        {
            return null;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("{ ");
            builder.Append($"\"largePersonGroupId\":\"{LargePersonGroupId}\"");
            builder.Append($", \"faceIds\":[\"{string.Join("\",\"", FaceIds)}\"]");
            if (MaxNumOfCandidatesReturned > 0)
            {
                builder.Append($", \"maxNumOfCandidatesReturned\":{MaxNumOfCandidatesReturned}");
            }
            if (ConfidenceThreshold > 0)
            {
                builder.Append($", \"confidenceThreshold\":{ConfidenceThreshold}");
            }
            builder.Append("} ");
            return builder.ToString();
        }

        public string ToUrlQueryParameters()
        {
            return null;
        }
    }
}

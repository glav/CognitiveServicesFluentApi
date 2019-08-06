using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public abstract class LargePersonGroupPersonFaceActionDataItem : LargePersonGroupPersonActionDataItem
    {
        protected LargePersonGroupPersonFaceActionDataItem(long id, ApiActionDefinition faceOperation, string groupId, 
            string personId, string persistedFaceId)
            : base(id, faceOperation, groupId, personId)
        {
            PersistedFaceId = persistedFaceId;
        }


        public string PersistedFaceId { get; private set; }

        public override string ToEndUriFragment()
        {
            var uri = base.ToEndUriFragment() + "/persistedfaces";
            if (!string.IsNullOrWhiteSpace(PersistedFaceId))
            {
                return uri + $"/{PersistedFaceId}";
            }
            return uri;

        }

    }
}

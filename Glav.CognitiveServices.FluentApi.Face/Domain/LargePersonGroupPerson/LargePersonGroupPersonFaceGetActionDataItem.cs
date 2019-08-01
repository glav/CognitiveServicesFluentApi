namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public class LargePersonGroupPersonFaceGetActionDataItem : LargePersonGroupPersonFaceActionDataItem
    {
        public LargePersonGroupPersonFaceGetActionDataItem(long id, string groupId, string personId, string persistedFaceId)
           : base(id, FaceApiOperations.LargePersonGroupPersonFaceGet, groupId, personId, persistedFaceId)
        {
        }

    }
}

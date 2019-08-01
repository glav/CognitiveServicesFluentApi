namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public class LargePersonGroupPersonFaceDeleteActionDataItem : LargePersonGroupPersonFaceActionDataItem
    {
        public LargePersonGroupPersonFaceDeleteActionDataItem(long id, string groupId, string personId, string persistedFaceId)
           : base(id, FaceApiOperations.LargePersonGroupPersonFaceDelete, groupId, personId,persistedFaceId)
        {
        }

    }
}

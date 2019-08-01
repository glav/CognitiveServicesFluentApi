namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public class LargePersonGroupPersonDeleteActionDataItem : LargePersonGroupPersonActionDataItem
    {
        public LargePersonGroupPersonDeleteActionDataItem(long id, string groupId, string personId)
            : base(id, FaceApiOperations.LargePersonGroupPersonDelete, groupId, personId)
        {

        }
    }
}

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public class LargePersonGroupPersonGetActionDataItem : LargePersonGroupPersonActionDataItem
    {
        public LargePersonGroupPersonGetActionDataItem(long id, string groupId, string personId) 
            : base(id, FaceApiOperations.LargePersonGroupPersonGet,groupId,personId)
        {

        }
    }
}

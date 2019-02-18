namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public class LargePersonGroupPersonListActionDataItem : LargePersonGroupPersonActionDataItem
    {
        public LargePersonGroupPersonListActionDataItem(long id, string groupId) 
            : base(id, FaceApiOperations.LargePersonGroupPersonList,groupId,null)
        {

        }
    }
}

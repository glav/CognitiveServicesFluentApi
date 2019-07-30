namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public class LargePersonGroupPersonCreateActionDataItem : LargePersonGroupPersonActionDataItem
    {
        public LargePersonGroupPersonCreateActionDataItem(long id, string groupId,
                string name,
                string userData = null) : base(id, FaceApiOperations.LargePersonGroupPersonCreate,groupId, name, userData)
        {

        }
    }
}

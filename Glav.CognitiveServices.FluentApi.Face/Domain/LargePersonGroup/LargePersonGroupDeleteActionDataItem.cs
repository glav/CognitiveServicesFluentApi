namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup
{
    public class LargePersonGroupDeleteActionDataItem : LargePersonGroupActionDataItem
    {
        public LargePersonGroupDeleteActionDataItem(long id, string groupId): base(id, FaceApiOperations.LargePersonGroupDelete, groupId)
        {

        }
    }
}

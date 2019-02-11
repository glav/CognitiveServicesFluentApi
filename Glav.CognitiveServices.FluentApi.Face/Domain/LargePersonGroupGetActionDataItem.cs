namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public class LargePersonGroupGetActionDataItem : LargePersonGroupActionDataItem
    {
        public LargePersonGroupGetActionDataItem(long id, string groupId) : base(id, FaceApiOperations.LargePersonGroupGet, groupId)
        {
        }
    }
}

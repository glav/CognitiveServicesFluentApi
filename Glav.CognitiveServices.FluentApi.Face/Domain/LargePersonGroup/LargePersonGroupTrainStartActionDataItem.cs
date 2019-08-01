namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup
{
    public class LargePersonGroupTrainStartActionDataItem : LargePersonGroupActionDataItem
    {
        public LargePersonGroupTrainStartActionDataItem(long id, string groupId): base(id, FaceApiOperations.LargePersonGroupTrainStart, groupId)
        {

        }

        public override string ToEndUriFragment()
        {
            return base.ToEndUriFragment() + "/train";
        }
    }
}

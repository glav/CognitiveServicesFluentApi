namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup
{
    public class LargePersonGroupTrainStatusActionDataItem : LargePersonGroupActionDataItem
    {
        public LargePersonGroupTrainStatusActionDataItem(long id, string groupId): base(id, FaceApiOperations.LargePersonGroupTrainStatus, groupId)
        {

        }

        public override string ToEndUriFragment()
        {
            return base.ToEndUriFragment() + "/train";
        }
    }
}

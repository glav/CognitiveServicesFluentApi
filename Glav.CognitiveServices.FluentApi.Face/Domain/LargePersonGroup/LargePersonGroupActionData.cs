using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup
{
    public class LargePersonGroupActionData : ApiActionDataCollection
    {
        public override bool SupportsBatchingMultipleItems => false;

        public void AddPersonGroupCreate(string groupId,
                string name,
                string userData = null)
        {
            ItemList.Add(new LargePersonGroupCreateActionDataItem(ItemList.Count+1, groupId,name,userData));
        }

        public void AddPersonGroupGet(string groupId)
        {
            ItemList.Add(new LargePersonGroupGetActionDataItem(ItemList.Count + 1, groupId));
        }

        public void AddPersonGroupList(string start, int? top = null)
        {
            ItemList.Add(new LargePersonGroupListActionDataItem(ItemList.Count+1,start,top));
        }

        public void AddPersonGroupDelete(string groupId)
        {
            ItemList.Add(new LargePersonGroupDeleteActionDataItem(ItemList.Count + 1, groupId));
        }
        public void AddPersonGroupTrainStart(string groupId)
        {
            ItemList.Add(new LargePersonGroupTrainStartActionDataItem(ItemList.Count + 1, groupId));
        }
        public void AddPersonGroupTrainStatus(string groupId)
        {
            ItemList.Add(new LargePersonGroupTrainStatusActionDataItem(ItemList.Count + 1, groupId));
        }

    }
}

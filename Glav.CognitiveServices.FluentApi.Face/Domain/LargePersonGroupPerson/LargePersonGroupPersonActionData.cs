using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public class LargePersonGroupPersonActionData : ApiActionDataCollection
    {
        public override bool SupportsBatchingMultipleItems => false;

        public void AddPersonGroupPersonCreate(string groupId,
                string name,
                string userData = null)
        {
            //ItemList.Add(new LargePersonGroupCreateActionDataItem(ItemList.Count+1, groupId,name,userData));
        }

        public void AddPersonGroupPersonGet(string groupId)
        {
            //ItemList.Add(new LargePersonGroupGetActionDataItem(ItemList.Count + 1, groupId));
        }

        public void AddPersonGroupPersonList(string start, int? top = null)
        {
            //ItemList.Add(new LargePersonGroupListActionDataItem(ItemList.Count+1,start,top));
        }

        public void AddPersonGroupPersonDelete(string groupId)
        {
            //ItemList.Add(new LargePersonGroupDeleteActionDataItem(ItemList.Count + 1, groupId));
        }

    }
}

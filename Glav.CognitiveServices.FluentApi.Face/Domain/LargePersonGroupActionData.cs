using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using System;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public class LargePersonGroupActionData : ApiActionDataCollection
    {
        public override bool SupportsBatchingMultipleItems => false;

        public void Add(string groupId,
                string name,
                string userData = null)
        {
            ItemList.Add(new LargePersonGroupActionDataItem(ItemList.Count+1, groupId,name,userData));
        }

    }

    public class LargePersonGroupActionDataItem : IActionDataItem
    {
        public LargePersonGroupActionDataItem(long id, string groupId,
                string name,
                string userData = null)
        {
            Id = id;
            Name = name;
            GroupId = groupId;
            UserData = userData;
        }

        public bool IsBinaryData => false;

        public ApiActionType ApiType => ApiActionType.FaceLargePersonGroups;

        public string GroupId { get; private set; }
        public string Name { get; private set; }
        public string UserData { get; private set; }

        public long Id { get; private set; }

        public byte[] ToBinary()
        {
            return null;
        }

        public override string ToString()
        {
            return string.Format("{{\"name\":\"{0}\", \"userData\":\"{1}\"}}", Name, UserData);
        }

        public string ToUrlQueryParameters()
        {
            return $"/{GroupId}";
        }
    }
}

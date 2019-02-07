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

        public void AddPersonGroupCreate(string groupId,
                string name,
                string userData = null)
        {
            ItemList.Add(new LargePersonGroupActionDataItem(ItemList.Count+1, FaceApiOperations.LargePersonGroupCreate, groupId,name,userData));
        }

        public void AddPersonGroupGet(string groupId)
        {
            ItemList.Add(new LargePersonGroupActionDataItem(ItemList.Count + 1, groupId));
        }

        public void AddPersonGroupList(string start, int? top = null)
        {
            ItemList.Add(new LargePersonGroupListActionDataItem(ItemList.Count+1,start,top));
        }

    }

    public class LargePersonGroupActionDataItem : IActionDataItem
    {
        public LargePersonGroupActionDataItem(long id, ApiActionDefinition apiDefinition,
                string groupId,
                string name,
                string userData = null)
        {
            if (string.IsNullOrWhiteSpace(groupId))
            {
                throw new ArgumentNullException("groupId");
            }
            if (groupId.Length > 64)
            {
                throw new ArgumentException("groupId cannot exceed 64 in length");
            }
            if (apiDefinition == null)
            {
                throw new ArgumentNullException("apiDefinition");
            }
            ApiDefintition = apiDefinition;
            Id = id;
            Name = name;
            GroupId = groupId;
            UserData = userData;
        }

        /// <summary>
        /// Only used for PersonGroupGet at this time.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="groupId"></param>
        public LargePersonGroupActionDataItem(long id, string groupId)
        {
            if (string.IsNullOrWhiteSpace(groupId))
            {
                throw new ArgumentNullException("groupId");
            }
            if (groupId.Length > 64)
            {
                throw new ArgumentException("groupId cannot exceed 64 in length");
            }
            Id = id;
            GroupId = groupId;
            ApiDefintition = FaceApiOperations.LargePersonGroupGet;
        }

        public bool IsBinaryData => false;

        public ApiActionDefinition ApiDefintition { get; private set; }

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
            return null;
        }
        public string ToEndUriFragment()
        {
            return $"/{GroupId}";
        }

    }

    public class LargePersonGroupListActionDataItem : IActionDataItem
    {
        public LargePersonGroupListActionDataItem(long id, string start= null, int? top = null)
        {
            Id = id;
            Start = start;
            Top = top;
        }
        public long Id { get; private set; }

        public ApiActionDefinition ApiDefintition => FaceApiOperations.LargePersonGroupList;

        public bool IsBinaryData => false;

        public string Start { get; private set; }
        public int? Top { get; private set; }

        public byte[] ToBinary()
        {
            return null;
        }

        public string ToEndUriFragment()
        {
            return null;
        }

        public string ToUrlQueryParameters()
        {
            var url = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(Start))
            {
                url.AppendFormat("{0}{1}", url.Length > 0 ? "&" : string.Empty, $"{Configuration.ApiConstants.LargePersonGroupStartParameterName}={Start}");
            }
            if (Top.HasValue)
            {
                url.AppendFormat("{0}{1}", url.Length > 0 ? "&" : string.Empty, $"{Configuration.ApiConstants.LargePersonGroupStopParameterName}={Top}");
            }
            return url.ToString();

        }
    }
}

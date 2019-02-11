using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public abstract class LargePersonGroupActionDataItem : IActionDataItem
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

            ApiDefintition = apiDefinition ?? throw new ArgumentNullException("apiDefinition");
            Id = id;
            Name = name;
            GroupId = groupId;
            UserData = userData;
        }

        public LargePersonGroupActionDataItem(long id, ApiActionDefinition apiDefinition, string groupId)
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
            ApiDefintition = apiDefinition ?? throw new ArgumentNullException("apiDefinition");
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
}

using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup
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
            ValidateId(groupId, "groupId");
            Id = id;
            GroupId = groupId;
            ApiDefintition = apiDefinition ?? throw new ArgumentNullException("apiDefinition");
        }

        protected void ValidateId(string id, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("groupId");
            }
            if (id.Length > 64)
            {
                throw new ArgumentException("groupId cannot exceed 64 in length");
            }

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

        public virtual string ToUrlQueryParameters()
        {
            return null;
        }
        public virtual string ToEndUriFragment()
        {
            return $"/{GroupId}";
        }

    }
}

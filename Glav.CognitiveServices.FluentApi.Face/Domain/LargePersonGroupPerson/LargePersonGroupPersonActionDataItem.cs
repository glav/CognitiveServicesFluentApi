using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public abstract class LargePersonGroupPersonActionDataItem : LargePersonGroupActionDataItem
    {
        protected LargePersonGroupPersonActionDataItem(long id, ApiActionDefinition apiDefinition,
                string groupId,
                string name,
                string userData) : base(id,apiDefinition,groupId, name, userData)
        {
        }

        protected LargePersonGroupPersonActionDataItem(long id, ApiActionDefinition apiDefinition, string groupId, string personId)
                : base(id,apiDefinition,groupId)
        {
            ValidateId(personId, "personId");
            PersonId = personId;
        }

        public string PersonId { get; private set; }

        public override string ToEndUriFragment()
        {
            var urlFragment = $"/{GroupId}/persons";
            if (!string.IsNullOrWhiteSpace(PersonId))
            {
                return $"{urlFragment}/{PersonId}";
            }
            return urlFragment;
        }

    }
}

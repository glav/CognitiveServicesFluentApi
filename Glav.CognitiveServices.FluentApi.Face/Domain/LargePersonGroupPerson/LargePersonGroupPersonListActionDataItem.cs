using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup;
using System;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public class LargePersonGroupPersonListActionDataItem : LargePersonGroupListActionDataItem
    {
        public LargePersonGroupPersonListActionDataItem(long id, string groupId, string start = null, int? top = null)
            : base(id,start,top)
        {
            GroupId = groupId;

        }
        public string GroupId { get; private set; }

        public override ApiActionDefinition ApiDefintition => FaceApiOperations.LargePersonGroupPersonList;

    }
}

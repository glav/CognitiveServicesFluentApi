﻿namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup
{
    public class LargePersonGroupCreateActionDataItem : LargePersonGroupActionDataItem
    {
        public LargePersonGroupCreateActionDataItem(long id, string groupId,
                string name,
                string userData = null) : base(id, FaceApiOperations.LargePersonGroupCreate,groupId, name, userData)
        {

        }
    }
}

using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public class LargePersonGroupPersonActionData : ApiActionDataCollection
    {
        public override bool SupportsBatchingMultipleItems => false;

        public void AddPersonGroupPersonCreate(string groupId,
                string name,
                string userData = null)
        {
            ItemList.Add(new LargePersonGroupPersonCreateActionDataItem(ItemList.Count+1, groupId,name,userData));
        }

        public void AddPersonGroupPersonGet(string groupId, string personId)
        {
            ItemList.Add(new LargePersonGroupPersonGetActionDataItem(ItemList.Count + 1, groupId,personId));
        }

        public void AddPersonGroupPersonList(string groupId, string start, int? top = null)
        {
            ItemList.Add(new LargePersonGroupPersonListActionDataItem(ItemList.Count+1,groupId,start,top));
        }

        public void AddPersonGroupPersonDelete(string groupId, string personId)
        {
            ItemList.Add(new LargePersonGroupPersonDeleteActionDataItem(ItemList.Count + 1, groupId,personId));
        }

        public void AddFaceToPersonGroupPerson(string groupId, string personId, Uri imageUri, string userData = null, FaceRectangle targetFace = null)
        {
            ItemList.Add(new LargePersonGroupPersonFaceAddActionDataItem(ItemList.Count + 1, groupId, personId, imageUri, userData, targetFace));
        }

        public void GetFaceForPersonGroupPerson(string groupId, string personId, string persistedFaceId)
        {
            ItemList.Add(new LargePersonGroupPersonFaceGetActionDataItem(ItemList.Count + 1, groupId, personId, persistedFaceId));
        }
    }
}

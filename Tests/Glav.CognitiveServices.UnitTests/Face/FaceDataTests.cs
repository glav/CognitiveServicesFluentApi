using Xunit;
using Glav.CognitiveServices.UnitTests.Helpers;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Face;
using Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using System.Linq;

namespace Glav.CognitiveServices.UnitTests.TextAnalytic
{
    public class FaceDataTests
    {
        private TestDataHelper _helper = new TestDataHelper();

        [Fact]
        public void FaceIdentificationDataShouldProduceValidJson()
        {
            var actionData = new FaceIdentificationActionData();
            actionData.Add("personGroup1", new string[] { "1", "2" });
            actionData.Add("personGroup2", new string[] { "3", "4" },99,0.5f);
            var actionItems = actionData.GetAllItems().ToList();

            dynamic json1Object = Newtonsoft.Json.Linq.JObject.Parse(actionItems[0].ToString());
            Assert.NotNull(json1Object);
            Assert.Equal("personGroup1", (string)json1Object.largePersonGroupId);
            Assert.NotEmpty(json1Object.faceIds);

            dynamic json2Object = Newtonsoft.Json.Linq.JObject.Parse(actionItems[1].ToString());
            Assert.NotNull(json2Object);
            Assert.Equal("personGroup2", (string)json2Object.largePersonGroupId);
            Assert.NotEmpty(json2Object.faceIds);
            Assert.Equal(99, (int)json2Object.maxNumOfCandidatesReturned);
            Assert.Equal(0.5f, (float)json2Object.confidenceThreshold);
        }

    }
}

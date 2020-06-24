using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using Glav.CognitiveServices.FluentApi.Luis.Domain.ApiResponses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Linq;
using System.Collections.Generic;

namespace Glav.CognitiveServices.FluentApi.Luis.Domain
{
    public class LuisAppAnalysisResult : BaseApiResponse<LuisAppResponseRoot>
    {
        public LuisAppAnalysisResult(ICommunicationResult apiCallResult) : base(apiCallResult)
        {
            PerformCustomResponseParsing();
        }

        private void PerformCustomResponseParsing()
        {
            if (ApiCallResult == null)
            {
                ResponseData = new LuisAppResponseRoot { error = new BaseApiErrorResponse { message = StandardResponseCodes.NoDataReturnedMessage } };
                ActionSubmittedSuccessfully = false;
                return;
            }

            if (((int)ApiCallResult.StatusCode) >= (int)HttpStatusCode.BadRequest || !ApiCallResult.Successfull)
            {
                ActionSubmittedSuccessfully = false;

                ResponseData = new LuisAppResponseRoot { error = new BaseApiErrorResponse { code= ApiCallResult.StatusCode.ToString(), message = ApiCallResult.ErrorMessage } };
                return;
            }

            try
            {
                JObject rawData = JObject.Parse(ApiCallResult.Data);
                ResponseData = new LuisAppResponseRoot { query = (string)rawData["query"], prediction = new LuisAppPrediction() };
                dynamic msg = JsonConvert.DeserializeObject(ApiCallResult.Data);
                ResponseData.prediction.topIntent = (string)rawData["prediction"]["topIntent"];

                // Ugly as sin
                var root = ((JObject)msg).Children().ToList();
                if (root.Count < 2)
                {
                    return;
                }
                var predictionRoot = root[1].Children().ToList();
                if (predictionRoot.Count == 0)
                {
                    return;
                }
                var predictionChildren = predictionRoot[0].Children().ToList();

                ExtractIntents(predictionChildren);
                ExtractEntities(predictionChildren);

                ActionSubmittedSuccessfully = true;
            }
            catch (Exception ex)
            {
                ResponseData = new LuisAppResponseRoot  { error = new BaseApiErrorResponse { message = $"Error parsing results: {ex.Message}" } };
                ActionSubmittedSuccessfully = false;
            }
        }

        private void ExtractEntities(List<JToken> predictionChildren)
        {
            if (predictionChildren.Count < 3)
            {
                return;
            }
            var entitiesRoot = predictionChildren[2].Children().ToList();
            if (entitiesRoot.Count == 0)
            {
                return;
            }
            var entitiesChildren = entitiesRoot[0].Children().ToList();
            var entities = new List<LuisAppEntity>();
            foreach (var childEntitiy in entitiesChildren)
            {
                var prop = childEntitiy as JProperty;
                if (prop?.Name == "$instance")
                {
                    continue;
                }
                var entitiesIdentified = prop.Children().ToList()[0].Children().ToList();

                var listOfEntitiesIdentified = new List<string>();
                foreach (var entityIdentified in entitiesIdentified)
                {
                    listOfEntitiesIdentified.Add(entityIdentified.Value<string>());
                }

                entities.Add(new LuisAppEntity { entityIdentifier = prop?.Name, entities = listOfEntitiesIdentified.ToArray() });
            }
            ResponseData.prediction.entityInstanceList = new LuisAppEntityInstanceList { entityIdentifiers = entities.ToArray(), instanceData = new LuisAppInstanceData() };
        }

        private void ExtractIntents(List<JToken> predictionChildren)
        {
            if (predictionChildren.Count < 2)
            {
                return;
            }
            var intentsRoot = predictionChildren[1].Children().ToList();

            if (intentsRoot.Count == 0)
            {
                return;
            }
            var intentsChildren = intentsRoot[0].Children().ToList();

            //var intents = ((Newtonsoft.Json.Linq.JObject)msg).Children().ToList()[1].Children().ToList()[0].Children().ToList()[1].Children().ToList()[0].Children().ToList();

            var intents = new List<LuisAppIntent>();
            foreach (var childIntent in intentsChildren)
            {
                var prop = childIntent as JProperty;
                var name = prop?.Name;
                var innerChild = (childIntent.Children().FirstOrDefault() as JProperty);
                var score = (double)childIntent.Children().FirstOrDefault().Children().FirstOrDefault();
                intents.Add(new LuisAppIntent { intent = name, score = score });
            }
            ResponseData.prediction.intents = intents.ToArray();
        }
    }
}

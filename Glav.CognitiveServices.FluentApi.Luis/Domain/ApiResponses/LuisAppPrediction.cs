﻿namespace Glav.CognitiveServices.FluentApi.Luis.Domain.ApiResponses
{
    public class LuisAppPrediction
    {
        public string topIntent { get; set; }
        public LuisAppIntent[] intents { get; set; }
        public LuisAppEntities entities {get; set;}

    }


}
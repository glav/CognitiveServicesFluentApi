using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Luis.Domain
{
    public class LuisAppActionData : ApiActionDataCollection
    {
        public override bool SupportsBatchingMultipleItems => false;

        public void Add(string appId, string subscriptionKey, string query,
            bool isVerbose = true, bool showAllIntents = true, bool shouldLog = true)
        {
            ItemList.Add(new LuisAppActionDataItem(ItemList.Count + 1,appId, subscriptionKey, query, isVerbose, showAllIntents, shouldLog));
        }

    }

    public class LuisAppActionDataItem : IActionDataItem
    {
        public LuisAppActionDataItem(long id, string appId, string subscriptionKey, string query, 
            bool isVerbose = true, bool showAllIntents = true, bool shouldLog = true)
        {
            Id = id;
            AppId = appId;
            SubscriptionKey = subscriptionKey;
            Query = query;
            IsVerbose = isVerbose;
            ShowAllIntents = showAllIntents;
            ShouldLog = shouldLog;
        }
        public long Id { get; private set; }

        public string AppId { get; private set; }
        public string SubscriptionKey { get; private set; }
        public string Query { get; private set; }
        public bool IsVerbose { get; private set; }
        public bool ShowAllIntents { get; private set; }
        public bool ShouldLog { get; private set; }

        public ApiActionDefinition ApiDefintition => LuisAnalysisApiOperations.LuisAnalysis;

        public bool IsBinaryData => false;

        public byte[] ToBinary()
        {
            throw new NotImplementedException();
        }

        public string ToEndUriFragment()
        {
            throw new NotImplementedException();
        }

        public string ToUrlQueryParameters()
        {
            throw new NotImplementedException();
        }
    }
}

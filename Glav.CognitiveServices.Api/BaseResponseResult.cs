using Glav.CognitiveServices.Api.Fluent.Contracts;
using System.Collections.Generic;
using Glav.CognitiveServices.Api.Communication;

namespace Glav.CognitiveServices.Api
{
    public abstract class BaseResponseResult<T> : IApiAnalysisResult<T> where T : IActionResponseRoot
    {
        protected List<T> _itemList = new List<T>();

        protected IEnumerable<T> AllItems()
        {
            return _itemList.ToArray();
        }

        protected List<T> ItemList { get { return _itemList; } }

        public T ResponseData { get; protected set; }

        public ICommunicationResult ApiCallResult { get; protected set; }
        public bool ActionSubmittedSuccessfully { get; protected set; }
    }
}

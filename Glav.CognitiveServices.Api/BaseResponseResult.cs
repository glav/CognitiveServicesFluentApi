using Glav.CognitiveServices.Api.Fluent.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.Api.Fluent.Http;

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

        public HttpResult ApiCallResult { get; protected set; }
        public bool Successfull { get; protected set; }
    }
}

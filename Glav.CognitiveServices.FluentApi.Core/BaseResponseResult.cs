﻿using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System.Collections.Generic;
using Glav.CognitiveServices.FluentApi.Core.Communication;

namespace Glav.CognitiveServices.FluentApi.Core
{
    public abstract class BaseResponseResult<T> : IApiRequestResult<T> where T : IActionResponseRoot
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

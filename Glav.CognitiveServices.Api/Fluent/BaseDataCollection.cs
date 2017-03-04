using Glav.CognitiveServices.Api.Fluent.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent
{
    public abstract class BaseDataCollection<T> where T : IActionDataItem
    {
        protected List<T> _itemList = new List<T>();

        protected IEnumerable<T> AllItems()
        {
            return _itemList.ToArray();
        }

        protected List<T> ItemList { get { return _itemList; } }

    }
}

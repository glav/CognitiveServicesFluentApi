using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.Contracts
{
    public interface IApiActionDataCollection
    {
        List<IActionDataItem> ItemList { get;  }
        IActionDataItem[] GetAllItems();
        string ToUrlQueryParameters();
        /// <summary>
        /// If multiple action data items are present, setting this property to true will mean that the multiple action data
        /// items can be submitted for analysis in one call. This effectively means a <see cref="ToString()"/> can be called on
        /// the class implementing <see cref="IApiActionDataCollection"/> interface and it will batch or group all the action data items
        /// on one payload for submission in one call. Setting this to false, means each action data item will be submitted
        /// separately, that is, one API call per data item. This implicitly means a <see cref="ToString()"/> is called on the data
        /// item, not the implementor of <see cref="IApiActionDataCollection"/>.
        /// </summary>
        bool SupportsBatchingMultipleItems { get; }

    }

    public class ApiActionDataCollection// : IApiActionDataCollection 
    {
        private readonly List<IActionDataItem> _itemList = new List<IActionDataItem>();
        protected List<IActionDataItem> ItemList => _itemList;

        public IEnumerable<IActionDataItem> GetAllItems()
        {
            return ItemList.AsEnumerable();
        }

        public virtual string ToUrlQueryParameters()
        {
            return null;
        }
        /// <summary>
        /// If multiple action data items are present, setting this property to true will mean that the multiple action data
        /// items can be submitted for analysis in one call. This effectively means a <see cref="ToString()"/> can be called on
        /// the class implementing <see cref="IApiActionDataCollection"/> interface and it will batch or group all the action data items
        /// on one payload for submission in one call. Setting this to false, means each action data item will be submitted
        /// separately, that is, one API call per data item. This implicitly means a <see cref="ToString()"/> is called on the data
        /// item, not the implementor of <see cref="IApiActionDataCollection"/>.
        /// </summary>
        public virtual bool SupportsBatchingMultipleItems { get; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.Contracts
{
    public interface IApiActionData
    {
        string ToUrlQueryParameters();

    }

    public abstract class ApiActionDataCollection<T> where T : IActionDataItem
    {
        protected List<T> ItemList = new List<T>();

        public T[] GetAllItems()
        {
            return ItemList.ToArray();
        }

    }
}

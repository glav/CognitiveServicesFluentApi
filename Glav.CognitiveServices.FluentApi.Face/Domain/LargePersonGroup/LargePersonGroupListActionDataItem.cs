using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup
{
    public class LargePersonGroupListActionDataItem : IActionDataItem
    {
        public LargePersonGroupListActionDataItem(long id, string start= null, int? top = null)
        {
            Id = id;
            Start = start;
            if (top.HasValue && top.Value > 1000)
            {
                throw new ArgumentException("top cannot be greater than 1000");
            }
            Top = top;

        }
        public long Id { get; private set; }

        public virtual ApiActionDefinition ApiDefintition => FaceApiOperations.LargePersonGroupList;

        public bool IsBinaryData => false;

        public string Start { get; private set; }
        public int? Top { get; private set; }

        public byte[] ToBinary()
        {
            return null;
        }

        public virtual string ToEndUriFragment()
        {
            return null;
        }

        public virtual string ToUrlQueryParameters()
        {
            var url = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(Start))
            {
                url.AppendFormat("{0}{1}", url.Length > 0 ? "&" : string.Empty, $"{Configuration.ApiConstants.LargePersonGroupStartParameterName}={Start}");
            }
            if (Top.HasValue)
            {
                url.AppendFormat("{0}{1}", url.Length > 0 ? "&" : string.Empty, $"{Configuration.ApiConstants.LargePersonGroupTopParameterName}={Top}");
            }
            return url.ToString();

        }
    }
}

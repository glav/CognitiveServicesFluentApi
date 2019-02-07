using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public class LargePersonGroupListActionDataItem : IActionDataItem
    {
        public LargePersonGroupListActionDataItem(long id, string start= null, int? top = null)
        {
            Id = id;
            Start = start;
            Top = top;
        }
        public long Id { get; private set; }

        public ApiActionDefinition ApiDefintition => FaceApiOperations.LargePersonGroupList;

        public bool IsBinaryData => false;

        public string Start { get; private set; }
        public int? Top { get; private set; }

        public byte[] ToBinary()
        {
            return null;
        }

        public string ToEndUriFragment()
        {
            return null;
        }

        public string ToUrlQueryParameters()
        {
            var url = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(Start))
            {
                url.AppendFormat("{0}{1}", url.Length > 0 ? "&" : string.Empty, $"{Configuration.ApiConstants.LargePersonGroupStartParameterName}={Start}");
            }
            if (Top.HasValue)
            {
                url.AppendFormat("{0}{1}", url.Length > 0 ? "&" : string.Empty, $"{Configuration.ApiConstants.LargePersonGroupStopParameterName}={Top}");
            }
            return url.ToString();

        }
    }
}

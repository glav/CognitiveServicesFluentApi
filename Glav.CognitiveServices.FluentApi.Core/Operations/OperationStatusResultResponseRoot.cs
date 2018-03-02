using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;

namespace Glav.CognitiveServices.FluentApi.Core.Operations
{
    public class OperationStatusResultResponseRoot : IActionResponseRoot
    {
        public string status { get; set; }
        public string createdDateTime { get; set; }
        public string lastActionDateTime { get; set; }
        public string message { get; set; }
    }

}

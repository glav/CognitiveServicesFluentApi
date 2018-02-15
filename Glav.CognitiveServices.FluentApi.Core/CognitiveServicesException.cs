using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core
{
    public class CognitiveServicesException : ApplicationException
    {
        public CognitiveServicesException()
        {
        }

        public CognitiveServicesException(string message) : base(message)
        {
        }

        public CognitiveServicesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CognitiveServicesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

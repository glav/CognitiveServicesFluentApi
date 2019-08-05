using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core
{
    [System.SerializableAttribute]
    public class CognitiveServicesArgumentException : CognitiveServicesException
    {
        public CognitiveServicesArgumentException()
        {
        }

        public CognitiveServicesArgumentException(string message) : base(message)
        {
        }

        public CognitiveServicesArgumentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CognitiveServicesArgumentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

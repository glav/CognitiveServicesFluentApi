using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Diagnostics
{
    public interface IDiagnosticTrace
    {
        void Log(string topic, string message, DiagnosticMessageType messageType);
        void LogError(string topic, string message);
        void LogError(string topic, Exception ex);
    }
}

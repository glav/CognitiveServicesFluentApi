using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.Diagnostics
{
    public interface IDiagnosticLogger
    {
        void LogInfo(string message, string topic = null);
        void LogWarning(string message, string topic = null);
        void LogError(string message, string topic = null);
        void LogError(Exception ex, string topic = null);

        void SetLogLevel(LoggingLevel logLevel);
    }
}
